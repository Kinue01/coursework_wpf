using coursework.Data.Repository;
using coursework.Domain.Model;
using coursework.EntityFramework.Mapper;
using coursework.EntityFramework.Model;
using Microsoft.EntityFrameworkCore;

namespace coursework.EntityFramework.RepositoryImpl
{
    public class SupplierDbRepositoryImpl(IDbContextFactory<KursovaiaContext> dbContext, GetSuppliersMapper getMapper, TbSupplierMapper tbMapper) : SupplierDbRepository
    {
        public async Task<bool> AddSupplier(Supplier supplier)
        {
            using var db = await dbContext.CreateDbContextAsync();
            try
            {
                await db.Database.ExecuteSqlAsync($"call add_supplier({supplier.SupplierName}, {supplier.SupplierAddress}, {supplier.SupplierPhone}, {supplier.SupplierEmail}, {supplier.SupplierContact})");
                return true;
            }
            catch (Exception ex) 
            {
                return false;
            }
        }

        public async Task<bool> DeleteSupplier(int id)
        {
            using var db = await dbContext.CreateDbContextAsync();
            try
            {
                await db.Database.ExecuteSqlAsync($"call delete_supplier({id})");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Supplier> GetSupplierById(int id)
        {
            using var db = await dbContext.CreateDbContextAsync();
            return tbMapper.MapFromModel(await db.TbSuppliers.FindAsync(id));
        }

        public async IAsyncEnumerable<Supplier> GetSuppliers()
        {
            using var db = await dbContext.CreateDbContextAsync();
            await foreach (var item in db.GetSuppliers.AsAsyncEnumerable())
                yield return getMapper.MapFromModel(item);
        }

        public async Task<bool> UpdateSupplier(Supplier supplier)
        {
            using var db = await dbContext.CreateDbContextAsync();
            try
            {
                await db.Database.ExecuteSqlAsync($"call update_supplier({supplier.SupplierId}, {supplier.SupplierName}, {supplier.SupplierAddress}, {supplier.SupplierPhone}, {supplier.SupplierEmail}, {supplier.SupplierContact})");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
