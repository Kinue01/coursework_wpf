using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class FilterIngredsByNameUseCase(IngredsRepository repository)
    {
        public IAsyncEnumerable<Ingredient> Execute(string name)
        {
            return repository.FilterByName(name);
        }
    }
}
