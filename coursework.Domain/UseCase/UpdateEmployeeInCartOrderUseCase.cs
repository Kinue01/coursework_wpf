using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class UpdateEmployeeInCartOrderUseCase(CartOrderRepository repository)
    {
        public async Task<bool> Execute(int order, int employee)
        {
            return await repository.UpdateEmployee(order, employee);
        }
    }
}
