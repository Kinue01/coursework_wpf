namespace coursework.EntityFramework.Model;

public partial class TbTimesheet
{
    public int TimesheetEmployeeId { get; set; }

    public DateTime TimesheetStartDate { get; set; }

    public DateTime TimesheetEndDate { get; set; }

    public virtual TbEmployee TimesheetEmployee { get; set; } = null!;
}
