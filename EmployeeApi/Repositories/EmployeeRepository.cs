using Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

       public async Task<(IEnumerable<Employee>, int)> GetAll(string? search, int page, int pageSize)
{
    var query = _context.Employees.AsQueryable();

    if (!string.IsNullOrEmpty(search))
    {
        query = query.Where(e => e.Name.Contains(search));
    }

    var totalCount = await query.CountAsync();

    var employees = await query
        .Skip((page - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();

    return (employees, totalCount);
}
        public async Task<Employee?> GetById(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<Employee> Create(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task Update(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var emp = await _context.Employees.FindAsync(id);

            if (emp != null)
            {
                _context.Employees.Remove(emp);
                await _context.SaveChangesAsync();
            }
        }
    }
}