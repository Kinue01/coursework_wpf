using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class GetOrdersUseCase(OrderRepository repository)
    {
        public IAsyncEnumerable<Order> Execute()
        {
            return repository.GetOrders();
        }
    }
}
