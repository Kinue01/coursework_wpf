using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class AddProdComposUseCase(ProdComposRepository repository)
    {
        public async Task<bool> Execute(ProdComposition composition)
        {
            return await repository.AddProdCompos(composition);
        }
    }
}
