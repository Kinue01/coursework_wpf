using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class DeleteClientUseCase(ClientRepository repository)
    {
        public async Task<bool> Execute(Client client)
        {
            return await repository.DeleteClient(client);
        }
    }
}
