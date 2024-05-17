using coursework.Domain.Model;
using coursework.EntityFramework.Model;

namespace coursework.EntityFramework.Mapper
{
    public class TbPositionMapper
    {
        public Position MapFromModel(TbPosition position)
        {
            return new Position(position.PositionId, position.PositionTitle, position.PositionBasePay);
        }
    }
}
