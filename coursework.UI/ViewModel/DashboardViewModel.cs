using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using coursework.Domain.Model;
using coursework.UI.Messenger;
using coursework.UI.Service.Interface;
using System.Windows;
using System.Windows.Input;

namespace coursework.UI.ViewModel
{
    class DashboardViewModel : ObservableObject
    {
        Employee employee;
        INavigationService navigationService;
        Visibility isChef, isManager, isAdmin, isWorkshopHead;

        public Employee Employee
        {
            get => employee; 
            set => SetProperty(ref employee, value);
        }
        public INavigationService NavigationService
        {
            get => navigationService;
            set => SetProperty(ref navigationService, value);
        }
        public Visibility IsManager
        {
            get => isManager;
            set => SetProperty(ref isManager, value);
        }
        public Visibility IsChef
        {
            get => isChef;
            set => SetProperty(ref isChef, value);
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

        public ICommand NavigateOrdersCommand { get; set; }
        public ICommand NavigateProductsCommand { get; set; }
        public ICommand NavigateIngredsCommand { get; set; }
        public ICommand NavigateEmpsCommand { get; set; }
        public ICommand NavigateSuppliersCommand { get; set; }
        public ICommand NavigateClientsCommand { get; set; }
        public ICommand NavigateTimetableCommand { get; set; }
        public ICommand NavigateWarehousesCommand { get; set; }

        public DashboardViewModel(INavigationService navigationService)
        {
            WeakReferenceMessenger.Default.Register<DashboardEmployeeMessenger>(this, (r, m) =>
            {
                Employee = m.Value;
                if (Employee.Position.PositionId == 3)
                {
                    IsChef = Visibility.Visible;
                    IsManager = Visibility.Collapsed;
                    IsAdmin = Visibility.Collapsed;
                    IsWorkshopHead = Visibility.Collapsed;
                }
                else if (Employee.Position.PositionId == 4)
                {
                    IsChef = Visibility.Visible;
                    IsManager = Visibility.Visible;
                    IsAdmin = Visibility.Collapsed;
                    IsWorkshopHead = Visibility.Collapsed;
                }
                else if (Employee.Position.PositionId == 5)
                {
                    IsChef = Visibility.Visible;
                    IsManager = Visibility.Visible;
                    IsAdmin = Visibility.Collapsed;
                    IsWorkshopHead = Visibility.Visible;
                }
                else
                {
                    IsChef = Visibility.Visible;
                    IsManager = Visibility.Visible;
                    IsAdmin = Visibility.Visible;
                    IsWorkshopHead = Visibility.Visible;
                }
            });
            NavigationService = navigationService;

            NavigateOrdersCommand = new RelayCommand(NavigateOrders);
            NavigateProductsCommand = new RelayCommand(NavigateProdcut);
            NavigateIngredsCommand = new RelayCommand(NavigateIngredient);
            NavigateEmpsCommand = new RelayCommand(NavigateEmployees);
            NavigateSuppliersCommand = new RelayCommand(NavigateSupplier);
            NavigateClientsCommand = new RelayCommand(NavigateClients);
            NavigateTimetableCommand = new RelayCommand(NavigateTimetable);
            NavigateWarehousesCommand = new RelayCommand(NavigateWarehouse);
        }

        void NavigateProdcut()
        {
            NavigationService.NavigateDashboardTo<EmpProdsViewModel>();
            WeakReferenceMessenger.Default.Send(new DashboardEmployeeMessenger(employee));
        }
        void NavigateIngredient()
        {
            NavigationService.NavigateDashboardTo<IngredsViewModel>();
            WeakReferenceMessenger.Default.Send(new DashboardEmployeeMessenger(employee));
        }
        void NavigateEmployees()
        {
            NavigationService.NavigateDashboardTo<EmployeesViewModel>();
            WeakReferenceMessenger.Default.Send(new DashboardEmployeeMessenger(employee));
        }
        void NavigateSupplier()
        {
            NavigationService.NavigateDashboardTo<SuppliersViewModel>();
            WeakReferenceMessenger.Default.Send(new DashboardEmployeeMessenger(employee));
        }
        void NavigateClients()
        {
            NavigationService.NavigateDashboardTo<ClientsViewModel>();
            WeakReferenceMessenger.Default.Send(new DashboardEmployeeMessenger(employee));
        }
        void NavigateTimetable()
        {
            NavigationService.NavigateDashboardTo<TimetableViewModel>();
            WeakReferenceMessenger.Default.Send(new DashboardEmployeeMessenger(employee));
        }
        void NavigateWarehouse()
        {
            NavigationService.NavigateDashboardTo<WorkshopViewModel>();
            WeakReferenceMessenger.Default.Send(new DashboardEmployeeMessenger(employee));
        }
        void NavigateOrders()
        {
            NavigationService.NavigateDashboardTo<OrdersViewModel>();
            WeakReferenceMessenger.Default.Send(new DashboardEmployeeMessenger(employee));
        }
    }
}
