using coursework.Data.Repository;
using coursework.Domain.Model;
using coursework.Domain.Repository;
using System.Collections.Generic;

namespace coursework.Data.RepositoryImpl
{
    public class IngredientExpenseRepositoryImpl(IngredientExpenseDbRepository repository) : IngredientExpenseRepository
    {
        public IAsyncEnumerable<IngredientExpense> GetIngredients(List<CartOrder> cart)
        {
            return repository.GetIngredients(cart);
        }
    }
}
