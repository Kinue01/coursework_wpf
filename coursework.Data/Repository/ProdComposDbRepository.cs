using coursework.Domain.Model;

namespace coursework.Data.Repository
{
    public interface ProdComposDbRepository
    {
        IAsyncEnumerable<ProdComposition> GetCompositionById(int id);
        Task<bool> DeleteProdCompos(ProdComposition composition);
        Task<bool> AddProdCompos(ProdComposition composition);
        Task<bool> UpdateProdCompos(ProdComposition composition);
    }
}
