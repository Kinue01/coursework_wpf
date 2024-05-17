using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class GetTimesheetUseCase(TimesheetRepository repository)
    {
        public IAsyncEnumerable<Timesheet> Execute()
        {
            return repository.GetTimesheets();
        }
    }
}
