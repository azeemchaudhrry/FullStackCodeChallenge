﻿using Common.Enums;

namespace Sample.EntityModels.EmployeeDTO;

public class InsertEmployeeDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public Gender Gender { get; set; }
}
