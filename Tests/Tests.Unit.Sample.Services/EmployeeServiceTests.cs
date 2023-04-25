using Common.Enums;
using FluentAssertions;
using Moq;
using Sample.EntityModels.EmployeeDTO;
using Sample.Repositories.Contracts;
using Sample.Services.Impl;
using Xunit;

namespace Tests.Unit.Sample.Services;

public class EmployeeServiceTests
{
    [Fact]
    public void EmployeeService_ShouldReturnAllEmployees_WhenGetAllExecuted()
    {
        //Arrange

        var lstEmployees = new List<EmployeeDTO>
        {
            new EmployeeDTO {
                Id = Guid.NewGuid(),
                FirstName = "FirstName",
                LastName = "LastName",
                Age = 25,
                Gender = Gender.Male,
                FullName = ""
            },
            new EmployeeDTO {
                Id = Guid.NewGuid(),
                FirstName = "FirstName",
                LastName = "LastName",
                Age = 25,
                Gender = Gender.Male,
                FullName = ""
            }
        };


        var mockRepo = new Mock<IEmployeeRepository>();
        mockRepo.Setup(repo => repo.GetAll())
                .Returns(Task.FromResult(lstEmployees));

        var services = new EmployeeService(mockRepo.Object);

        //Act
        var result = services.GetAll(string.Empty, string.Empty, null).Result;


        //Assert
        result.Count().Should().Be(2);
    }

    [Fact]
    public void EmployeeService_ShouldSaveEmployeeInfo_WhenSaveIsCalled()
    {
        //Arrange

        var insert_dto = new InsertEmployeeDTO()
        {
            FirstName = "FirstName",
            LastName = "LastName",
            Age = 12,
            Gender = Gender.Male
        };

        var insertDto = new UpdateEmployeeDTO()
        {
            Id = Guid.Empty,
            FirstName = "FirstName",
            LastName = "LastName",
            Age = 12,
            Gender = Gender.Male
        };

        var updateDto = new UpdateEmployeeDTO()
        {
            Id = Guid.NewGuid(),
            FirstName = "FirstName",
            LastName = "LastName",
            Age = 12,
            Gender = Gender.Male
        };

        var mockRepo = new Mock<IEmployeeRepository>();
        mockRepo.Setup(repo => repo.Insert(insert_dto))
                .Returns(Task.FromResult(Guid.NewGuid()));
        mockRepo.Setup(repo => repo.Update(updateDto))
                .Returns(Task.FromResult(true));

        var services = new EmployeeService(mockRepo.Object);

        //Act
        var insertResult = services.Save(insertDto).Result;
        var updateResult = services.Save(updateDto).Result;

        //Assert
        updateResult.Should().Be(updateDto.Id);
    }
}