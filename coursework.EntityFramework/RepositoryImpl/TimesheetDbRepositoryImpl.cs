using coursework.Data.Repository;
using coursework.Domain.Model;
using coursework.EntityFramework.Mapper;
using coursework.EntityFramework.Model;
using Microsoft.EntityFrameworkCore;

namespace coursework.EntityFramework.RepositoryImpl
{
    public class TimesheetDbRepositoryImpl(IDbContextFactory<KursovaiaContext> dbContextFactory, GetTimesheetMapper getMapper) : TimesheetDbRepository
    {
        public async Task<bool> AddTimesheet(Timesheet timesheet)
        {
            using var db = await dbContextFactory.CreateDbContextAsync();
            try
            {
                await db.Database.ExecuteSqlInterpolatedAsync($"call add_timesheet({timesheet.Employee.Id}, {DateOnly.FromDateTime(timesheet.TimesheetStartDate.ToUniversalTime())}, {DateOnly.FromDateTime(timesheet.TimesheetEndDate.ToUniversalTime())})");
                return true;
            }
            catch (Exception ex) 
            {
                return false;
            }
        }

        public async Task<bool> DeleteTimesheet(Timesheet timesheet)
        {
            using var db = await dbContextFactory.CreateDbContextAsync();
            try
            {
                await db.Database.ExecuteSqlInterpolatedAsync($"call delete_timesheet({timesheet.Employee.Id}, {DateOnly.FromDateTime(timesheet.TimesheetStartDate)}, {DateOnly.FromDateTime(timesheet.TimesheetEndDate)})");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async IAsyncEnumerable<Timesheet> FilterByEmp(int id)
        {
            using var db = await dbContextFactory.CreateDbContextAsync();
            await foreach(var item in db.GetTimesheets.Where(time => time.TimesheetEmployeeId == id).AsAsyncEnumerable())
                yield return await getMapper.MapFromModel(item);
        }

        public async IAsyncEnumerable<Timesheet> GetTimesheets()
        {
            using var db = await dbContextFactory.CreateDbContextAsync();
            await foreach(var item in db.GetTimesheets.AsAsyncEnumerable())
                yield return await getMapper.MapFromModel(item);
        }
    }
}
