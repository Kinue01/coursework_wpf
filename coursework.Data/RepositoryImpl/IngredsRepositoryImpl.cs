using coursework.Data.Repository;
using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Data.RepositoryImpl
{
    public class IngredsRepositoryImpl(IngredsDbRepository repository) : IngredsRepository
    {
        public async Task<bool> AddIngred(Ingredient ingredient)
        {
            return await repository.AddIngred(ingredient);
        }

        public async Task<bool> DeleteIngred(int id)
        {
            return await repository.DeleteIngred(id);
        }

        public IAsyncEnumerable<Ingredient> FilterByName(string name)
        {
            return repository.FilterByName(name);
        }

        public IAsyncEnumerable<Ingredient> FilterByTypeId(int id)
        {
            return repository.FilterByTypeId(id);
        }

        public async Task<Ingredient> GetIngredientById(int id)
        {
            return await repository.GetIngredientById(id);
        }

        public IAsyncEnumerable<Ingredient> GetIngreds()
        {
            return repository.GetIngreds();
        }

        public async Task<bool> UpdateIngred(Ingredient ingredient)
        {
            return await repository.UpdateIngred(ingredient);
        }
    }
}
