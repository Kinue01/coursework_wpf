using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class GetClientUseCase(ClientRepository repository)
    {
        public async Task<Client> Execute(string login)
        {
            return await repository.GetClient(login);
        }
    }
}
