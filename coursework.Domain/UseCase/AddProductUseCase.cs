using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class AddProductUseCase(ProductRepository repository)
    {
        public async Task<bool> Execute(Product product)
        {
            return await repository.AddProduct(product);
        }
    }
}
