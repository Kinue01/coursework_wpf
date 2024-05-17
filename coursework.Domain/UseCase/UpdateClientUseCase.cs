using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class UpdateClientUseCase(ClientRepository repository)
    {
        public async Task<bool> Execute(Client client, User user)
        {
            return await repository.UpdateClient(client, user);
        }
    }
}
