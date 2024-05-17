using coursework.Data.Repository;
using coursework.Domain.Model;
using coursework.EntityFramework.Mapper;
using coursework.EntityFramework.Model;
using coursework.EntityFramework.Utils;
using Microsoft.EntityFrameworkCore;

namespace coursework.EntityFramework.RepositoryImpl
{
    public class UserDbRepositoryImpl(IDbContextFactory<KursovaiaContext> kursovaiaContext, TbUserMapper tbUserMapper, EVerification hash) : UserDbRepository
    {
        public async Task<User> CheckUser(string login, string pass)
        {
            using var db = await kursovaiaContext.CreateDbContextAsync();
            var res = await db.TbUsers.Where(user => user.UserLogin == login).ToListAsync();
            if (hash.VerifySHA512Hash(pass, res[0].UserPassword))
            {
                return tbUserMapper.MapFromModel(res[0]);
            }
            else
            {
                return null;
            }
        }

        public async Task<User> GetUser(string login)
        {
            using var db = await kursovaiaContext.CreateDbContextAsync();
            var res = await db.TbUsers.Where(user => user.UserLogin == login).ToListAsync();
            return tbUserMapper.MapFromModel(res[0]);
        }
    }
}