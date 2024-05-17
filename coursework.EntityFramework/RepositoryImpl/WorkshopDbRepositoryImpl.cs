using coursework.Data.Repository;
using coursework.Domain.Model;
using coursework.EntityFramework.Mapper;
using coursework.EntityFramework.Model;
using Microsoft.EntityFrameworkCore;

namespace coursework.EntityFramework.RepositoryImpl
{
    public class WorkshopDbRepositoryImpl(IDbContextFactory<KursovaiaContext> contextFactory, GetWorkshopsMapper getMapper, TbWorkshopMapper tbMapper) : WorkshopDbRepository
    {
        public async Task<bool> AddWorkshop(Workshop workshop)
        {
            using var db = await contextFactory.CreateDbContextAsync();
            try
            {
                await db.Database.ExecuteSqlInterpolatedAsync($"call add_workshop({workshop.WorkshopName}, {workshop.WorkshopChief.Id}, {workshop.WorkshopChiefPhone}, {workshop.WorkshopStaffCount})");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteWorkshop(Workshop workshop)
        {
            using var db = await contextFactory.CreateDbContextAsync();
            try
            {
                await db.Database.ExecuteSqlInterpolatedAsync($"call delete_workshop({workshop.WorkshopId})");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Workshop> GetWorkshopById(int id)
        {
            using var db = await contextFactory.CreateDbContextAsync();
            return await tbMapper.MapFromModel(await db.TbWorkshops.FindAsync(id));
        }

        public async IAsyncEnumerable<Workshop> GetWorkshops()
        {
            using var db = await contextFactory.CreateDbContextAsync();
            await foreach (var item in db.GetWorkshops.AsAsyncEnumerable())
                yield return await getMapper.MapFromModel(item);
        }

        public async Task<bool> UpdateWorkshop(Workshop workshop)
        {
            using var db = await contextFactory.CreateDbContextAsync();
            try
            {
                await db.Database.ExecuteSqlInterpolatedAsync($"call update_workshop({workshop.WorkshopId}, {workshop.WorkshopName}, {workshop.WorkshopChief.Id}, {workshop.WorkshopChiefPhone}, {workshop.WorkshopStaffCount})");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}