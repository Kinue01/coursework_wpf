using coursework.Data.Repository;
using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Data.RepositoryImpl
{
    public class ProdComposRepositoryImpl(ProdComposDbRepository repository) : ProdComposRepository
    {
        public async Task<bool> AddProdCompos(ProdComposition composition)
        {
            return await repository.AddProdCompos(composition);
        }

        public async Task<bool> DeleteProdCompos(ProdComposition composition)
        {
            return await repository.DeleteProdCompos(composition);
        }

        public IAsyncEnumerable<ProdComposition> GetCompositionById(int id)
        {
            return repository.GetCompositionById(id);
        }

        public async Task<bool> UpdateProdCompos(ProdComposition composition)
        {
            return await repository.UpdateProdCompos(composition);
        }
    }
}
