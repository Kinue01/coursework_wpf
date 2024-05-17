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

namespace coursework.UI.ViewModel
{
    class AddOrderViewModel : ObservableObject
    {
        List<Product> products;
        Client client;
        ObservableCollection<Paytype> paytypes;
        int count;
        GetPaytypesUseCase GetPaytypesUseCase;
        Paytype currType;
        AddOrderUseCase AddOrderUseCase;
        string address;
        INavigationService navigationService;
        IDialogService dialogService;
        AddCartOrderUseCase AddCartOrderUseCase;

        public Client Client
        {
            get => client;
            set => SetProperty(ref client, value);
        }
        public ObservableCollection<Paytype> Paytypes
        {
            get => paytypes;
            set => SetProperty(ref paytypes, value);
        }
        public Paytype CurrType
        {
            get => currType;
            set => SetProperty(ref currType, value);
        }
        public string Address
        {
            get => address;
            set => SetProperty(ref address, value);
        }
        public INavigationService NavigationService
        {
            get => navigationService;
            set => SetProperty(ref navigationService, value);
        }

        public IAsyncRelayCommand AddOrderCommand { get; set; }

        public AddOrderViewModel(GetPaytypesUseCase getPaytypesUseCase, AddOrderUseCase addOrderUseCase, IDialogService dialogService, INavigationService navigationService, AddCartOrderUseCase addCartOrderUseCase)
        {
            GetPaytypesUseCase = getPaytypesUseCase;
            AddOrderUseCase = addOrderUseCase;
            this.dialogService = dialogService;
            NavigationService = navigationService;
            AddCartOrderUseCase = addCartOrderUseCase;

            AddOrderCommand = new AsyncRelayCommand(AddOrder);

            products = [];

            WeakReferenceMessenger.Default.Register<ProductMessenger>(this, (r, m) =>
            {
                products.Add(m.Value);
            });
            WeakReferenceMessenger.Default.Register<ClientMessenger>(this, (r, m) =>
            {
                client = m.Value;
            });
            WeakReferenceMessenger.Default.Register<CountMessenger>(this, (r, m) =>
            {
                count = m.Value;
            });

            Task.Run(GetTypes);
        }

        async Task GetTypes()
        {
            Paytypes = [];
            await foreach (var item in GetPaytypesUseCase.Execute())
                Paytypes.Add(item);
        }
        async Task AddOrder()
        {
            if (CurrType != null)
            {
                int cost = 0;
                products.ForEach(prod =>
                {
                    cost += prod.ProductPrice;
                });

                if (await AddOrderUseCase.Execute(Client.Id, Address, cost, count, DateOnly.FromDateTime(DateTime.Now), CurrType.TypeId, products))
                {
                    dialogService.OpenDialog(new AlertDialogViewModel("Успех", "Заказ успешно добавлен"));
                    NavigationService.NavigateMainTo<ProductsViewModel>();
                }
                else
                {
                    dialogService.OpenDialog(new AlertDialogViewModel("Ошибка", "Заказ не добавлен"));
                }
            }
            else
            {
                dialogService.OpenDialog(new AlertDialogViewModel("Ошибка", "Выберите тип"));
            }
        }
    }
}