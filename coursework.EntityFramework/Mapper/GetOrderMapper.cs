using coursework.Domain.Model;
using coursework.EntityFramework.Model;

namespace coursework.EntityFramework.Mapper
{
    public class GetOrderMapper
    {
        public Order MapFromModel(GetOrder order)
        {
            return new Order(order.OrderId.GetValueOrDefault(), order.Concat, order.OrderAddress, order.OrderCost.GetValueOrDefault(), order.OrderProductCount.GetValueOrDefault(), order.TypeName.GetValueOrDefault(), order.StatusName);
        }
    }
}
