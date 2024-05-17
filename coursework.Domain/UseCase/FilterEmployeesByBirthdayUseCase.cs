using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class FilterEmployeesByBirthdayUseCase(EmployeeRepository repository)
    {
        public IAsyncEnumerable<Employee> Execute(DateOnly date)
        {
            return repository.FilterByBirthday(date);
        }
    }
}
