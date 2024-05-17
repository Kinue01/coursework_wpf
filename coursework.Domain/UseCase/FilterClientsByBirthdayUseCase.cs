using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class FilterClientsByBirthdayUseCase(ClientRepository repository)
    {
        public IAsyncEnumerable<Client> Execute(DateOnly date)
        {
            return repository.FilterByBirthday(date);
        }
    }
}
