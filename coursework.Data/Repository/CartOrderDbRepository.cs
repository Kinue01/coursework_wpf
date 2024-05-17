using coursework.Domain.Model;

namespace coursework.Data.Repository
{
    public interface CartOrderDbRepository
    {
        Task<bool> AddCartOrder(List<CartOrder> cartOrders);
    }
}
