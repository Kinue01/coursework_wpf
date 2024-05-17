namespace coursework.EntityFramework.Model;

public partial class GetTimesheet
{
    public int TimesheetEmployeeId { get; set; }

    public DateTime? TimesheetStartDate { get; set; }

    public DateTime? TimesheetEndDate { get; set; }
}
