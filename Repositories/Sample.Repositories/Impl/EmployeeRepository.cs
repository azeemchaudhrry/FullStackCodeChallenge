using Microsoft.EntityFrameworkCore;
using Sample.Domains.Entities;
using Sample.EntityModels.EmployeeDTO;
using Sample.Repositories.Contracts;
using Sample.Repositories.Data;

namespace Sample.Repositories.Impl;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly EmployeeDbContext _employeeDbContext;
    public EmployeeRepository(EmployeeDbContext employeeDbContext)
    {
        _employeeDbContext = employeeDbContext;
    }
    
    public async Task<bool> Delete(Guid Id)
    {
        var employee = _employeeDbContext.employees.SingleOrDefault(x => x.Id == Id);
        if (employee == null) return false;

        employee.DeletedDate = DateTime.UtcNow;

        await _employeeDbContext.SaveChangesAsync();

        return true;
    }

    public async Task<List<EmployeeDTO>> GetAll()
    {
        return await _employeeDbContext.employees.Select(x =>
                  new EmployeeDTO
                  {
                      Id = x.Id,
                      FirstName = x.FirstName,
                      LastName = x.LastName,
                      Age = x.Age,
                      Gender = x.Gender,
                      FullName = $"{x.FirstName} {x.LastName}",
                  }
             ).ToListAsync();
    }

    public async Task<Guid> Insert(InsertEmployeeDTO dto)
    {
        var entity = _employeeDbContext.employees.Add(new Employee
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Age = dto.Age,
            Gender = dto.Gender

        });

        // Save changes
        await _employeeDbContext.SaveChangesAsync();
        
        return entity.Entity.Id;
    }

    public async Task<bool> Update(UpdateEmployeeDTO dto)
    {
        var employee = _employeeDbContext.employees.SingleOrDefault(x => x.Id == dto.Id && x.DeletedDate == null);
        if (employee == null) return false;

        employee.FirstName = dto.FirstName;
        employee.LastName = dto.LastName;
        employee.Age = dto.Age;
        employee.Gender = dto.Gender;

        // Save changes
        await _employeeDbContext.SaveChangesAsync();

        return true;
    }
}
