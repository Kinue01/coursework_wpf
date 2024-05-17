using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class GetClientByIdUseCase(ClientRepository repository)
    {
        public async Task<Client> Execute(int id)
        {
            return await repository.GetClientById(id);
        }
    }
}
