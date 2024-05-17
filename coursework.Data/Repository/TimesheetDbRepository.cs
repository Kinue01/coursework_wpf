using coursework.Domain.Model;

namespace coursework.Data.Repository
{
    public interface TimesheetDbRepository
    {
        IAsyncEnumerable<Timesheet> GetTimesheets();
        Task<bool> DeleteTimesheet(Timesheet timesheet);
        IAsyncEnumerable<Timesheet> FilterByEmp(int id);
        Task<bool> AddTimesheet(Timesheet timesheet);
    }
}
