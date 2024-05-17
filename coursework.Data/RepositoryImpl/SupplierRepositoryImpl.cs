using coursework.Data.Repository;
using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Data.RepositoryImpl
{
    public class SupplierRepositoryImpl(SupplierDbRepository repository) : SupplierRepository
    {
        public async Task<bool> AddSupplier(Supplier supplier)
        {
            return await repository.AddSupplier(supplier);
        }

        public async Task<bool> DeleteSupplier(int id)
        {
            return await repository.DeleteSupplier(id);
        }

        public async Task<Supplier> GetSupplierById(int id)
        {
            return await repository.GetSupplierById(id);
        }

        public IAsyncEnumerable<Supplier> GetSuppliers()
        {
            return repository.GetSuppliers();
        }

        public async Task<bool> UpdateSupplier(Supplier supplier)
        {
            return await repository.UpdateSupplier(supplier);
        }
    }
}
