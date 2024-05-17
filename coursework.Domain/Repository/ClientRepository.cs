using coursework.Domain.Model;

namespace coursework.Domain.Repository
{
    public interface ClientRepository
    {
        Task<Client> GetClient(string login);
        Task<bool> AddClient(Client client, User user);
        IAsyncEnumerable<Client> GetClients();
        Task<Client> GetClientById(int id);
        IAsyncEnumerable<Client> FilterByFio(string query);
        IAsyncEnumerable<Client> FilterByBirthday(DateOnly date);
        Task<bool> DeleteClient(Client client);
        Task<bool> UpdateClient(Client client, User user);
    }
}
