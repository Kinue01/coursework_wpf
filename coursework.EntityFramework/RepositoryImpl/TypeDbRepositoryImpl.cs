using coursework.Data.Repository;
using coursework.Domain.Model;
using coursework.EntityFramework.Mapper;
using coursework.EntityFramework.Model;
using Microsoft.EntityFrameworkCore;

namespace coursework.EntityFramework.RepositoryImpl
{
    public class TypeDbRepositoryImpl(IDbContextFactory<KursovaiaContext> contextFactory, TbIngredientTypeMapper tbMapper, GetIngredTypeMapper getMapper) : TypeDbRepository
    {
        public async Task<IngredType> GetTypeById(int id)
        {
            using var db = await contextFactory.CreateDbContextAsync();
            return tbMapper.MapFromModel(await db.TbIngredientTypes.FindAsync(id));
        }

        public async IAsyncEnumerable<IngredType> GetTypes()
        {
            using var db = await contextFactory.CreateDbContextAsync();
            await foreach (var item in db.GetIngredsTypes.AsAsyncEnumerable())
                yield return getMapper.MapFromModel(item);
        }
    }
}
