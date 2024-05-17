using coursework.Data.Repository;
using coursework.Domain.Model;
using coursework.EntityFramework.Mapper;
using coursework.EntityFramework.Model;
using Microsoft.EntityFrameworkCore;

namespace coursework.EntityFramework.RepositoryImpl
{
    public class StatusDbRepositoryImpl(IDbContextFactory<KursovaiaContext> kursovaiaContext, GetOrderStatusMapper getmapper, TbOrderStatusMapper tbmapper) : StatusDbRepository
    {
        public async Task<Status> GetStatusById(int id)
        {
            using var db = await kursovaiaContext.CreateDbContextAsync();
            return tbmapper.MapFromModel(await db.TbOrderStatuses.FindAsync(id));
        }

        public async IAsyncEnumerable<Status> GetStatuses()
        {
            using var db = await kursovaiaContext.CreateDbContextAsync();
            await foreach (var item in db.GetOrderStatuses.AsAsyncEnumerable())
                yield return getmapper.MapFromModel(item);
        }
    }
}
