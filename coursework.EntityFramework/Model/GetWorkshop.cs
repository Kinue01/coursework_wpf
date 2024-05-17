namespace coursework.EntityFramework.Model;

public partial class GetWorkshop
{
    public int? WorkshopId { get; set; }

    public string? WorkshopName { get; set; }

    public int WorkshopChief { get; set; }

    public string? WorkshopChiefPhone { get; set; }

    public int? WorkshopStaffCount { get; set; }
}
