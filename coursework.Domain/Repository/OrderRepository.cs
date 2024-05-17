using coursework.Domain.Model;

namespace coursework.Domain.Repository
{
    public interface OrderRepository
    {
        IAsyncEnumerable<Order> GetOrders();
        IAsyncEnumerable<Order> FilterOrder(int id);
        IAsyncEnumerable<CartOrder> GetCartOrder(int id);
        Task<bool> AddOrder(int cId, string addr, int cost, int pCount, DateOnly date, int pId, List<Product> products);
        Task<Order> GetOrderById(int id);
        Task<bool> UpdateOrderStatus(int id);
    }
}
