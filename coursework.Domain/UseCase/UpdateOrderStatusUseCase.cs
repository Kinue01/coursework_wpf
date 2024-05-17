using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class UpdateOrderStatusUseCase(OrderRepository repository)
    {
        public async Task<bool> Execute(int id)
        {
            return await repository.UpdateOrderStatus(id);
        }
    }
}
