using Common.Enums;

namespace Sample.EntityModels.EmployeeDTO;

public class EmployeeDTO
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName { get; set; }
    public int Age { get; set; }
    public Gender Gender { get; set; }
}