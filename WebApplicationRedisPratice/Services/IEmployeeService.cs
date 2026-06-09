using WebApplicationRedisPratice.Dto;

namespace WebApplicationRedisPratice.Services
{
    public interface IEmployeeService
    {
        public  Task<EmployeeResponseDto?> GetEmployeeByIdAsync(int id);
    }
}
