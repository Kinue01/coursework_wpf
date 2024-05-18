using coursework.Domain.Model;

namespace coursework.Data.Repository
{
    public interface CartOrderDbRepository
    {
        Task<bool> AddCartOrder(List<CartOrder> cartOrders);
        Task<bool> UpdateEmployee(int order, int employee);
    }
}
