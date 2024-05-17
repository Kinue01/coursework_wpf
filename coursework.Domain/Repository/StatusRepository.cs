using coursework.Domain.Model;

namespace coursework.Domain.Repository
{
    public interface StatusRepository
    {
        IAsyncEnumerable<Status> GetStatuses();
        Task<Status> GetStatusById(int id);
    }
}
