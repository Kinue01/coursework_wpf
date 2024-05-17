using coursework.Domain.Model;
using coursework.Domain.UseCase;
using coursework.EntityFramework.Model;

namespace coursework.EntityFramework.Mapper
{
    public class GetIngredsOnWarehouseMapper(GetIngredientByIdUseCase getIngredientByIdUseCase, GetSupplierByIdUseCase getSupplierByIdUseCase)
    {
        public async Task<IngredientOnWarehouse> MapFromModel(GetIngredsOnWarehouse ingred)
        {
            return new IngredientOnWarehouse(await getIngredientByIdUseCase.Execute(ingred.IngredientId.GetValueOrDefault()), await getSupplierByIdUseCase.Execute(ingred.SupplierId.GetValueOrDefault()), ingred.SupplyDate.GetValueOrDefault(), ingred.IngredientCount.GetValueOrDefault(), ingred.IngredientUpTo.GetValueOrDefault());
        }
    }
}
