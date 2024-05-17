using coursework.Domain.Model;
using coursework.Domain.UseCase;
using coursework.EntityFramework.Model;

namespace coursework.EntityFramework.Mapper
{
    public class GetCartOrderMapper(GetEmployeeByIdUseCase getEmployeeByIdUseCase, GetProductByIdUseCase getProductByIdUseCase)
    {
        public async Task<CartOrder> MapFromModel(GetCartOrder order)
        {
            Employee employee = new Employee();
            if (order.CartProdEmployeeId != null && order.CartProdEmployeeId != 0)
            {
                employee = await getEmployeeByIdUseCase.Execute(order.CartProdEmployeeId.GetValueOrDefault());
            }
            return new CartOrder(order.CartOrderId.GetValueOrDefault(), await getProductByIdUseCase.Execute(order.ProductId.GetValueOrDefault()), order.CartProdCount.GetValueOrDefault(), employee, order.CartProdProduceDate);
        }
    }
}