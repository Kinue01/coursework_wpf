using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class GetUserUseCase(UserRepository repository)
    {
        public async Task<User> Execute(string login, string pass)
        {
            return await repository.CheckUser(login, pass);
        }
    }
}
