using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class GetSupplierByIdUseCase(SupplierRepository repository)
    {
        public async Task<Supplier> Execute(int id)
        {
            return await repository.GetSupplierById(id);
        }
    }
}
