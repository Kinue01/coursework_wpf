using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class GetEmployeeUseCase(EmployeeRepository repository)
    {
        public async Task<Employee> Execute(string login)
        {
            return await repository.GetEmployee(login);
        }
    }
}
