using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class AddTimesheetUseCase(TimesheetRepository repository)
    {
        public async Task<bool> Execute(Timesheet timesheet)
        {
            return await repository.AddTimesheet(timesheet);
        }
    }
}
