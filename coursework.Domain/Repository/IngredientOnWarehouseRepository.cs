using coursework.Domain.Model;

namespace coursework.Domain.Repository
{
    public interface IngredientOnWarehouseRepository
    {
        IAsyncEnumerable<IngredientOnWarehouse> GetIngredientOnWarehouse();
        Task<bool> AddIngredOnWarehouse(IngredientOnWarehouse ingred);
    }
}
