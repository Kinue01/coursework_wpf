using coursework.Data.Repository;
using coursework.Domain.Model;
using coursework.EntityFramework.Mapper;
using coursework.EntityFramework.Model;
using Microsoft.EntityFrameworkCore;

namespace coursework.EntityFramework.RepositoryImpl
{
    public class IngredientOnWarehouseDbRepositoryImpl(IDbContextFactory<KursovaiaContext> contextFactory, GetIngredsOnWarehouseMapper getMapper) : IngredientOnWarehouseDbRepository
    {
        public async Task<bool> AddIngredOnWarehouse(IngredientOnWarehouse ingred)
        {
            using var db = await contextFactory.CreateDbContextAsync();
            try
            {
                await db.Database.ExecuteSqlInterpolatedAsync($"call add_ingred_on_warehouse({ingred.Ingredient.Id}, {ingred.Supplier.SupplierId}, {ingred.SupplyDate}, {ingred.IngredientCount}, {ingred.IngredientUpTo})");
                return true;
            }
            catch (Exception ex) 
            {
                return false;
            }
        }

        public async IAsyncEnumerable<IngredientOnWarehouse> GetIngredientOnWarehouse()
        {
            using var db = await contextFactory.CreateDbContextAsync();
            await foreach (var item in db.GetIngredsOnWarehouses.AsAsyncEnumerable())
                yield return await getMapper.MapFromModel(item);
        }
    }
}
