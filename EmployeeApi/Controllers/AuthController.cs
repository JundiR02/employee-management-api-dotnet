using Microsoft.AspNetCore.Mvc;
using DTOs;
using Services;
using Microsoft.AspNetCore.Authorization;
using Serilog;


namespace EmployeeApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]


    
    public class AuthController : ControllerBase
    {
         private readonly JwtService _jwtService;
        private readonly AuthService _authService;
        public AuthController(AuthService authService, JwtService jwtService)
    {
        _authService = authService;
        _jwtService = jwtService;
    }
[HttpGet("hash")]
public IActionResult GenerateHash()
{
    var hash = BCrypt.Net.BCrypt.HashPassword("admin123");
    return Ok(hash);
}

[HttpPost("login")]
public async Task<IActionResult> Login(LoginDto dto)
{
    var user = await _authService.Login(dto.Username, dto.Password);

    if (user == null)
        return Unauthorized("Username atau password salah");

    Log.Information("User logged in: {Username}", user.Username);

    var token = _jwtService.GenerateToken(user);

    return Ok(new
    {
        token = token
    });
}

[HttpPost("register")]
public async Task<IActionResult> Register(RegisterDto dto)
{
    var user = await _authService.Register(dto.Username, dto.Password, dto.Role);

    return Ok(new
    {
        message = "User registered successfully",
        username = user.Username,
        role = user.Role
    });
}
    }
}