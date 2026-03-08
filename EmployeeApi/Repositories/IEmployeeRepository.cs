using Models;

namespace Repositories
{
    public interface IEmployeeRepository
{
    Task<(IEnumerable<Employee>, int)> GetAll(string? search, int page, int pageSize);
    Task<Employee?> GetById(int id);
    Task<Employee> Create(Employee employee);
    Task Update(Employee employee);
    Task Delete(int id);
}
}