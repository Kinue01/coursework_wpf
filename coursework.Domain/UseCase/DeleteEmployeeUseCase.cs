using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class DeleteEmployeeUseCase(EmployeeRepository repository)
    {
        public async Task<bool> Execute(int id)
        {
            return await repository.DeleteEmployee(id);
        }
    }
}
