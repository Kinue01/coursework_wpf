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
    class OrdersViewModel : ObservableObject
    {
        ObservableCollection<Order> orders;
        ObservableCollection<Status> statuses;
        Status currStatus;
        private readonly GetOrdersUseCase getOrdersUseCase;
        private readonly GetOrderStatusesUseCase getOrdersStatusesUseCase;
        private readonly FilterOrdersByStatus filterOrdersByStatus;
        private readonly GetOrderCartUseCase getOrderCartUseCase;
        ObservableCollection<CartOrder> cartOrders;
        Order currOrder;
        private readonly INavigationService navigationService;
        Visibility isChief;
        UpdateOrderStatusUseCase updateOrderStatusUseCase;
        IDialogService dialogService;
        UpdateEmployeeInCartOrderUseCase UpdateEmployeeInCartOrderUseCase;
        Employee employee;

        public ObservableCollection<Order> Orders 
        { 
            get => orders; 
            set => SetProperty(ref orders, value);
        }
        public ObservableCollection<Status> Statuses
        {
            get => statuses;
            set => SetProperty(ref statuses, value);
        }
        public Status CurrStatus
        {
            get => currStatus;
            set => SetProperty(ref currStatus, value);
        }
        public ObservableCollection<CartOrder> CartOrders
        {
            get => cartOrders;
            set => SetProperty(ref cartOrders, value);
        }
        public Order CurrOrder
        {
            get => currOrder;
            set => SetProperty(ref currOrder, value);
        }
        public Visibility IsChief
        {
            get => isChief;
            set => SetProperty(ref isChief, value);
        }

        public IAsyncRelayCommand FilterOrdersCommand { get; set; }
        public IAsyncRelayCommand GetOrderCartCommand { get; set; }
        public ICommand NavigateIngredExpenseCommand { get; set; }
        public IAsyncRelayCommand AddCartOrderCommand { get; set; } 
        
        public OrdersViewModel(GetOrdersUseCase getOrdersUseCase, GetOrderStatusesUseCase getOrdersStatusesUseCase, FilterOrdersByStatus filterOrdersByStatus, GetOrderCartUseCase getOrderCartUseCase, INavigationService navigationService, UpdateOrderStatusUseCase updateOrderStatusUseCase, IDialogService dialogService, UpdateEmployeeInCartOrderUseCase updateEmployeeInCartOrderUseCase)
        {
            this.getOrdersUseCase = getOrdersUseCase;
            this.getOrdersStatusesUseCase = getOrdersStatusesUseCase;
            this.filterOrdersByStatus = filterOrdersByStatus;
            this.getOrderCartUseCase = getOrderCartUseCase;
            this.navigationService = navigationService;
            this.updateOrderStatusUseCase = updateOrderStatusUseCase;
            this.dialogService = dialogService;
            UpdateEmployeeInCartOrderUseCase = updateEmployeeInCartOrderUseCase;

            FilterOrdersCommand = new AsyncRelayCommand(FilterOrders);
            GetOrderCartCommand = new AsyncRelayCommand(GetOrderCart);
            NavigateIngredExpenseCommand = new RelayCommand(NavigateIngredExpense);
            AddCartOrderCommand = new AsyncRelayCommand(AddCartOrder);

            CartOrders = [];
            Orders = [];
            Statuses = [];

            WeakReferenceMessenger.Default.Register<DashboardEmployeeMessenger>(this, (r, m) =>
            {
                employee = m.Value;
                if (m.Value.Position.PositionId == 3)
                {
                    IsChief = Visibility.Visible;
                }
                else
                {
                    IsChief = Visibility.Collapsed;
                }
            });

            GetOrders();
            GetStatuses();
        }

        async Task GetOrders()
        {
            await foreach (var item in getOrdersUseCase.Execute())
                Orders.Add(item);
        }
        async Task GetStatuses()
        {
            await foreach(var item in getOrdersStatusesUseCase.Execute())
                Statuses.Add(item);
            Statuses.Insert(0, new Status(0, "Все"));
        }
        async Task FilterOrders()
        {
            Orders.Clear();
            if (CurrStatus.Id != 0)
            {
                await foreach(var item in filterOrdersByStatus.Execute(CurrStatus.Id))
                    Orders.Add(item);
            }
            else
                await GetOrders();
        }
        async Task GetOrderCart()
        {
            CartOrders.Clear();
            if (CurrOrder != null)
            {
                await foreach (var item in getOrderCartUseCase.Execute(CurrOrder.Id))
                    CartOrders.Add(item);
            }
        }
        void NavigateIngredExpense()
        {
            navigationService.NavigateDashboardTo<IngredExpenseViewModel>();
            WeakReferenceMessenger.Default.Send(new CartOrderMessenger(CartOrders.ToList()));
        }
        async Task AddCartOrder()
        {
            if(await updateOrderStatusUseCase.Execute(CurrOrder.Id) && await UpdateEmployeeInCartOrderUseCase.Execute(CurrOrder.Id, employee.Id))
            {
                Orders.Clear();
                await GetOrders();
            }
            else
            {
                dialogService.OpenDialog(new AlertDialogViewModel("Ошибка", "Не удалось обновить статус заказа"));
            }
        }
    }
}