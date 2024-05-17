using coursework.Data.Repository;
using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Data.RepositoryImpl
{
    public class WorkhopRepositoryImpl(WorkshopDbRepository repository) : WorkshopRepository
    {
        public async Task<bool> AddWorkshop(Workshop workshop)
        {
            return await repository.AddWorkshop(workshop);
        }

        public async Task<bool> DeleteWorkshop(Workshop workshop)
        {
            return await repository.DeleteWorkshop(workshop);
        }

        public async Task<Workshop> GetWorkshopById(int id)
        {
            return await repository.GetWorkshopById(id);
        }

        public IAsyncEnumerable<Workshop> GetWorkshops()
        {
            return repository.GetWorkshops();
        }

        public async Task<bool> UpdateWorkshop(Workshop workshop)
        {
            return await repository.UpdateWorkshop(workshop);
        }
    }
}
