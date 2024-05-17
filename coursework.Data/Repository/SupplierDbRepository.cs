using coursework.Domain.Model;

namespace coursework.Data.Repository
{
    public interface SupplierDbRepository
    {
        IAsyncEnumerable<Supplier> GetSuppliers();
        Task<Supplier> GetSupplierById(int id);
        Task<bool> AddSupplier(Supplier supplier);
        Task<bool> DeleteSupplier(int id);
        Task<bool> UpdateSupplier(Supplier supplier);
    }
}
