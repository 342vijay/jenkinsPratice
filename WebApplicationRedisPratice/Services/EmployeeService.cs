using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using WebApplicationRedisPratice.Dto;
using WebApplicationRedisPratice.Repositories;

namespace WebApplicationRedisPratice.Services
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        private readonly IDistributedCache _cache;

        public EmployeeService(
            IEmployeeRepository repository,
            IDistributedCache cache)
        {
            _repository = repository;
            _cache = cache;
        }
        public async Task<EmployeeResponseDto?> GetEmployeeByIdAsync(int id)
        {
            string cacheKey = $"employee_{id}";
            // 1. Check Redis Cache
            var cachedData = await _cache.GetStringAsync(cacheKey);
            if (!string.IsNullOrEmpty(cachedData))
            {
                Console.WriteLine("Data fetched from Redis");

                return JsonSerializer.Deserialize<EmployeeResponseDto>(
                    cachedData);
            }
            // 2. Fetch from Database
            var employee = await _repository.GetByIdAsync(id);
            if (employee == null)
                return null;

            // 3. Convert Entity to DTO
            var response = new EmployeeResponseDto
            {
                Id = employee.Id,
                Name = employee.Name,
                Department = employee.Department
            };
            // 4. Store in Redis
            var cacheOptions = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow =
                    TimeSpan.FromMinutes(5)
            };

            await _cache.SetStringAsync(
                cacheKey,
                JsonSerializer.Serialize(response),
                cacheOptions);

            Console.WriteLine("Data fetched from SQL and stored in Redis");

            return response;



        }
    }
}
