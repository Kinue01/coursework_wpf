using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using coursework.Domain.Model;
using coursework.Domain.UseCase;
using coursework.UI.Dialog.ViewModel;
using coursework.UI.Messenger;
using coursework.UI.Service.Interface;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace coursework.UI.ViewModel
{
    class ProductComposViewModel : ObservableObject
    {
        ObservableCollection<ProdComposition> compositions;
        GetComposByProdIdUseCase GetComposByProdIdUseCase;
        Product product;
        IDialogService dialogService;
        ProdComposition currIngred;
        DeleteProdComposUseCase DeleteProdComposUseCase;
        AddProdComposViewModel AddProdComposViewModel;
        UpdateProdComposViewModel UpdateProdComposViewModel;

        public ObservableCollection<ProdComposition> Compositions
        {
            get => compositions;
            set => SetProperty(ref compositions, value);
        }
        public Product Product
        {
            get => product;
            set => SetProperty(ref product, value);
        }
        public ProdComposition CurrIngred
        {
            get => currIngred;
            set => SetProperty(ref currIngred, value);
        }

        public ICommand NavigateProdsCommand { get; set; }
        public IAsyncRelayCommand AddComposCommand { get; set; }
        public IAsyncRelayCommand UpdateComposCommand { get; set; }
        public IAsyncRelayCommand DeleteComposCommand { get; set; }

        public ProductComposViewModel(GetComposByProdIdUseCase getComposByProdIdUseCase, INavigationService navigationService, IDialogService dialogService, UpdateProdComposViewModel updateProdComposViewModel, AddProdComposViewModel addProdComposViewModel)
        {
            GetComposByProdIdUseCase = getComposByProdIdUseCase;
            this.dialogService = dialogService;
            UpdateProdComposViewModel = updateProdComposViewModel;
            AddProdComposViewModel = addProdComposViewModel;

            NavigateProdsCommand = new RelayCommand(navigationService.NavigateDashboardTo<EmpProdsViewModel>);
            AddComposCommand = new AsyncRelayCommand(AddCompos);
            DeleteComposCommand = new AsyncRelayCommand(DeleteCompos);
            UpdateComposCommand = new AsyncRelayCommand(UpdateCompos);

            WeakReferenceMessenger.Default.Register<ProductMessenger>(this, async (r, m) =>
            {
                Product = m.Value;
                await GetCompos();
            });
        }

        async Task GetCompos()
        {
            Compositions = [];
            await foreach(var item in GetComposByProdIdUseCase.Execute(product.ProductId))
                Compositions.Add(item);
        }
        async Task AddCompos()
        {
            var res = dialogService.OpenDialog(AddProdComposViewModel);

            if (res == Utils.DialogResults.Yes)
            {
                await GetCompos();
            }
        }
        async Task UpdateCompos()
        {
            WeakReferenceMessenger.Default.Send(new ProdComposMessenger(CurrIngred));
            var res = dialogService.OpenDialog(UpdateProdComposViewModel);

            if (res == Utils.DialogResults.Yes)
            {
                await GetCompos();
            }
        }
        async Task DeleteCompos()
        {
            if (CurrIngred != null)
            {
                var res = dialogService.OpenDialog(new DeleteDialogViewModel("Удаление ингредиента в составе", $"Вы точно хотите удалить ингредиент {CurrIngred.CompositionIngredient.Name} в продукте {Product.ProductName}"));
                if (res == Utils.DialogResults.Yes)
                {
                    if (await DeleteProdComposUseCase.Execute(CurrIngred) == true)
                    {
                        await GetCompos();
                    }
                    else
                    {
                        dialogService.OpenDialog(new AlertDialogViewModel("Ошибка", "Не удалось удалить ингредиент"));
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
