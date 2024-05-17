namespace coursework.EntityFramework.Model;

public partial class GetIngredsOnWarehouse
{
    public int? IngredientId { get; set; }

    public int? SupplierId { get; set; }

    public DateOnly? SupplyDate { get; set; }

    public int? IngredientCount { get; set; }

    public DateOnly? IngredientUpTo { get; set; }
}
