using coursework.Data.Repository;
using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Data.RepositoryImpl
{
    public class UserRepositoryImpl(UserDbRepository repository) : UserRepository
    {
        public async Task<User> CheckUser(string login, string pass)
        {
            return await repository.CheckUser(login, pass);
        }

        public async Task<User> GetUser(string login)
        {
            return await repository.GetUser(login);
        }
    }
}
