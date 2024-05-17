using coursework.Domain.Model;

namespace coursework.Domain.Repository
{
    public interface EmployeeRepository
    {
        Task<Employee> GetEmployee(string login);
        IAsyncEnumerable<Employee> GetEmployees();
        Task<Employee> GetEmployeeById(int id);
        IAsyncEnumerable<Employee> FilterByFio(string query);
        IAsyncEnumerable<Employee> FilterByBirthday(DateOnly date);
        Task<bool> AddEmployee(Employee employee, User user);
        Task<bool> DeleteEmployee(int id);
        Task<bool> UpdateEmployee(Employee employee, User user);
    }
}