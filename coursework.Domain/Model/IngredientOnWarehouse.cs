namespace coursework.Domain.Model
{
    public class IngredientOnWarehouse
    {
        public Ingredient Ingredient { get; set; }

        public Supplier Supplier { get; set; }

        public DateOnly SupplyDate { get; set; }

        public int IngredientCount { get; set; }

        public DateOnly IngredientUpTo { get; set; }


        public IngredientOnWarehouse(Ingredient ingredient, Supplier supplier, DateOnly supplyDate, int ingredientCount, DateOnly ingredientUpTo)
        {
            Ingredient = ingredient;
            Supplier = supplier;
            SupplyDate = supplyDate;
            IngredientCount = ingredientCount;
            IngredientUpTo = ingredientUpTo;
        }
    }
}
