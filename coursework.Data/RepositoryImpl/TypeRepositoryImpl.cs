using coursework.Data.Repository;
using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Data.RepositoryImpl
{
    public class TypeRepositoryImpl(TypeDbRepository repository) : TypeRepository
    {
        public async Task<IngredType> GetTypeById(int id)
        {
            return await repository.GetTypeById(id);
        }

        public IAsyncEnumerable<IngredType> GetTypes()
        {
            return repository.GetTypes();
        }
    }
}
