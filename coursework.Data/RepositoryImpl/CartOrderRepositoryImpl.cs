using coursework.Data.Repository;
using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Data.RepositoryImpl
{
    public class CartOrderRepositoryImpl(CartOrderDbRepository repository) : CartOrderRepository
    {
        public async Task<bool> AddCartOrder(List<CartOrder> cartOrders)
        {
            return await repository.AddCartOrder(cartOrders);
        }

        public async Task<bool> UpdateEmployee(int order, int employee)
        {
            return await repository.UpdateEmployee(order, employee);
        }
    }
}
