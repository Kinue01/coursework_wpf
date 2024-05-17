using coursework.Domain.Model;
using coursework.Domain.UseCase;
using coursework.EntityFramework.Model;

namespace coursework.EntityFramework.Mapper
{
    public class TbProductCompositionMapper(GetProductByIdUseCase getProductByIdUseCase, GetIngredientByIdUseCase getIngredientByIdUseCase)
    {
        public async Task<ProdComposition> MapFromModel(TbProductComposition composition)
        {
            return new ProdComposition(await getProductByIdUseCase.Execute(composition.CompositionProductId), await getIngredientByIdUseCase.Execute(composition.CompositionIngredientId), composition.CompositionIngredientCount);
        }
    }
}
