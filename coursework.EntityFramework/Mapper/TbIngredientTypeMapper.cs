using coursework.Domain.Model;
using coursework.EntityFramework.Model;

namespace coursework.EntityFramework.Mapper
{
    public class TbIngredientTypeMapper
    {
        public IngredType MapFromModel(TbIngredientType ingredient)
        {
            return new IngredType(ingredient.TypeId, ingredient.TypeName, ingredient.TypeStorageTemp, ingredient.TypeStorageHumidity);
        }
    }
}
