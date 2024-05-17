using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class GetOrderStatusesUseCase(StatusRepository repository)
    {
        public IAsyncEnumerable<Status> Execute()
        {
            return repository.GetStatuses();
        }
    }
}
