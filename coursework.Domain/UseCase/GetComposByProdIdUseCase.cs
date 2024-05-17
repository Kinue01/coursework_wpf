using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class GetComposByProdIdUseCase(ProdComposRepository repository)
    {
        public IAsyncEnumerable<ProdComposition> Execute(int id)
        {
            return repository.GetCompositionById(id);
        }
    }
}
