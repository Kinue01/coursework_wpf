using CommunityToolkit.Mvvm.Input;
using coursework.Domain.Model;
using coursework.Domain.UseCase;
using coursework.UI.Service.Interface;
using coursework.UI.Utils;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace coursework.UI.Dialog.ViewModel
{
    internal class AddIngredOnWarehouseViewModel : DialogViewModelBase<DialogResults>
    {
        ObservableCollection<Ingredient> ingredients;
        ObservableCollection<Supplier> suppliers;
        Ingredient currIngred;
        Supplier currSupplier;
        DateTime upto;
        int count;
        AddIngredOnWarehouseUseCase AddIngredOnWarehouseUseCase;
        GetIngredsUseCase GetIngredsUseCase;
        GetSuppliersUseCase GetSuppliersUseCase;
        IDialogService dialogService;

        public ObservableCollection<Supplier> Suppliers
        {
            get => suppliers;
            set => SetProperty(ref suppliers, value);
        }
        public int Count
        {
            get => count;
            set => SetProperty(ref count, value);
        }
        public DateTime Upto
        {
            get => upto; 
            set => SetProperty(ref upto, value);
        }
        public ObservableCollection<Ingredient> Ingredients
        {
            get => ingredients; 
            set => SetProperty(ref ingredients, value);
        }
        public Ingredient CurrIngred
        {
            get => currIngred; 
            set => SetProperty(ref currIngred, value);
        }
        public Supplier CurrSupplier
        {
            get => currSupplier; 
            set => SetProperty(ref currSupplier, value);
        }

        public IAsyncRelayCommand YesCommand { get; set; }
        public ICommand NoCommand { get; set; }

        public AddIngredOnWarehouseViewModel(AddIngredOnWarehouseUseCase addIngredOnWarehouseUseCase, GetIngredsUseCase getIngredsUseCase, GetSuppliersUseCase getSuppliersUseCase, IDialogService dialogService)
        {
            AddIngredOnWarehouseUseCase = addIngredOnWarehouseUseCase;
            GetSuppliersUseCase = getSuppliersUseCase;
            GetIngredsUseCase = getIngredsUseCase;
            this.dialogService = dialogService;

            YesCommand = new AsyncRelayCommand<IDialogWindow>(Yes);
            NoCommand = new RelayCommand<IDialogWindow>(No);

            Task.Run(GetIngreds);
            Task.Run(GetSuppliers);
        }

        async Task Yes(IDialogWindow window)
        {
            if (CurrIngred != null && CurrSupplier != null)
            {
                if (!await AddIngredOnWarehouseUseCase.Execute(new IngredientOnWarehouse(CurrIngred, CurrSupplier, DateOnly.FromDateTime(DateTime.Now), Count, DateOnly.FromDateTime(Upto))))
                {
                    dialogService.OpenDialog(new AlertDialogViewModel("Ошибка", "Не удалось добавить ингредиент на склад"));
                }
                else
                {
                    CloseDialogWithResult(window, DialogResults.Yes);
                }
            }
            else
            {
                dialogService.OpenDialog(new AlertDialogViewModel("Ошибка", "Выберите ингредиент и поставщика"));
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
        async Task GetSuppliers()
        {
            Suppliers = [];
            await foreach(var item in GetSuppliersUseCase.Execute())
                Suppliers.Add(item);
        }
    }
}
