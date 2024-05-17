using coursework.Domain.Model;

namespace coursework.Domain.Repository
{
    public interface ProductRepository
    {
        IAsyncEnumerable<Product> GetProducts();
        Task<Product> GetProductById(int id);
        IAsyncEnumerable<Product> FilterName(string name);
        IAsyncEnumerable<Product> FilterPrice(int lower, int upper);
        Task<bool> AddProduct(Product product);
        Task<bool> DeleteProduct(Product product);
        Task<bool> UpdateProduct(Product product);
    }
}
