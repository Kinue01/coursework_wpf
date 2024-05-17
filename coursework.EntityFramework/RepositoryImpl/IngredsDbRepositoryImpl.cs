using coursework.Data.Repository;
using coursework.Domain.Model;
using coursework.EntityFramework.Mapper;
using coursework.EntityFramework.Model;
using Microsoft.EntityFrameworkCore;

namespace coursework.EntityFramework.RepositoryImpl
{
    public class IngredsDbRepositoryImpl(IDbContextFactory<KursovaiaContext> dbContextFactory, GetIngredsMapper getMapper, TbIngredientMapper tbMapper) : IngredsDbRepository
    {
        public async Task<bool> AddIngred(Ingredient ingredient)
        {
            using var db = await dbContextFactory.CreateDbContextAsync();
            try
            {
                await db.Database.ExecuteSqlAsync($"call add_ingredient( {ingredient.Name} , {ingredient.Weight}, {ingredient.Type.TypeId})");
                return true;
            }
            catch (Exception ex) 
            {
                return false;
            }
        }

        public async Task<bool> DeleteIngred(int id)
        {
            using var db = await dbContextFactory.CreateDbContextAsync();
            try
            {
                await db.Database.ExecuteSqlAsync($"call delete_ingredient({id})");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async IAsyncEnumerable<Ingredient> FilterByName(string name)
        {
            using var db = await dbContextFactory.CreateDbContextAsync();
            await foreach (var item in db.GetIngreds.Where(ing => ing.IngredientName.ToLower().Contains(name)).AsAsyncEnumerable())
                yield return await getMapper.MapFromModel(item);
        }

        public async IAsyncEnumerable<Ingredient> FilterByTypeId(int id)
        {
            using var db = await dbContextFactory.CreateDbContextAsync();
            await foreach (var item in db.GetIngreds.Where(ing => ing.TypeId == id).AsAsyncEnumerable())
                yield return await getMapper.MapFromModel(item);
        }

        public async Task<Ingredient> GetIngredientById(int id)
        {
            using var db = await dbContextFactory.CreateDbContextAsync();
            return await tbMapper.MapFromModel(await db.TbIngredients.FindAsync(id));
        }

        public async IAsyncEnumerable<Ingredient> GetIngreds()
        {
            using var db = await dbContextFactory.CreateDbContextAsync();
            await foreach (var item in db.GetIngreds.AsAsyncEnumerable())
                yield return await getMapper.MapFromModel(item);
        }

        public async Task<bool> UpdateIngred(Ingredient ingredient)
        {
            using var db = await dbContextFactory.CreateDbContextAsync();
            try
            {
                await db.Database.ExecuteSqlAsync($"call update_ingredient({ingredient.Id}, {ingredient.Name}, {ingredient.Weight}, {ingredient.Type.TypeId})");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}