using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class GetPaytypesUseCase(PaytypeRepository repository)
    {
        public IAsyncEnumerable<Paytype> Execute()
        {
            return repository.GetPaytypes();
        }
    }
}
