using coursework.Domain.Model;
using coursework.EntityFramework.Model;

namespace coursework.EntityFramework.Mapper
{
    public class GetPayTypeMapper
    {
        public Paytype MapFromModel(GetPayType payType)
        {
            return new Paytype(payType.TypeId.GetValueOrDefault(), payType.TypeName);
        }
    }
}
