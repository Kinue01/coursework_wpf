using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class GetSuppliersUseCase(SupplierRepository repository)
    {
        public IAsyncEnumerable<Supplier> Execute()
        {
            return repository.GetSuppliers();
        }
    }
}
