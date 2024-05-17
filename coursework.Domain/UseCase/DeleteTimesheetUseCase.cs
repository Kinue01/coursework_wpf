using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class DeleteTimesheetUseCase(TimesheetRepository repository)
    {
        public async Task<bool> Execute(Timesheet timesheet)
        {
            return await repository.DeleteTimesheet(timesheet);
        }
    }
}
