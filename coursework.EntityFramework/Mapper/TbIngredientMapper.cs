using coursework.Domain.Model;
using coursework.Domain.UseCase;
using coursework.EntityFramework.Model;

namespace coursework.EntityFramework.Mapper
{
    public class TbIngredientMapper(GetIngredTypeByIdUseCase getIngredTypeByIdUseCase)
    {
        public async Task<Ingredient> MapFromModel(TbIngredient ingredient)
        {
            return new Ingredient(ingredient.IngredientId, ingredient.IngredientName, ingredient.IngredientWeight, await getIngredTypeByIdUseCase.Execute(ingredient.IngredientTypeId));
        }
    }
}
