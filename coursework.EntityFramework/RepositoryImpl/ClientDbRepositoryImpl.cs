using coursework.Data.Repository;
using coursework.Domain.Model;
using coursework.EntityFramework.Mapper;
using coursework.EntityFramework.Model;
using Microsoft.EntityFrameworkCore;

namespace coursework.EntityFramework.RepositoryImpl
{
    public class ClientDbRepositoryImpl(IDbContextFactory<KursovaiaContext> kursovaiaContext, TbClientMapper tbMapper, GetClientsMapper getMapper) : ClientDbRepository
    {
        public async Task<bool> AddClient(Client client, User user)
        {
            using var db = await kursovaiaContext.CreateDbContextAsync();
            using var transaction = await db.Database.BeginTransactionAsync();
            try
            {
                await db.TbUsers.AddAsync(new TbUser
                {
                    UserLogin = user.Login,
                    UserEmail = user.Email,
                    UserPassword = user.Password,
                    UserRoleId = user.Role,
                    UserPhone = user.PhoneNumber,
                    UserImage = user.imgstr
                });

                await transaction.CreateSavepointAsync("save1");

                await db.TbClients.AddAsync(new TbClient
                {
                    ClientLastname = client.Lastname,
                    ClientFirstname = client.Firstname,
                    ClientMiddlename = client.Middlename,
                    ClientLogin = client.Login,
                    ClientId = client.Id,
                    ClientBirthday = client.Birthday,
                    ClientRegDate = client.RegDate,
                });

                await db.SaveChangesAsync();

                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return false;
            }
        }

        public async Task<bool> DeleteClient(Client client)
        {
            using var db = await kursovaiaContext.CreateDbContextAsync();
            using var trans = await db.Database.BeginTransactionAsync();
            try
            {
                var orders = await db.TbOrders.Where(order => order.OrderClientId == client.Id).ToListAsync();

                foreach(var order in orders)
                {
                    var temp = await db.TbCartOrders.Where(cart => cart.CartOrderId == order.OrderId).ToListAsync();
                    db.TbCartOrders.RemoveRange(temp);
                }
                await db.SaveChangesAsync();

                foreach (var order in orders)
                {
                    await db.Database.ExecuteSqlAsync($"call delete_order({order.OrderId})");
                }

                var user = await db.TbUsers.FindAsync(client.Login);

                var tempcl = await db.TbClients.FindAsync(client.Id);
                await db.Database.ExecuteSqlAsync($"call delete_client({tempcl.ClientId})");

                await db.Database.ExecuteSqlAsync($"call delete_user({user.UserLogin})");
                await trans.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                return false;
            }
        }

        public async IAsyncEnumerable<Client> FilterByBirthday(DateOnly date)
        {
            using var db = await kursovaiaContext.CreateDbContextAsync();
            await foreach (var item in db.GetClients.Where(client => client.ClientBirthday == date).AsAsyncEnumerable())
                yield return getMapper.MapFromModel(item);
        }

        public async IAsyncEnumerable<Client> FilterByFio(string query)
        {
            using var db = await kursovaiaContext.CreateDbContextAsync();
            await foreach (var item in db.GetClients.Where(client => client.ClientFirstname.ToLower().Contains(query.ToLower()) || client.ClientMiddlename.ToLower().Contains(query.ToLower()) || client.ClientLastname.ToLower().Contains(query.ToLower())).AsAsyncEnumerable())
                yield return getMapper.MapFromModel(item);
        }

        public async Task<Client> GetClientAsync(string login)
        {
            using var db = await kursovaiaContext.CreateDbContextAsync();
            return tbMapper.MapFromModel(db.TbClients.FromSqlRaw($"select * from get_client_by_login('{login}')").ToList()[0]);
        }

        public async Task<Client> GetClientById(int id)
        {
            using var db = await kursovaiaContext.CreateDbContextAsync();
            return tbMapper.MapFromModel(await db.TbClients.FindAsync(id));
        }

        public async IAsyncEnumerable<Client> GetClients()
        {
            using var db = await kursovaiaContext.CreateDbContextAsync();
            await foreach (var item in db.GetClients.AsAsyncEnumerable())
                yield return getMapper.MapFromModel(item);
        }

        public async Task<bool> UpdateClient(Client client, User user)
        {
            using var db = await kursovaiaContext.CreateDbContextAsync();
            using var transaction = await db.Database.BeginTransactionAsync();
            try
            {
                var users = await db.TbUsers.Where(usr => usr.UserLogin == user.Login).ToListAsync();
                var usr = users.FirstOrDefault();
                if (usr != null)
                {
                    usr.UserLogin = user.Login;
                    usr.UserEmail = user.Email;
                    usr.UserPassword = user.Password;
                    usr.UserRoleId = user.Role;
                    usr.UserPhone = user.PhoneNumber;
                    usr.UserImage = user.imgstr;
                }

                await transaction.CreateSavepointAsync("save1");

                var cl = await db.TbClients.FindAsync(client.Id);
                if (cl != null)
                {
                    cl.ClientLastname = client.Lastname;
                    cl.ClientFirstname = client.Firstname;
                    cl.ClientMiddlename = client.Middlename;
                    cl.ClientBirthday = client.Birthday;
                    cl.ClientLogin = client.Login;
                    cl.ClientRegDate = client.RegDate;
                }

                await db.SaveChangesAsync();

                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return false;
            }
        }
    }
}