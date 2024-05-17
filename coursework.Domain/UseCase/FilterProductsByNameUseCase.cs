using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class FilterProductsByNameUseCase(ProductRepository repository)
    {
        public IAsyncEnumerable<Product> Execute(string name)
        {
            return repository.FilterName(name);
        }
    }
}
