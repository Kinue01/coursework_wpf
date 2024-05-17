namespace coursework.Domain.Model
{
    public class ProdComposition
    {
        public Product CompositionProduct { get; set; }

        public Ingredient CompositionIngredient { get; set; }

        public int CompositionIngredientCount { get; set; }

        public ProdComposition(Product product, Ingredient ingredient, int count)
        {
            CompositionIngredient = ingredient;
            CompositionIngredientCount = count;
            CompositionProduct = product;
        }
    }
}
