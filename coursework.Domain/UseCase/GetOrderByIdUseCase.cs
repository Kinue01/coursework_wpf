using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class GetOrderByIdUseCase(OrderRepository repository)
    {
        public async Task<Order> Execute(int id)
        {
            return await repository.GetOrderById(id);
        }
    }
}