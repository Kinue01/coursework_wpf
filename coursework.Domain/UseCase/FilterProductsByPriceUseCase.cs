using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class FilterProductsByPriceUseCase(ProductRepository repository)
    {
        public IAsyncEnumerable<Product> Execute(int lower, int upper)
        {
            return repository.FilterPrice(lower, upper);
        }
    }
}
