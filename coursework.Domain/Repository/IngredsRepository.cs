using coursework.Domain.Model;

namespace coursework.Domain.Repository
{
    public interface IngredsRepository
    {
        IAsyncEnumerable<Ingredient> GetIngreds();
        Task<Ingredient> GetIngredientById(int id);
        IAsyncEnumerable<Ingredient> FilterByName(string name);
        IAsyncEnumerable<Ingredient> FilterByTypeId(int id);
        Task<bool> AddIngred(Ingredient ingredient);
        Task<bool> UpdateIngred(Ingredient ingredient);
        Task<bool> DeleteIngred(int id);
    }
}
