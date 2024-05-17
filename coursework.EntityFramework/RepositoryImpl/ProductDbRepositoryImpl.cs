using coursework.Data.Repository;
using coursework.Domain.Model;
using coursework.EntityFramework.Mapper;
using coursework.EntityFramework.Model;
using Microsoft.EntityFrameworkCore;

namespace coursework.EntityFramework.RepositoryImpl
{
    public class ProductDbRepositoryImpl(IDbContextFactory<KursovaiaContext> context, GetProdMapper getMapper, TbProductMapper tbMapper) : ProductDbRepository
    {
        public async Task<bool> AddProduct(Product product)
        {
            using var db = await context.CreateDbContextAsync();
            try
            {
                await db.Database.ExecuteSqlAsync($"call add_product({product.ProductName}, {product.ProductPrice}, {product.ProductProteins}, {product.ProductFats}, {product.ProductCarbohydrates}, {product.ProductWeight})");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteProduct(Product product)
        {
            using var db = await context.CreateDbContextAsync();
            using var trans = await db.Database.BeginTransactionAsync();
            try
            {
                await db.Database.ExecuteSqlAsync($"call delete_product({product.ProductId})");
                await trans.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                return false;
            }
        }

        public async IAsyncEnumerable<Product> FilterName(string name)
        {
            using var db = await context.CreateDbContextAsync();
            await foreach (var item in db.GetProds.Where(prod => prod.ProductName.ToLower().Contains(name.ToLower())).AsAsyncEnumerable())
                yield return getMapper.MapFromModel(item);
        }

        public async IAsyncEnumerable<Product> FilterPrice(int lower, int upper)
        {
            using var db = await context.CreateDbContextAsync();
            await foreach (var item in db.GetProds.Where(prod => prod.ProductPrice >= lower && prod.ProductPrice <= upper).AsAsyncEnumerable())
                yield return getMapper.MapFromModel(item);
        }

        public async Task<Product> GetProductById(int id)
        {
            using var db = await context.CreateDbContextAsync();
            return tbMapper.MapFromModel(await db.TbProducts.FindAsync(id));
        }

        public async IAsyncEnumerable<Product> GetProducts()
        {
            using var db = await context.CreateDbContextAsync();
            await foreach (var item in db.GetProds.AsAsyncEnumerable())
                yield return getMapper.MapFromModel(item);
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            using var db = await context.CreateDbContextAsync();
            try
            {
                await db.Database.ExecuteSqlAsync($"call update_product({product.ProductId}, {product.ProductName}, {product.ProductPrice}, {product.ProductProteins}, {product.ProductFats}, {product.ProductCarbohydrates}, {product.ProductWeight})");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
