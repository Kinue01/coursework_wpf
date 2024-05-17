using coursework.Domain.Model;

namespace coursework.Domain.Repository
{
    public interface ProdComposRepository
    {
        IAsyncEnumerable<ProdComposition> GetCompositionById(int id);
        Task<bool> DeleteProdCompos(ProdComposition composition);
        Task<bool> AddProdCompos(ProdComposition composition);
        Task<bool> UpdateProdCompos(ProdComposition composition);
    }
}
