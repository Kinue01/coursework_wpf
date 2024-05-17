using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class AddIngredOnWarehouseUseCase(IngredientOnWarehouseRepository repository)
    {
        public async Task<bool> Execute(IngredientOnWarehouse ingredient)
        {
            return await repository.AddIngredOnWarehouse(ingredient);
        }
    }
}
