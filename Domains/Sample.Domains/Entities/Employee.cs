using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Common.Enums;

namespace Sample.Domains.Entities;

public class Employee : BaseModel
{
    [Required]
    public string FirstName { get; set; }
    
    [Required]
    public string LastName { get; set; }
    
    [Required]
    public int Age { get; set; }

    [Required]
    public Gender Gender { get; set; }

    [NotMapped]
    public string FullName { get; }

    public Employee()
    {
        FullName = $"{FirstName} {LastName}";
    }
}