using Common.Enums;
using Sample.EntityModels.EmployeeDTO;
using Sample.Repositories.Contracts;
using Sample.Services.Contracts;

namespace Sample.Services.Impl;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    
    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<IEnumerable<EmployeeDTO>> GetAll(string FirstName, string LastName, Gender? Gender)
    {
        // use IQueriable to build query
        var employees = await _employeeRepository.GetAll();
        return employees.Where(x => (x.FirstName == FirstName || FirstName == string.Empty) &&
        (x.LastName == LastName || LastName == string.Empty) &&
        (x.Gender == Gender || Gender == null)).ToList();
    }

    public async Task<Guid> Save(UpdateEmployeeDTO dto)
    {
        if (dto.Id == Guid.Empty)
            return await _employeeRepository.Insert(new InsertEmployeeDTO { FirstName = dto.FirstName, LastName = dto.LastName, Age = dto.Age, Gender = dto.Gender });
        else
            await _employeeRepository.Update(dto);
        return dto.Id;
    }
}
