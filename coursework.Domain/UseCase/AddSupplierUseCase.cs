using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class AddSupplierUseCase(SupplierRepository repository)
    {
        public async Task<bool> Execute(Supplier supplier)
        {
            return await repository.AddSupplier(supplier);
        }
    }
}
