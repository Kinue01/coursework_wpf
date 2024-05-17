using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using coursework.Domain.Model;
using coursework.UI.Messenger;
using coursework.UI.Service.Interface;
using System.Windows.Input;

namespace coursework.UI.ViewModel
{
    class ProdViewModel : ObservableObject
    {
        Product product;
        INavigationService navigationService;
        Client client;
        int count;

        public Product Product
        {
            get => product; 
            set => SetProperty(ref product, value);
        }
        public INavigationService NavigationService
        {
            get => navigationService;
            set => SetProperty(ref navigationService, value);
        }
        public int Count
        {
            get => count;
            set => SetProperty(ref count, value);
        }

        public ICommand NavigateAddOrderCommand { get; set; }

        public ProdViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;

            WeakReferenceMessenger.Default.Register<ProductMessenger>(this, (r, m) =>
            {
                Product = m.Value;
            });
            WeakReferenceMessenger.Default.Register<ClientMessenger>(this, (r, m) =>
            {
                client = m.Value;
            });

            NavigateAddOrderCommand = new RelayCommand(NavigateAddOrder);
        }

        void NavigateAddOrder()
        {
            NavigationService.NavigateMainTo<AddOrderViewModel>();
            for (int i = 0; i < count; i++)
            {
                WeakReferenceMessenger.Default.Send(new ProductMessenger(Product));
            }
            WeakReferenceMessenger.Default.Send(new ClientMessenger(client));
            WeakReferenceMessenger.Default.Send(new CountMessenger(Count));
        }
    }
}
