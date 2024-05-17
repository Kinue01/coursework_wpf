using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class FilterTimesheetByEmployeeUseCase(TimesheetRepository repository)
    {
        public IAsyncEnumerable<Timesheet> Execute(int id)
        {
            return repository.FilterByEmp(id);
        }
    }
}
