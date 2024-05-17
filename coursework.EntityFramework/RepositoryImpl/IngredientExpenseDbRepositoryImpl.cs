using coursework.Data.Repository;
using coursework.Domain.Model;
using coursework.EntityFramework.Mapper;
using coursework.EntityFramework.Model;
using Microsoft.EntityFrameworkCore;

namespace coursework.EntityFramework.RepositoryImpl
{
    public class IngredientExpenseDbRepositoryImpl(IDbContextFactory<KursovaiaContext> contextFactory, GetIngredExpenseMapper getMapper) : IngredientExpenseDbRepository
    {
        public async IAsyncEnumerable<IngredientExpense> GetIngredients(List<CartOrder> cart)
        {
            using var db = await contextFactory.CreateDbContextAsync();
            foreach (var cartOrder in cart) 
            {
                await foreach (var item in db.GetIngredsExpenses.Where(ingred => cartOrder.CartProduct.ProductId == ingred.ProductId).AsAsyncEnumerable())
                    yield return await getMapper.MapFromModel(item);
            }
        }
    }
}
