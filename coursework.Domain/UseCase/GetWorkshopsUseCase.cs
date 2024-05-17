using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class GetWorkshopsUseCase(WorkshopRepository repository)
    {
        public IAsyncEnumerable<Workshop> Execute()
        {
            return repository.GetWorkshops();
        }
    }
}
