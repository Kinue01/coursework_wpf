using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class FilterEmployeesByFioUseCase(EmployeeRepository repository)
    {
        public IAsyncEnumerable<Employee> Execute(string fio)
        {
            return repository.FilterByFio(fio);
        }
    }
}
