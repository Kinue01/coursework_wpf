using coursework.Data.Repository;
using coursework.Domain.Model;
using coursework.EntityFramework.Mapper;
using coursework.EntityFramework.Model;
using Microsoft.EntityFrameworkCore;

namespace coursework.EntityFramework.RepositoryImpl
{
    public class PositionDbRepositoryImpl(IDbContextFactory<KursovaiaContext> dbContext, GetPoseMapper getMapper, TbPositionMapper tbMapper) : PositionDbRepository
    {
        public async Task<Position> GetPositionById(int positionId)
        {
            using var db = await dbContext.CreateDbContextAsync();
            return tbMapper.MapFromModel(await db.TbPositions.FindAsync(positionId));
        }

        public async IAsyncEnumerable<Position> GetPositions()
        {
            using var db = await dbContext.CreateDbContextAsync();
            await foreach (var item in db.GetPoses.AsAsyncEnumerable())
                yield return getMapper.MapFromModel(item);
        }
    }
}
