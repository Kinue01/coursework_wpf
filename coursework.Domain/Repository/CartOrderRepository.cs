using coursework.Domain.Model;

namespace coursework.Domain.Repository
{
    public interface CartOrderRepository
    {
        Task<bool> AddCartOrder(List<CartOrder> cartOrders);
    }
}
