namespace coursework.EntityFramework.Model;

public partial class TbIngredientsOnWarehouse
{
    public int IngredientId { get; set; }

    public int SupplierId { get; set; }

    public DateOnly SupplyDate { get; set; }

    public int IngredientCount { get; set; }

    public DateOnly IngredientUpTo { get; set; }

    public virtual TbIngredient Ingredient { get; set; } = null!;

    public virtual TbSupplier Supplier { get; set; } = null!;
}
