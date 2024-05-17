namespace coursework.EntityFramework.Model;

public partial class GetCartOrder
{
    public int? CartOrderId { get; set; }

    public int? ProductId { get; set; }

    public int? CartProdCount { get; set; }

    public int? CartProdEmployeeId { get; set; }

    public DateOnly? CartProdProduceDate { get; set; }
}
