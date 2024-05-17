using coursework.Data.Repository;
using coursework.Domain.Model;
using coursework.EntityFramework.Mapper;
using coursework.EntityFramework.Model;
using Microsoft.EntityFrameworkCore;

namespace coursework.EntityFramework.RepositoryImpl
{
    public class PaytypeDbRepositoryImpl(IDbContextFactory<KursovaiaContext> dbContext, GetPayTypeMapper getMapper) : PaytypeDbRepository
    {
        public async IAsyncEnumerable<Paytype> GetPaytypes()
        {
            using var db = await dbContext.CreateDbContextAsync();
            await foreach (var item in db.GetPayTypes.AsAsyncEnumerable())
                yield return getMapper.MapFromModel(item);
        }
    }
}
