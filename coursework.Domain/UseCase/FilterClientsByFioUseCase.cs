using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class FilterClientsByFioUseCase(ClientRepository repository)
    {
        public IAsyncEnumerable<Client> Execute(string query)
        {
            return repository.FilterByFio(query);
        }
    }
}
