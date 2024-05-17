using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class GetClientsUseCase(ClientRepository repository)
    {
        public IAsyncEnumerable<Client> Execute()
        {
            return repository.GetClients();
        }
    }
}
