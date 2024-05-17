using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class GetUserByLoginUseCase(UserRepository repository)
    {
        public async Task<User> Execute(string login)
        {
            return await repository.GetUser(login);
        }
    }
}
