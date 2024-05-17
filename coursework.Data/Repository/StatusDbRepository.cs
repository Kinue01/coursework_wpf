using coursework.Domain.Model;

namespace coursework.Data.Repository
{
    public interface StatusDbRepository
    {
        IAsyncEnumerable<Status> GetStatuses();
        Task<Status> GetStatusById(int id);
    }
}
