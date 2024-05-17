using coursework.Domain.Model;

namespace coursework.Data.Repository
{
    public interface TypeDbRepository
    {
        Task<IngredType> GetTypeById(int id);
        IAsyncEnumerable<IngredType> GetTypes();
    }
}
