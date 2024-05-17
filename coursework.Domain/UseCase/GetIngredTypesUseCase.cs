using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class GetIngredTypesUseCase(TypeRepository repository)
    {
        public IAsyncEnumerable<IngredType> Execute()
        {
            return repository.GetTypes();
        }
    }
}
