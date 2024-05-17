using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class GetEmployeeByIdUseCase(EmployeeRepository repository)
    {
        public async Task<Employee> Execute(int id)
        {
            return await repository.GetEmployeeById(id);
        }
    }
}
