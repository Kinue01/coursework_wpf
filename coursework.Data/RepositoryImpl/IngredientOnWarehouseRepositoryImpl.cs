using coursework.Data.Repository;
using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Data.RepositoryImpl
{
    public class IngredientOnWarehouseRepositoryImpl(IngredientOnWarehouseDbRepository repository) : IngredientOnWarehouseRepository
    {
        public async Task<bool> AddIngredOnWarehouse(IngredientOnWarehouse ingred)
        {
            return await repository.AddIngredOnWarehouse(ingred);
        }

        public IAsyncEnumerable<IngredientOnWarehouse> GetIngredientOnWarehouse()
        {
            return repository.GetIngredientOnWarehouse();
        }
    }
}
