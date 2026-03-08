using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;
using Models;
using AutoMapper;
using DTOs;
using Services;
using Helpers;
using Microsoft.AspNetCore.Authorization;
using Serilog;

namespace EmployeeApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]

    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeService _service;
        private readonly IMapper _mapper;
        public EmployeesController(EmployeeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
    
[Authorize(Roles = "Admin,User")]
[HttpGet]
public async Task<IActionResult> GetAll(
    string? search,
    int page = 1,
    int pageSize = 5)
{
    var (employees, totalCount) = await _service.GetAll(search, page, pageSize);

return Ok(new
{
    data = _mapper.Map<IEnumerable<EmployeeReadDto>>(employees),
    meta = new
    {
        page,
        pageSize,
        totalCount,
        totalPages = (int)Math.Ceiling((double)totalCount / pageSize)
    }
});
}

[Authorize(Roles = "Admin")]
[HttpPost]
public async Task<IActionResult> Create(EmployeeCreateDto dto)
{
    var employee = _mapper.Map<Employee>(dto);

    var created = await _service.Create(employee);

    Log.Information("Employee created: {Name}", created.Name);

    var result = _mapper.Map<EmployeeReadDto>(created);

    return Ok(new ApiResponse<EmployeeReadDto>(
        true,
        "Employee created successfully",
        result
    ));
}

[Authorize(Roles = "Admin")]
[HttpPut("{id}")]
public async Task<IActionResult> Update(int id, EmployeeUpdateDto dto)
{
    var employee = _mapper.Map<Employee>(dto);

    var updated = await _service.Update(id, employee);

    if (updated == null)
        return NotFound(new ApiResponse<string>(
            false,
            "Employee not found",
            null
        ));
    Log.Information("Employee updated: {Id} - {Name}", updated.Id, updated.Name);

    var result = _mapper.Map<EmployeeReadDto>(updated);

    return Ok(new ApiResponse<EmployeeReadDto>(
        true,
        "Employee updated successfully",
        result
    ));
}

[Authorize(Roles = "Admin")]
[HttpDelete("{id}")]
public async Task<IActionResult> Delete(int id)
{
    var emp = await _service.GetById(id);

    if (emp == null)
    return NotFound(new ApiResponse<string>(
        false,
        "Employee not found",
        null
    ));

    await _service.Delete(id);

    Log.Information("Employee deleted with id {Id}", id);

    return Ok(new ApiResponse<string>(
        true,
        "Employee deleted successfully",
        null
    ));
}
    }
}