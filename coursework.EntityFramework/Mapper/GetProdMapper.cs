using coursework.Domain.Model;
using coursework.EntityFramework.Model;

namespace coursework.EntityFramework.Mapper
{
    public class GetProdMapper
    {
        public Product MapFromModel(GetProd prod)
        {
            return new Product(prod.ProductId.GetValueOrDefault(), prod.ProductName, prod.ProductPrice.GetValueOrDefault(), prod.ProductProteins.GetValueOrDefault(), prod.ProductFats.GetValueOrDefault(), prod.ProductCarbohydrates.GetValueOrDefault(), prod.ProductWeight.GetValueOrDefault(), prod.ProductImage);
        }
    }
}
