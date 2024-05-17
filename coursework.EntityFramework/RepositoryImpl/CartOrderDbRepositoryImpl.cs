using coursework.Data.Repository;
using coursework.Domain.Model;
using coursework.EntityFramework.Model;
using Microsoft.EntityFrameworkCore;

namespace coursework.EntityFramework.RepositoryImpl
{
    public class CartOrderDbRepositoryImpl(IDbContextFactory<KursovaiaContext> contextFactory) : CartOrderDbRepository
    {
        public async Task<bool> AddCartOrder(List<CartOrder> cartOrders)
        {
            using var db = await contextFactory.CreateDbContextAsync();
            using var trans = await db.Database.BeginTransactionAsync();
            try
            {
                foreach (var cartOrder in cartOrders)
                {
                    await db.Database.ExecuteSqlInterpolatedAsync($"call add_cart_order({cartOrder.CartOrderId}, {cartOrder.CartProduct.ProductId}, {cartOrder.CartProdCount}, {cartOrder.CartProdEmployee.Id})");
                }

                await trans.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                return false;
            }
        }
    }
}