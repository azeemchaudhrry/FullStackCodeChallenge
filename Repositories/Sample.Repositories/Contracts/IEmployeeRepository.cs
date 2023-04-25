using Sample.EntityModels.EmployeeDTO;

namespace Sample.Repositories.Contracts;

public interface IEmployeeRepository
{
    Task<Guid> Insert(InsertEmployeeDTO dto);
    Task<bool> Update(UpdateEmployeeDTO dto);
    Task<bool> Delete(Guid Id);
    Task<List<EmployeeDTO>> GetAll();
}
