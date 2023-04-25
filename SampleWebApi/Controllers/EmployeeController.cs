using Common.Enums;
using Microsoft.AspNetCore.Mvc;
using Sample.EntityModels.EmployeeDTO;
using Sample.Services.Contracts;

namespace SampleWebApi.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll(string? firstName, string? lastName, Gender? gender)
        {
            var response = await _employeeService.GetAll(firstName ?? string.Empty, lastName ?? string.Empty, gender);
            return response.Count() > 0 ? Ok(response) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Save(UpdateEmployeeDTO dto)
        {
            if (dto.FirstName == null || dto.LastName == null || dto.Gender == 0)
                return BadRequest("Required fields are missing.");
            
            var response = await _employeeService.Save(dto);
            return Ok(response);
        }
    }
}
