using coursework.Domain.Model;

namespace coursework.Data.Repository
{
    public interface ClientDbRepository
    {
        Task<Client> GetClientAsync(string login);
        Task<bool> AddClient(Client client, User user);
        IAsyncEnumerable<Client> GetClients();
        Task<Client> GetClientById(int id);
        IAsyncEnumerable<Client> FilterByFio(string query);
        IAsyncEnumerable<Client> FilterByBirthday(DateOnly date);
        Task<bool> DeleteClient(Client client);
        Task<bool> UpdateClient(Client client, User user);
    }
}
