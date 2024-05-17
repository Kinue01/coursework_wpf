using coursework.Domain.Model;

namespace coursework.Domain.Repository
{
    public interface IngredientExpenseRepository
    {
        IAsyncEnumerable<IngredientExpense> GetIngredients(List<CartOrder> cart);
    }
}
