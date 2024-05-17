using coursework.Domain.Model;
using coursework.Domain.UseCase;
using coursework.EntityFramework.Model;

namespace coursework.EntityFramework.Mapper
{
    public class GetIngredsMapper(GetIngredTypeByIdUseCase getIngredTypeByIdUseCase)
    {
        public async Task<Ingredient> MapFromModel(GetIngred ingred)
        {
            return new Ingredient(ingred.IngredientId.GetValueOrDefault(), ingred.IngredientName, ingred.IngredientWeight.GetValueOrDefault(), await getIngredTypeByIdUseCase.Execute(ingred.TypeId.GetValueOrDefault()));
        }
    }
}
