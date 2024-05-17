using coursework.Domain.Model;

namespace coursework.Domain.Repository
{
    public interface TypeRepository
    {
        Task<IngredType> GetTypeById(int id);
        IAsyncEnumerable<IngredType> GetTypes();
    }
}
