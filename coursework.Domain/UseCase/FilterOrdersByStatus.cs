using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class FilterOrdersByStatus(OrderRepository repository)
    {
        public IAsyncEnumerable<Order> Execute(int id)
        {
            return repository.FilterOrder(id);
        }
    }
}
