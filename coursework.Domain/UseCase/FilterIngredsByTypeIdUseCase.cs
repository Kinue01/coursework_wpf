using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class FilterIngredsByTypeIdUseCase(IngredsRepository repository)
    {
        public IAsyncEnumerable<Ingredient> Execute(int id)
        {
            return repository.FilterByTypeId(id);
        }
    }
}
