using coursework.Data.Repository;
using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Data.RepositoryImpl
{
    public class PaytypeRepositoryImpl(PaytypeDbRepository repository) : PaytypeRepository
    {
        public IAsyncEnumerable<Paytype> GetPaytypes()
        {
            return repository.GetPaytypes();
        }
    }
}
