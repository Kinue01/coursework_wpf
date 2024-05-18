using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using coursework.Domain.Model;
using coursework.Domain.UseCase;
using coursework.UI.Dialog.ViewModel;
using coursework.UI.Service.Interface;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace coursework.UI.ViewModel
{
    internal class IngredsOnWarehouseViewModel : ObservableObject
    {
        ObservableCollection<IngredientOnWarehouse> ingredients;
        GetIngredsOnWarehouseUseCase GetIngredsOnWarehouseUseCase;
        IDialogService dialogService;
        AddIngredOnWarehouseViewModel AddIngredOnWarehouseViewModel;

        public ObservableCollection<IngredientOnWarehouse> Ingredients
        {
            get => ingredients;
            set => SetProperty(ref ingredients, value);
        }

        public ICommand NavigateIngredsCommand { get; set; }
        public IAsyncRelayCommand AddIngredCommand { get; set; }

        public IngredsOnWarehouseViewModel(GetIngredsOnWarehouseUseCase getIngredsOnWarehouseUseCase, INavigationService navigationService, IDialogService dialogService, AddIngredOnWarehouseViewModel addIngredOnWarehouseViewModel)
        {
            GetIngredsOnWarehouseUseCase = getIngredsOnWarehouseUseCase;
            this.dialogService = dialogService;
            AddIngredOnWarehouseViewModel = addIngredOnWarehouseViewModel;

            NavigateIngredsCommand = new RelayCommand(navigationService.NavigateDashboardTo<IngredsViewModel>);
            AddIngredCommand = new AsyncRelayCommand(AddIngredOnWarehouse);

            GetIngreds();
        }

        async Task GetIngreds()
        {
            Ingredients = [];
            await foreach (var item in GetIngredsOnWarehouseUseCase.Execute())
                Ingredients.Add(item);
        }
        async Task AddIngredOnWarehouse()
        {
            var res = dialogService.OpenDialog(AddIngredOnWarehouseViewModel);
            if (res == Utils.DialogResults.Yes)
            {
                await GetIngreds();
            }
        }
    }
}
