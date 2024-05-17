using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using coursework.Domain.Model;
using coursework.Domain.UseCase;
using coursework.UI.Dialog.ViewModel;
using coursework.UI.Messenger;
using coursework.UI.Service.Interface;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace coursework.UI.ViewModel
{
    class IngredsViewModel : ObservableObject
    {
        ObservableCollection<Ingredient> ingredients;
        ObservableCollection<IngredType> types;
        GetIngredsUseCase getIngredsUseCase;
        GetIngredTypesUseCase getIngredTypesUseCase;
        FilterIngredsByNameUseCase filterIngredsByNameUseCase;
        FilterIngredsByTypeIdUseCase filterIngredsByTypeIdUseCase;
        string queryName;
        Ingredient currIngred;
        IngredType currIngredType;
        IDialogService dialogService;
        DeleteIngredUseCase deleteIngredUseCase;
        AddIngredViewModel addIngredViewModel;
        UpdateIngredViewModel updateIngredViewModel;
        Visibility isAdmin, isWorkshopHead;

        public ObservableCollection<Ingredient> Ingredients
        {
            get => ingredients;
            set => SetProperty(ref ingredients, value);
        }
        public ObservableCollection<IngredType> Types
        {
            get => types;
            set => SetProperty(ref types, value);
        }
        public string QueryName
        {
            get => queryName;
            set => SetProperty(ref queryName, value);
        }
        public IngredType CurrIngredType
        {
            get => currIngredType;
            set => SetProperty(ref currIngredType, value);
        }
        public Ingredient CurrIngredient
        {
            get => currIngred;
            set => SetProperty(ref currIngred, value);
        }
        public Visibility IsAdmin
        {
            get => isAdmin;
            set => SetProperty(ref isAdmin, value);
        }
        public Visibility IsWorkshopHead
        {
            get => isWorkshopHead;
            set => SetProperty(ref isWorkshopHead, value);
        }

        public ICommand NavigateIngredsOnWarehouseCommand { get; set; }
        public IAsyncRelayCommand FilterByNameCommand { get; set; }
        public IAsyncRelayCommand FilterByTypeIdCommand { get; set; }
        public IAsyncRelayCommand AddIngredCommand { get; set; }
        public IAsyncRelayCommand UpdateIngredCommand { get; set; }
        public IAsyncRelayCommand DeleteIngredCommand { get; set; }

        public IngredsViewModel(GetIngredsUseCase getIngredsUseCase, INavigationService navigationService, GetIngredTypesUseCase getIngredTypesUseCase, FilterIngredsByNameUseCase filterIngredsByNameUseCase, FilterIngredsByTypeIdUseCase filterIngredsByTypeIdUseCase, IDialogService dialogService, DeleteIngredUseCase deleteIngredUseCase, AddIngredViewModel addIngredViewModel, UpdateIngredViewModel updateIngredViewModel)
        {
            this.getIngredsUseCase = getIngredsUseCase;
            this.getIngredTypesUseCase = getIngredTypesUseCase;
            this.filterIngredsByNameUseCase = filterIngredsByNameUseCase;
            this.filterIngredsByTypeIdUseCase = filterIngredsByTypeIdUseCase;
            this.dialogService = dialogService;
            this.deleteIngredUseCase = deleteIngredUseCase;
            this.addIngredViewModel = addIngredViewModel;
            this.updateIngredViewModel = updateIngredViewModel;

            NavigateIngredsOnWarehouseCommand = new RelayCommand(navigationService.NavigateDashboardTo<IngredsOnWarehouseViewModel>);
            FilterByNameCommand = new AsyncRelayCommand(FilterName);
            FilterByTypeIdCommand = new AsyncRelayCommand(FilterType);
            AddIngredCommand = new AsyncRelayCommand(AddIngred);
            UpdateIngredCommand = new AsyncRelayCommand(UpdateIngred);
            DeleteIngredCommand = new AsyncRelayCommand(DeleteIngred);

            WeakReferenceMessenger.Default.Register<DashboardEmployeeMessenger>(this, async (r, m) =>
            {

                await GetTypes();
                await GetIngreds();

                if (m.Value.Position.PositionId == 1 || m.Value.Position.PositionId == 2)
                {
                    IsAdmin = Visibility.Visible;
                    IsWorkshopHead = Visibility.Visible;
                }
                else if (m.Value.Position.PositionId == 5)
                {
                    IsAdmin = Visibility.Collapsed;
                    IsWorkshopHead = Visibility.Visible;
                }
                else
                {
                    IsAdmin = Visibility.Collapsed;
                    IsWorkshopHead = Visibility.Collapsed;
                }
            });
        }

        async Task GetIngreds()
        {
            Ingredients = [];
            await foreach (var ingred in getIngredsUseCase.Execute())
                Ingredients.Add(ingred);
        }
        async Task GetTypes()
        {
            Types = [];
            Types.Add(new IngredType(0, "Все", 0, 0));
            await foreach (var item in getIngredTypesUseCase.Execute())
                Types.Add(item);
        }
        async Task FilterName()
        {
            Ingredients.Clear();
            if (QueryName != "")
            {
                await foreach (var item in filterIngredsByNameUseCase.Execute(QueryName))
                    Ingredients.Add(item);
            }
            else
                await GetIngreds();
        }
        async Task FilterType()
        {
            Ingredients.Clear();
            if (CurrIngredType != null && CurrIngredType.TypeId != 0)
            {
                await foreach (var item in filterIngredsByTypeIdUseCase.Execute(CurrIngredType.TypeId))
                    Ingredients.Add(item);
            }
            else
                await GetIngreds();
        }
        async Task AddIngred()
        {
            var res = dialogService.OpenDialog(addIngredViewModel);
            if (res == Utils.DialogResults.Yes)
            {
                await GetIngreds();
            }
        }
        async Task UpdateIngred()
        {
            WeakReferenceMessenger.Default.Send(new IngredientMessenger(CurrIngredient));
            var res = dialogService.OpenDialog(updateIngredViewModel);

            if (res == Utils.DialogResults.Yes)
            {
                await GetIngreds();
            }
        }
        async Task DeleteIngred()
        {
            if (CurrIngredient != null)
            {
                var res = dialogService.OpenDialog(new DeleteDialogViewModel("Удаление ингредиента", $"Вы точно хотите удалить {CurrIngredient.Name}"));
                if (res == Utils.DialogResults.Yes)
                {
                    if (await deleteIngredUseCase.Execute(CurrIngredient.Id) == true)
                    {
                        await GetIngreds();
                    }
                    else
                    {
                        dialogService.OpenDialog(new AlertDialogViewModel("Ошибка", $"Не удалось удалить {CurrIngredient.Name}"));
                    }
                }
            }
            else
            {
                dialogService.OpenDialog(new AlertDialogViewModel("Ошибка", "Выберите ингредиент"));
            }
        }
    }
}
