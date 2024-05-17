using coursework.Domain.Model;

namespace coursework.Data.Repository
{
    public interface ProductDbRepository
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
