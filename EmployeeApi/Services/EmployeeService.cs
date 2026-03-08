using Models;
using Repositories;


namespace Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _repo;

        public EmployeeService(IEmployeeRepository repo)
        {
            _repo = repo;
        }

       public async Task<(IEnumerable<Employee>, int)> GetAll(string? search, int page, int pageSize)
{
    return await _repo.GetAll(search, page, pageSize);
}
        

        public async Task<Employee?> GetById(int id)
        {
            return await _repo.GetById(id);
        }

        public async Task<Employee> Create(Employee emp)
        {
            return await _repo.Create(emp);
        }

        public async Task<Employee?> Update(int id, Employee employee)
        {
            var existing = await _repo.GetById(id);

            if (existing == null)
                return null;

            existing.Name = employee.Name;
            existing.Position = employee.Position;
            existing.Salary = employee.Salary;

            await _repo.Update(existing);

            return existing;
        }

        public async Task Delete(int id)
        {
            await _repo.Delete(id);
        }
    }
}