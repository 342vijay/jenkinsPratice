using Microsoft.EntityFrameworkCore;
using WebApplicationRedisPratice.Data;
using WebApplicationRedisPratice.Model;

namespace WebApplicationRedisPratice.Repositories
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(
            AppDbContext context)
        {
            _context = context;
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
