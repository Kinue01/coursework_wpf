using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class GetProductsUseCase(ProductRepository repository)
    {
        public IAsyncEnumerable<Product> Execute()
        {
            return repository.GetProducts();    
        }
    }
}
