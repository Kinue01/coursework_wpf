namespace coursework.EntityFramework.Model;

public partial class GetIngredsExpense
{
    public int? IngredientId { get; set; }

    public int? ProductId { get; set; }

    public int? SupplierId { get; set; }

    public DateOnly? SupplyDate { get; set; }

    public int? Count { get; set; }
}
