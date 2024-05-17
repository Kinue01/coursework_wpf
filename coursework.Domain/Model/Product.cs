using System.Windows.Media.Imaging;

namespace coursework.Domain.Model
{
    public class Product
    {
        public int ProductId { get; set; }

        public string? ProductName { get; set; }

        public int ProductPrice { get; set; }

        public int ProductProteins { get; set; }

        public int ProductFats { get; set; }

        public int ProductCarbohydrates { get; set; }

        public int ProductWeight { get; set; }

        public BitmapImage ProductImage { get; set; }
        
        public string imagestr { get; set; }

        public Product(int productId, string? productName, int productPrice, int productProteins, int productFats, int productCarbohydrates, int productWeight, string productImage)
        {
            ProductId = productId;
            ProductName = productName;
            ProductPrice = productPrice;
            ProductProteins = productProteins;
            ProductFats = productFats;
            ProductCarbohydrates = productCarbohydrates;
            ProductWeight = productWeight;
            imagestr = productImage;

            ProductImage = new();
            ProductImage.BeginInit();
            ProductImage.UriSource = new Uri("..\\..\\..\\Image\\" + productImage, UriKind.Relative);
            ProductImage.CacheOption = BitmapCacheOption.OnLoad;
            ProductImage.EndInit();
        }
    }
}
