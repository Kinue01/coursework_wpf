namespace coursework.EntityFramework.Model;

public partial class TbIngredientsExpense
{
    public int IngredientId { get; set; }

    public int ProductId { get; set; }

    public int SupplierId { get; set; }

    public DateOnly SupplyDate { get; set; }

    public virtual TbIngredientsOnWarehouse TbIngredientsOnWarehouse { get; set; } = null!;

    public virtual TbProductComposition TbProductComposition { get; set; } = null!;
}
