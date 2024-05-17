using coursework.Domain.Model;
using coursework.Domain.UseCase;
using coursework.EntityFramework.Model;

namespace coursework.EntityFramework.Mapper
{
    public class TbOrderMapper(GetClientByIdUseCase clientByIdUseCase, GetOrderStatusByIdUseCase getOrderStatusByIdUseCase)
    {
        public async Task<Order> MapFromModel(TbOrder order)
        {
            var client = await clientByIdUseCase.Execute(order.OrderClientId);
            var status = await getOrderStatusByIdUseCase.Execute(order.OrderStatusId);

            return new Order(order.OrderId, client.Lastname + client.Firstname + client.Middlename, order.OrderAddress, order.OrderCost, order.OrderProductCount, order.OrderDate, status.Name);
        }
    }
}