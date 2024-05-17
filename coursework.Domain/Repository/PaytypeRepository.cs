using coursework.Domain.Model;

namespace coursework.Domain.Repository
{
    public interface PaytypeRepository
    {
        IAsyncEnumerable<Paytype> GetPaytypes();
    }
}
