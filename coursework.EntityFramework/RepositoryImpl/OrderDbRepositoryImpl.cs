using coursework.Data.Repository;
using coursework.Domain.Model;
using coursework.EntityFramework.Mapper;
using coursework.EntityFramework.Model;
using Microsoft.EntityFrameworkCore;

namespace coursework.EntityFramework.RepositoryImpl
{
    public class OrderDbRepositoryImpl(IDbContextFactory<KursovaiaContext> kursovaiaContext, GetOrderMapper getMapper, TbOrderMapper tbmapper, GetCartOrderMapper getCartOrderMapper) : OrderDbRepository
    {
        public async Task<bool> AddOrder(int cId, string addr, int cost, int pCount, DateOnly date, int pId, List<Product> products)
        {
            using var db = await kursovaiaContext.CreateDbContextAsync();
            using var trans = await db.Database.BeginTransactionAsync();
            try
            {
                await db.Database.ExecuteSqlInterpolatedAsync($"call add_order({cId}, {addr}, {cost}, {pCount}, {date}, {pId}, 1)");

                var temp = await db.TbOrders.OrderBy(order => order.OrderId).LastAsync();

                var cart = products.GroupBy(u => u.ProductId).Select(g => new
                {
                    g.Key,
                    Count = g.Count()
                }).ToList();

                cart.ForEach(prod =>
                {
                    db.Database.ExecuteSqlInterpolated($"call add_cart_order({temp.OrderId}, {prod.Key}, {prod.Count}, {null})");
                });

                await trans.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                return false;
            }
        }

        public async IAsyncEnumerable<Order> FilterOrder(int id)
        {
            using var db = await kursovaiaContext.CreateDbContextAsync();
            await foreach(var item in db.TbOrders.Where(order => order.OrderStatusId == id).AsAsyncEnumerable())
                yield return await tbmapper.MapFromModel(item);
        }

        public async IAsyncEnumerable<CartOrder> GetCartOrder(int id)
        {
            using var db = await kursovaiaContext.CreateDbContextAsync();
            await foreach(var item in db.GetCartOrders.Where(order => order.CartOrderId == id).AsAsyncEnumerable())
                yield return await getCartOrderMapper.MapFromModel(item);
        }

        public async Task<Order> GetOrderById(int id)
        {
            using var db = await kursovaiaContext.CreateDbContextAsync();
            return await tbmapper.MapFromModel(await db.TbOrders.FindAsync(id));
        }

        public async IAsyncEnumerable<Order> GetOrders()
        {
            using var db = await kursovaiaContext.CreateDbContextAsync();
            await foreach (var item in db.GetOrders.AsAsyncEnumerable())
                yield return getMapper.MapFromModel(item);
        }

        public async Task<bool> UpdateOrderStatus(int id)
        {
            using var db = await kursovaiaContext.CreateDbContextAsync();
            try
            {
                await db.Database.ExecuteSqlInterpolatedAsync($"call update_order_status({id})");
                return true;
            }
            catch (Exception ex) 
            {
                return false;
            }
        }
    }
}
