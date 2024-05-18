using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using coursework.Domain.Model;
using coursework.Domain.UseCase;
using coursework.UI.Messenger;
using coursework.UI.Service.Interface;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace coursework.UI.ViewModel
{
    internal class ProductsViewModel : ObservableObject
    {
        ObservableCollection<Product> products;
        GetProductsUseCase getProductsUseCase;
        FilterProductsByNameUseCase filterProductsByNameUseCase;
        FilterProductsByPriceUseCase filterProductsByPriceUseCase;
        Product currProduct;
        INavigationService navigationService;
        Client client;
        string queryName;
        int lower, upper;

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

        public ICommand NavigateProdViewCommand { get; set; }
        public IAsyncRelayCommand FilterNameCommand { get; set; }
        public IAsyncRelayCommand FilterPriceCommand { get; set; }

        public ProductsViewModel(GetProductsUseCase getProductsUseCase, INavigationService navigationService, FilterProductsByNameUseCase filterProductsByNameUseCase, FilterProductsByPriceUseCase filterProductsByPriceUseCase)
        {
            this.getProductsUseCase = getProductsUseCase;
            this.filterProductsByNameUseCase = filterProductsByNameUseCase;
            this.filterProductsByPriceUseCase = filterProductsByPriceUseCase;

            NavigateProdViewCommand = new RelayCommand(NavigateProdView);
            NavigationService = navigationService;

            FilterNameCommand = new AsyncRelayCommand(FilterName);
            FilterPriceCommand = new AsyncRelayCommand(FilterPrice);

            WeakReferenceMessenger.Default.Register<ClientMessenger>(this, (r, m) =>
            {
                client = m.Value;
            });

            GetProds();
        }

        async Task GetProds()
        {
            Products = [];
            await foreach(var item in getProductsUseCase.Execute())
                Products.Add(item);
        }
        void NavigateProdView() 
        {
            if (client != null)
            {
                NavigationService.NavigateMainTo<ProdViewModel>();
                WeakReferenceMessenger.Default.Send(new ProductMessenger(CurrProduct));
                WeakReferenceMessenger.Default.Send(new ClientMessenger(client));
            }
        }
        async Task FilterName()
        {
            Products.Clear();
            if (QueryName != "")
            {
                
                await foreach (var item in filterProductsByNameUseCase.Execute(QueryName))
                    Products.Add(item);
            }
            else
                await GetProds();
        }
        async Task FilterPrice()
        {
            Products.Clear();
            await foreach (var item in filterProductsByPriceUseCase.Execute(Lower, Upper))
                Products.Add(item);
        }
    }
}