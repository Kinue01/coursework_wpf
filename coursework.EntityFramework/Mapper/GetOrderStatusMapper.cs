using coursework.Domain.Model;
using coursework.EntityFramework.Model;

namespace coursework.EntityFramework.Mapper
{
    public class GetOrderStatusMapper
    {
        public Status MapFromModel(GetOrderStatus orderStatus)
        {
            return new Status(orderStatus.StatusId.GetValueOrDefault(), orderStatus.StatusName);
        }
    }
}
