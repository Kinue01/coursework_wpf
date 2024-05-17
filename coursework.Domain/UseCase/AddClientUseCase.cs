using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class AddClientUseCase(ClientRepository repository)
    {
        public async Task<bool> Execute(Client client, User user)
        {
            return await repository.AddClient(client, user);
        }
    }
}
