using coursework.Data.Repository;
using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Data.RepositoryImpl
{
    public class StatusRepositoryImpl(StatusDbRepository repository) : StatusRepository
    {
        public async Task<Status> GetStatusById(int id)
        {
            return await repository.GetStatusById(id);
        }

        public IAsyncEnumerable<Status> GetStatuses()
        {
            return repository.GetStatuses();
        }
    }
}
