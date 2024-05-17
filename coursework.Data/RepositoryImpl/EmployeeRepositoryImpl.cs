using coursework.Data.Repository;
using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Data.RepositoryImpl
{
    public class EmployeeRepositoryImpl(EmployeeDbRepository repository) : EmployeeRepository
    {
        public async Task<bool> AddEmployee(Employee employee, User user)
        {
            return await repository.AddEmployee(employee, user);
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            return await repository.DeleteEmployee(id);
        }

        public IAsyncEnumerable<Employee> FilterByBirthday(DateOnly date)
        {
            return repository.FilterByBirthday(date);
        }

        public IAsyncEnumerable<Employee> FilterByFio(string query)
        {
            return repository.FilterByFio(query);
        }

        public async Task<Employee> GetEmployee(string login)
        {
            return await repository.GetEmployee(login);
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await repository.GetEmployeeById(id);
        }

        public IAsyncEnumerable<Employee> GetEmployees()
        {
            return repository.GetEmployees();
        }

        public async Task<bool> UpdateEmployee(Employee employee, User user)
        {
            return await repository.UpdateEmployee(employee, user);
        }
    }
}
