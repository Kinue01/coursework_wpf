using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class AddCartOrderUseCase(CartOrderRepository repository)
    {
        public async Task<bool> Execute(List<CartOrder> cartOrders)
        {
            return await repository.AddCartOrder(cartOrders);
        }
    }
}
