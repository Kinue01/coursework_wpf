using coursework.Data.Repository;
using coursework.Domain.Model;
using coursework.EntityFramework.Mapper;
using coursework.EntityFramework.Model;
using Microsoft.EntityFrameworkCore;

namespace coursework.EntityFramework.RepositoryImpl
{
    public class ProdComposDbRepositoryImpl(IDbContextFactory<KursovaiaContext> contextFactory, TbProductCompositionMapper tbProductCompositionMapper) : ProdComposDbRepository
    {
        public async Task<bool> AddProdCompos(ProdComposition composition)
        {
            using var db = await contextFactory.CreateDbContextAsync();
            try
            {
                await db.Database.ExecuteSqlAsync($"call add_prod_compos({composition.CompositionProduct.ProductId}, {composition.CompositionIngredient.Id}, {composition.CompositionIngredientCount})");
                return true;
            }
            catch (Exception ex) 
            {
                return false;
            }
        }

        public async Task<bool> DeleteProdCompos(ProdComposition composition)
        {
            using var db = await contextFactory.CreateDbContextAsync();
            try
            {
                await db.Database.ExecuteSqlAsync($"call delete_prod_compos({composition.CompositionProduct.ProductId}, {composition.CompositionIngredient.Id})");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async IAsyncEnumerable<ProdComposition> GetCompositionById(int id)
        {
            using var db = await contextFactory.CreateDbContextAsync();
            await foreach(var item in db.TbProductCompositions.Where(comp => comp.CompositionProductId == id).AsAsyncEnumerable())
                yield return await tbProductCompositionMapper.MapFromModel(item);
        }

        public async Task<bool> UpdateProdCompos(ProdComposition composition)
        {
            using var db = await contextFactory.CreateDbContextAsync();
            try
            {
                await db.Database.ExecuteSqlAsync($"call update_prod_compos({composition.CompositionProduct.ProductId}, {composition.CompositionIngredient.Id}, {composition.CompositionIngredientCount})");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
