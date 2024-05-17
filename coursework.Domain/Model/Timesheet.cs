namespace coursework.Domain.Model
{
    public class Timesheet
    {
        public Employee Employee { get; set; }

        public DateTime TimesheetStartDate { get; set; }

        public DateTime TimesheetEndDate { get; set; }

        public Timesheet(Employee employee, DateTime timesheetStartDate, DateTime timesheetEndDate)
        {
            Employee = employee;
            TimesheetStartDate = timesheetStartDate;
            TimesheetEndDate = timesheetEndDate;
        }
    }
}
