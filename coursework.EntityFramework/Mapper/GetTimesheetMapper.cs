using coursework.Domain.Model;
using coursework.Domain.UseCase;
using coursework.EntityFramework.Model;

namespace coursework.EntityFramework.Mapper
{
    public class GetTimesheetMapper(GetEmployeeByIdUseCase getEmployeeByIdUseCase)
    {
        public async Task<Timesheet> MapFromModel(GetTimesheet timesheet)
        {
            return new Timesheet(await getEmployeeByIdUseCase.Execute(timesheet.TimesheetEmployeeId), timesheet.TimesheetStartDate.GetValueOrDefault(), timesheet.TimesheetEndDate.GetValueOrDefault());
        }
    }
}
