namespace coursework.Domain.Model
{
    public class IngredientExpense
    {
        public Ingredient Ingredient { get; set; }

        public Product Product { get; set; }

        public Supplier Supplier { get; set; }

        public DateOnly SupplyDate { get; set; }

        public int Count { get; set; }

        public IngredientExpense(Ingredient ingredient, Product product, Supplier supplier, DateOnly supplyDate, int count)
        {
            Ingredient = ingredient;
            Product = product;
            Supplier = supplier;
            SupplyDate = supplyDate;
            Count = count;
        }
    }
}
