using coursework.Domain.Model;

namespace coursework.Data.Repository
{
    public interface OrderDbRepository
    {
        IAsyncEnumerable<Order> GetOrders();
        IAsyncEnumerable<Order> FilterOrder(int id);
        IAsyncEnumerable<CartOrder> GetCartOrder(int id);
        Task<bool> AddOrder(int cId, string addr, int cost, int pCount, DateOnly date, int pId, List<Product> products);
        Task<Order> GetOrderById(int id);
        Task<bool> UpdateOrderStatus(int id);
    }
}
