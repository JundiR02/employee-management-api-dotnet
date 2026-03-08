using Data;
using Models;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Services
{
    public class AuthService
    {
        private readonly AppDbContext _context;

        public AuthService(AppDbContext context)
        {
            _context = context;
        }

     public async Task<User?> Login(string username, string password)
{
    var user = await _context.Users
        .FirstOrDefaultAsync(x => x.Username == username);

    if (user == null)
    {
        Log.Warning("Login failed: username {Username} not found", username);
        return null;
    }

    bool validPassword = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);

    if (!validPassword)
    {
        Log.Warning("Login failed: wrong password for {Username}", username);
        return null;
    }

    Log.Information("User {Username} logged in successfully", username);

    return user;
}

public async Task<User> Register(string username, string password, string role)
{
    var existingUser = await _context.Users
        .FirstOrDefaultAsync(x => x.Username == username);

    if (existingUser != null)
        throw new Exception("Username already exists");

    // normalisasi role
    role = role.Substring(0,1).ToUpper() + role.Substring(1).ToLower();

    if(role != "Admin" && role != "User")
    throw new Exception("Role must be Admin or User");

    var user = new User
    {
        Username = username,
        PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
        Role = role
    };

    _context.Users.Add(user);
    await _context.SaveChangesAsync();

    return user;
}
    }
}