using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using coursework.Domain.Model;
using coursework.Domain.UseCase;
using coursework.UI.Messenger;
using System.Collections.ObjectModel;

namespace coursework.UI.ViewModel
{
    internal class IngredExpenseViewModel : ObservableObject
    {
        ObservableCollection<IngredientExpense> ingredients;
        GetIngredientExpenseByProductsIdUseCase GetIngredientExpenseByProductsIdUseCase;
        List<CartOrder> cartOrders;

        public ObservableCollection<IngredientExpense> Ingredients
        {
            get => ingredients;
            set => SetProperty(ref ingredients, value);
        }

        public IngredExpenseViewModel(GetIngredientExpenseByProductsIdUseCase getIngredientExpenseByProductsIdUseCase) 
        {
            GetIngredientExpenseByProductsIdUseCase = getIngredientExpenseByProductsIdUseCase;

            WeakReferenceMessenger.Default.Register<CartOrderMessenger>(this, async (r, m) =>
            {
                cartOrders = m.Value;

                await GetIngreds();
            });
        }

        async Task GetIngreds()
        {
            Ingredients = [];
            await foreach (var item in GetIngredientExpenseByProductsIdUseCase.Execute(cartOrders))
                Ingredients.Add(item);
        }
    }
}
