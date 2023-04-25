using Common.Enums;
using Sample.EntityModels.EmployeeDTO;

namespace Sample.Services.Contracts;

public interface IEmployeeService
{
    Task<Guid> Save(UpdateEmployeeDTO dto);
    Task<IEnumerable<EmployeeDTO>> GetAll(string FirstName, string LastName, Gender? Gender);
}
