using coursework.Domain.Model;

namespace coursework.Data.Repository
{
    public interface IngredientExpenseDbRepository
    {
        IAsyncEnumerable<IngredientExpense> GetIngredients(List<CartOrder> cart);
    }
}
