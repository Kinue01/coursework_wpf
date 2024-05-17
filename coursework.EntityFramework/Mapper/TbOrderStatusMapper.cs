using coursework.Domain.Model;
using coursework.EntityFramework.Model;

namespace coursework.EntityFramework.Mapper
{
    public class TbOrderStatusMapper
    {
        public Status MapFromModel(TbOrderStatus status)
        {
            return new Status(status.StatusId, status.StatusName);
        }
    }
}
