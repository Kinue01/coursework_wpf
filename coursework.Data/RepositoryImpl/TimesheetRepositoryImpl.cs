using coursework.Data.Repository;
using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Data.RepositoryImpl
{
    public class TimesheetRepositoryImpl(TimesheetDbRepository repository) : TimesheetRepository
    {
        public async Task<bool> AddTimesheet(Timesheet timesheet)
        {
            return await repository.AddTimesheet(timesheet);
        }

        public async Task<bool> DeleteTimesheet(Timesheet timesheet)
        {
            return await repository.DeleteTimesheet(timesheet);
        }

        public IAsyncEnumerable<Timesheet> FilterByEmp(int id)
        {
            return repository.FilterByEmp(id);
        }

        public IAsyncEnumerable<Timesheet> GetTimesheets()
        {
            return repository.GetTimesheets();
        }
    }
}
