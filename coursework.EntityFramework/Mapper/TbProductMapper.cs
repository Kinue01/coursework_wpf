using coursework.Domain.Model;
using coursework.EntityFramework.Model;

namespace coursework.EntityFramework.Mapper
{
    public class TbProductMapper
    {
        public Product MapFromModel(TbProduct product)
        {
            return new Product(product.ProductId, product.ProductName, product.ProductPrice, product.ProductProteins, product.ProductFats, product.ProductCarbohydrates, product.ProductWeight, product.ProductImage);
        }
    }
}
