using coursework.Domain.Model;

namespace coursework.Domain.Repository
{
    public interface WorkshopRepository
    {
        IAsyncEnumerable<Workshop> GetWorkshops();
        Task<Workshop> GetWorkshopById(int id);
        Task<bool> DeleteWorkshop(Workshop workshop);
        Task<bool> AddWorkshop(Workshop workshop);
        Task<bool> UpdateWorkshop(Workshop workshop);
    }
}
