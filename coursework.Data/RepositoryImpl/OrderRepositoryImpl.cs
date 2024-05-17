using coursework.Data.Repository;
using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Data.RepositoryImpl
{
    public class OrderRepositoryImpl(OrderDbRepository repository) : OrderRepository
    {
        public async Task<bool> AddOrder(int cId, string addr, int cost, int pCount, DateOnly date, int pId, List<Product> products)
        {
            return await repository.AddOrder(cId, addr, cost, pCount, date, pId, products);
        }

        public IAsyncEnumerable<Order> FilterOrder(int id)
        {
            return repository.FilterOrder(id);
        }

        public IAsyncEnumerable<CartOrder> GetCartOrder(int id)
        {
            return repository.GetCartOrder(id);
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await repository.GetOrderById(id);
        }

        public IAsyncEnumerable<Order> GetOrders()
        {
            return repository.GetOrders();
        }

        public async Task<bool> UpdateOrderStatus(int id)
        {
            return await repository.UpdateOrderStatus(id);
        }
    }
}
