using Common.Enums;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using Sample.Domains.Entities;
using Sample.Repositories.Data;
using Xunit;
using EmployeeRepository = Sample.Repositories.Impl.EmployeeRepository;

namespace Tests.Unit.Sample.Repositories.RepositoriesTests;

public class EmployeeRepositoryTests
{
    [Fact]
    public async void EmployeeDelete_ShouldDeleteEmplyee_WhenRequestedWithValidParameters()
    {
        //Arrange
        var employees = new List<Employee>
            {
                new Employee {
                    FirstName = "John",
                    LastName = "John",
                    Age = 25,
                    Gender = Gender.Male,
                },
                new Employee {
                    FirstName = "Smith",
                    LastName = "Smith",
                    Age = 25,
                    Gender = Gender.Male,
                }
        };

        var mockDbSet = new Mock<DbSet<Employee>>();
        var context = new Mock<EmployeeDbContext>();

        mockDbSet.As<IQueryable<Employee>>()
                 .Setup(x => x.Provider)
                 .Returns(employees.AsQueryable().Provider);
        mockDbSet.As<IQueryable<Employee>>()
                 .Setup(x => x.ElementType)
                 .Returns(employees.AsQueryable().ElementType);
        mockDbSet.As<IQueryable<Employee>>()
                 .Setup(x => x.Expression)
                 .Returns(employees.AsQueryable().Expression);
        mockDbSet.As<IQueryable<Employee>>()
                 .Setup(x => x.GetEnumerator())
                 .Returns(employees.GetEnumerator());

        context.Setup(x => x.employees).Returns(mockDbSet.Object);

        var repository = new EmployeeRepository(context.Object);

        //Act
        var result = await repository.Delete(employees[0].Id);

        // Assert            
        result.Should().BeTrue();
        employees[0].DeletedDate.Should().NotBeNull();
    }
}