using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class DeleteSupplierUseCase(SupplierRepository repository)
    {
        public async Task<bool> Execute(int id)
        {
            return await repository.DeleteSupplier(id);
        }
    }
}
