using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using coursework.Domain.Model;
using coursework.Domain.UseCase;
using coursework.UI.Messenger;
using coursework.UI.Service.Interface;
using coursework.UI.Utils;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace coursework.UI.Dialog.ViewModel
{
    internal class AddProdComposViewModel : DialogViewModelBase<DialogResults>
    {
        ObservableCollection<Ingredient> ingredients;
        Ingredient currIngredient;
        int count;
        AddProdComposUseCase AddProdComposUseCase;
        Product product;
        GetIngredsUseCase GetIngredsUseCase;
        IDialogService DialogService;

        public ObservableCollection<Ingredient> Ingredients
        {
            get => ingredients;
            set => SetProperty(ref ingredients, value);
        }
        public Ingredient CurrIngredient
        {
            get => currIngredient;
            set => SetProperty(ref currIngredient, value);
        }
        public int Count
        {
            get => count; 
            set => SetProperty(ref count, value);
        }

        public IAsyncRelayCommand YesCommand { get; set; }
        public ICommand NoCommand { get; set; }

        public AddProdComposViewModel(AddProdComposUseCase addProdComposUseCase, GetIngredsUseCase getIngredsUseCase, IDialogService dialogService)
        {
            AddProdComposUseCase = addProdComposUseCase;
            GetIngredsUseCase = getIngredsUseCase;
            DialogService = dialogService;

            YesCommand = new AsyncRelayCommand<IDialogWindow>(Yes);
            NoCommand = new RelayCommand<IDialogWindow>(No);

            WeakReferenceMessenger.Default.Register<ProdComposMessenger>(this, async (r, m) =>
            {
                product = m.Value.CompositionProduct;

                await GetIngreds();
            });
        }

        async Task Yes(IDialogWindow window)
        {
            if (CurrIngredient != null)
            {
                if (!await AddProdComposUseCase.Execute(new ProdComposition(product, CurrIngredient, Count)))
                {
                    DialogService.OpenDialog(new AlertDialogViewModel("Ошибка", "Не удалось добавить ингредиент"));
                }
                else
                {
                    CloseDialogWithResult(window, DialogResults.Yes);
                }
            }
            else
            {
                DialogService.OpenDialog(new AlertDialogViewModel("Ошибка", "Выберите ингредиент"));
            }
        }
        void No(IDialogWindow window)
        {
            CloseDialogWithResult(window, DialogResults.No);
        }
        async Task GetIngreds()
        {
            Ingredients = [];
            await foreach(var item in GetIngredsUseCase.Execute())
                Ingredients.Add(item);
        }
    }
}
