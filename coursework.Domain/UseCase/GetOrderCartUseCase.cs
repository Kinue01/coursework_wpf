using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class GetOrderCartUseCase(OrderRepository repository)
    {
        public IAsyncEnumerable<CartOrder> Execute(int id)
        {
            return repository.GetCartOrder(id);
        }
    }
}
