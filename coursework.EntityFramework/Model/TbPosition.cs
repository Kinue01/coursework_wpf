namespace coursework.EntityFramework.Model;

public partial class TbPosition
{
    public int PositionId { get; set; }

    public string PositionTitle { get; set; } = null!;

    public int PositionBasePay { get; set; }

    public virtual ICollection<TbEmployee> TbEmployees { get; set; } = new List<TbEmployee>();
}
