using coursework.Data.Repository;
using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Data.RepositoryImpl
{
    public class ProductRepositoryImpl(ProductDbRepository repository) : ProductRepository
    {
        public async Task<bool> AddProduct(Product product)
        {
            return await repository.AddProduct(product);
        }

        public async Task<bool> DeleteProduct(Product product)
        {
            return await repository.DeleteProduct(product);
        }

        public IAsyncEnumerable<Product> FilterName(string name)
        {
            return repository.FilterName(name);
        }

        public IAsyncEnumerable<Product> FilterPrice(int lower, int upper)
        {
            return repository.FilterPrice(lower, upper);
        }

        public async Task<Product> GetProductById(int id)
        {
            return await repository.GetProductById(id);
        }

        public IAsyncEnumerable<Product> GetProducts()
        {
            return repository.GetProducts();
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            return await repository.UpdateProduct(product);
        }
    }
}
