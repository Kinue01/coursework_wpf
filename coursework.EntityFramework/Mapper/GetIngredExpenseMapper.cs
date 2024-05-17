using coursework.Domain.Model;
using coursework.Domain.UseCase;
using coursework.EntityFramework.Model;

namespace coursework.EntityFramework.Mapper
{
    public class GetIngredExpenseMapper(GetIngredientByIdUseCase getIngredientByIdUseCase, GetSupplierByIdUseCase getSupplierByIdUseCase, GetProductByIdUseCase getProductByIdUseCase)
    {
        public async Task<IngredientExpense> MapFromModel(GetIngredsExpense ingred)
        {
            return new IngredientExpense(await getIngredientByIdUseCase.Execute(ingred.IngredientId.GetValueOrDefault()), await getProductByIdUseCase.Execute(ingred.ProductId.GetValueOrDefault()), await getSupplierByIdUseCase.Execute(ingred.SupplierId.GetValueOrDefault()), ingred.SupplyDate.GetValueOrDefault(), ingred.Count.GetValueOrDefault());
        }
    }
}
