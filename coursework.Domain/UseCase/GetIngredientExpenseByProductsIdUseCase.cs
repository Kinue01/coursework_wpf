using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class GetIngredientExpenseByProductsIdUseCase(IngredientExpenseRepository repository)
    {
        public IAsyncEnumerable<IngredientExpense> Execute(List<CartOrder> cart)
        {
            return repository.GetIngredients(cart);
        }
    }
}
