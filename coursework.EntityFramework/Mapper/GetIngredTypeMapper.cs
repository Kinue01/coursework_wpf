using coursework.Domain.Model;
using coursework.EntityFramework.Model;

namespace coursework.EntityFramework.Mapper
{
    public class GetIngredTypeMapper
    {
        public IngredType MapFromModel(GetIngredsType type)
        {
            return new IngredType(type.TypeId.GetValueOrDefault(), type.TypeName, type.TypeStorageTemp.GetValueOrDefault(), type.TypeStorageHumidity.GetValueOrDefault());
        }
    }
}
