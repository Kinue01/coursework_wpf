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
    internal class EmpProdsViewModel : ObservableObject
    {
        ObservableCollection<Product> products;
        GetProductsUseCase getProductsUseCase;
        Product currProduct;
        AddProductViewModel addProductViewModel;
        IDialogService dialogService;
        INavigationService navigationService;
        FilterProductsByNameUseCase filterProductsByNameUseCase;
        FilterProductsByPriceUseCase filterProductsByPriceUseCase;
        string queryName;
        int lower, upper;
        DeleteProductUseCase deleteProductUseCase;
        UpdateProductViewModel updateProductViewModel;
        Visibility isAdmin;

        public ObservableCollection<Product> Products
        {
            get => products;
            set => SetProperty(ref products, value);
        }
        public Product CurrProduct
        {
            get => currProduct;
            set => SetProperty(ref currProduct, value);
        }
        public INavigationService NavigationService
        {
            get => navigationService;
            set => SetProperty(ref navigationService, value);
        }
        public string QueryName
        {
            get => queryName;
            set => SetProperty(ref queryName, value);
        }
        public int Lower
        {
            get => lower;
            set => SetProperty(ref lower, value);
        }
        public int Upper
        {
            get => upper;
            set => SetProperty(ref upper, value);
        }
        public Visibility IsAdmin
        {
            get => isAdmin;
            set => SetProperty(ref isAdmin, value);
        }

        public IAsyncRelayCommand AddProductDialog { get; set; }
        public ICommand NavigateProdComposCommand { get; set; }
        public IAsyncRelayCommand FilterNameCommand { get; set; }
        public IAsyncRelayCommand FilterPriceCommand { get; set; }
        public IAsyncRelayCommand DeleteProdCommand { get; set; }
        public IAsyncRelayCommand UpdateProdCommand { get; set; }

        public EmpProdsViewModel(GetProductsUseCase getProductsUseCase, AddProductViewModel addProductViewModel, IDialogService dialogService, INavigationService navigationService, FilterProductsByNameUseCase filterProductsByNameUseCase, FilterProductsByPriceUseCase filterProductsByPriceUseCase, DeleteProductUseCase deleteProductUseCase, UpdateProductViewModel updateProductViewModel)
        {
            this.getProductsUseCase = getProductsUseCase;
            this.addProductViewModel = addProductViewModel;
            this.dialogService = dialogService;
            NavigationService = navigationService;
            this.filterProductsByPriceUseCase = filterProductsByPriceUseCase;
            this.filterProductsByNameUseCase = filterProductsByNameUseCase;
            this.deleteProductUseCase = deleteProductUseCase;
            this.updateProductViewModel = updateProductViewModel;

            AddProductDialog = new AsyncRelayCommand(AddProd);
            NavigateProdComposCommand = new RelayCommand(NavigateProdCompos);
            FilterNameCommand = new AsyncRelayCommand(FilterName);
            FilterPriceCommand = new AsyncRelayCommand(FilterPrice);
            DeleteProdCommand = new AsyncRelayCommand(DeleteProd);
            UpdateProdCommand = new AsyncRelayCommand(UpdateProd);

            WeakReferenceMessenger.Default.Register<DashboardEmployeeMessenger>(this, (r, m) =>
            {
                if (m.Value.Position.PositionId == 2 || m.Value.Position.PositionId == 1)
                {
                    IsAdmin = Visibility.Visible;
                }
                else
                {
                    IsAdmin = Visibility.Collapsed;
                }
            });

            Task.Run(GetProds);
        }

        async Task GetProds()
        {
            Products = [];
            await foreach(var item in getProductsUseCase.Execute())
                Products.Add(item);
        }
        async Task AddProd()
        {
            var res = dialogService.OpenDialog(addProductViewModel);
            if (res == Utils.DialogResults.Yes)
            {
                await GetProds();
            }
        }
        void NavigateProdCompos()
        {
            NavigationService.NavigateDashboardTo<ProductComposViewModel>();
            WeakReferenceMessenger.Default.Send(new ProductMessenger(CurrProduct));
        }
        async Task FilterName()
        {
            Products.Clear();
            if (QueryName != "")
            {
                Products.Clear();
                await foreach(var item in filterProductsByNameUseCase.Execute(QueryName))
                    Products.Add(item);
            }
                
            else
                await GetProds();
        }
        async Task FilterPrice()
        {
            Products.Clear();
            await foreach(var item in filterProductsByPriceUseCase.Execute(Lower, Upper))
                Products.Add(item);
        }
        async Task DeleteProd()
        {
            if (CurrProduct != null)
            {
                var res = dialogService.OpenDialog(new DeleteDialogViewModel("Удаление продукта", $"Вы точно хотите удалить {CurrProduct.ProductName}"));
                if (res == Utils.DialogResults.Yes)
                {
                    var result = await deleteProductUseCase.Execute(CurrProduct);
                    if (result == true)
                    {
                        await GetProds();
                    }
                    else
                    {
                        dialogService.OpenDialog(new AlertDialogViewModel("Ошибка", "Не удалось удалить продукт"));
                    }
                }
            }
            else
            {
                dialogService.OpenDialog(new AlertDialogViewModel("Ошибка", "Выберите продукт"));
            }
        }
        async Task UpdateProd()
        {
            WeakReferenceMessenger.Default.Send(new ProductMessenger(CurrProduct));
            var res = dialogService.OpenDialog(updateProductViewModel);

            if (res == Utils.DialogResults.Yes)
            {
                await GetProds();
            }
        }
    }
}