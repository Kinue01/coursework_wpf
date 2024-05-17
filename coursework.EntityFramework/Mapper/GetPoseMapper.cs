using coursework.Domain.Model;
using coursework.EntityFramework.Model;

namespace coursework.EntityFramework.Mapper
{
    public class GetPoseMapper
    {
        public Position MapFromModel(GetPose pose)
        {
            return new Position(pose.PositionId.GetValueOrDefault(), pose.PositionTitle, pose.PositionBasePay.GetValueOrDefault());
        }
    }
}
