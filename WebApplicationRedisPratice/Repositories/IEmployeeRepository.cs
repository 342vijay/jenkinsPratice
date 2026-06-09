using WebApplicationRedisPratice.Model;

namespace WebApplicationRedisPratice.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee?> GetByIdAsync(int id);
    }
}
