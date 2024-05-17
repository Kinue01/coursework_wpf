using coursework.Domain.Model;

namespace coursework.Domain.Repository
{
    public interface UserRepository
    {
        Task<User> CheckUser(string login, string pass);
        Task<User> GetUser(string login);
    }
}
