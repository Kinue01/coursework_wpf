using coursework.Domain.Model;

namespace coursework.Domain.Repository
{
    public interface SupplierRepository
    {
        IAsyncEnumerable<Supplier> GetSuppliers();
        Task<Supplier> GetSupplierById(int id);
        Task<bool> AddSupplier(Supplier supplier);
        Task<bool> DeleteSupplier(int id);
        Task<bool> UpdateSupplier(Supplier supplier);
    }
}
