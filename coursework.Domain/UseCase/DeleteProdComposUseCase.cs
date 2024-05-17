using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class DeleteProdComposUseCase(ProdComposRepository repository)
    {
        public async Task<bool> Execute(ProdComposition composition)
        {
            return await repository.DeleteProdCompos(composition);
        }
    }
}
