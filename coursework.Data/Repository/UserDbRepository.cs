using coursework.Domain.Model;

namespace coursework.Data.Repository
{
    public interface UserDbRepository
    {
        Task<User> CheckUser(string login, string pass);
        Task<User> GetUser(string login);
    }
}
