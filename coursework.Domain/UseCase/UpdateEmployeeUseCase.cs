using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class UpdateEmployeeUseCase(EmployeeRepository repository)
    {
        public async Task<bool> Execute(Employee employee, User user)
        {
            return await repository.UpdateEmployee(employee, user);
        }
    }
}
