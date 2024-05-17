using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class GetProductByIdUseCase(ProductRepository repository)
    {
        public async Task<Product> Execute(int id)
        {
            return await repository.GetProductById(id);
        }
    }
}
