using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class GetEmployeesUseCase(EmployeeRepository repository)
    {
        public IAsyncEnumerable<Employee> Execute()
        {
            return repository.GetEmployees();
        }
    }
}
