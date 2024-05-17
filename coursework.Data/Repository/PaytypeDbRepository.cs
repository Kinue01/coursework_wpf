using coursework.Domain.Model;

namespace coursework.Data.Repository
{
    public interface PaytypeDbRepository
    {
        IAsyncEnumerable<Paytype> GetPaytypes();
    }
}
