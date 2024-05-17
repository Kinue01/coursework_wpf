using coursework.Domain.Model;

namespace coursework.Domain.Repository
{
    public interface TimesheetRepository
    {
        IAsyncEnumerable<Timesheet> GetTimesheets();
        Task<bool> DeleteTimesheet(Timesheet timesheet);
        IAsyncEnumerable<Timesheet> FilterByEmp(int id);
        Task<bool> AddTimesheet(Timesheet timesheet);
    }
}
