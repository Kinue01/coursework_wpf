using coursework.Data.Repository;
using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Data.RepositoryImpl
{
    public class ClientRepositoryImpl(ClientDbRepository repository) : ClientRepository
    {
        public async Task<bool> AddClient(Client client, User user)
        {
            return await repository.AddClient(client, user);
        }

        public async Task<bool> DeleteClient(Client client)
        {
            return await repository.DeleteClient(client);
        }

        public IAsyncEnumerable<Client> FilterByBirthday(DateOnly date)
        {
            return repository.FilterByBirthday(date);
        }

        public IAsyncEnumerable<Client> FilterByFio(string query)
        {
            return repository.FilterByFio(query);
        }

        public async Task<Client> GetClient(string login)
        {
            return await repository.GetClientAsync(login);
        }

        public async Task<Client> GetClientById(int id)
        {
            return await repository.GetClientById(id);
        }

        public IAsyncEnumerable<Client> GetClients()
        {
            return repository.GetClients();
        }

        public async Task<bool> UpdateClient(Client client, User user)
        {
            return await repository.UpdateClient(client, user);
        }
    }
}
