namespace coursework.EntityFramework.Model;

public partial class TbWorkshop
{
    public int WorkshopId { get; set; }

    public string WorkshopName { get; set; } = null!;

    public string WorkshopChiefPhone { get; set; } = null!;

    public int? WorkshopStaffCount { get; set; }

    public int WorkshopChief {  get; set; } 

    public virtual TbEmployee? WorkshopEmployeeChief { get; set; }

    public virtual ICollection<TbEmployee> TbEmployees { get; set; } = new List<TbEmployee>();
}
