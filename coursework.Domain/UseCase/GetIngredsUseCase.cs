using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class GetIngredsUseCase(IngredsRepository repository)
    {
        public IAsyncEnumerable<Ingredient> Execute()
        {
            return repository.GetIngreds();
        }
    }
}
