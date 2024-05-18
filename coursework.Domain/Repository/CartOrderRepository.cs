using coursework.Domain.Model;

namespace coursework.Domain.Repository
{
    public interface CartOrderRepository
    {
        Task<bool> AddCartOrder(List<CartOrder> cartOrders);
        Task<bool> UpdateEmployee(int order, int employee);
    }
}
