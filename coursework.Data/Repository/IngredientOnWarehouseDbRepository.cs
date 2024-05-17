using coursework.Domain.Model;

namespace coursework.Data.Repository
{
    public interface IngredientOnWarehouseDbRepository
    {
        IAsyncEnumerable<IngredientOnWarehouse> GetIngredientOnWarehouse();
        Task<bool> AddIngredOnWarehouse(IngredientOnWarehouse ingred);
    }
}
