using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationRedisPratice.Services;

namespace WebApplicationRedisPratice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase

    {
        private readonly IEmployeeService _service;

        public EmployeeController(
            IEmployeeService service)
        {
            _service = service;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var employee =
                await _service.GetEmployeeByIdAsync(id);

            if (employee == null)
                return NotFound("Employee not found");

            return Ok(employee);
        }

    }
}
