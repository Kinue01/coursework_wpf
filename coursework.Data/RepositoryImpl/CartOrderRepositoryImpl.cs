using coursework.Data.Repository;
using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Data.RepositoryImpl
{
    public class CartOrderRepositoryImpl(CartOrderDbRepository repository) : CartOrderRepository
    {
        public Task<bool> AddCartOrder(List<CartOrder> cartOrders)
        {
            return repository.AddCartOrder(cartOrders);
        }
    }
}
