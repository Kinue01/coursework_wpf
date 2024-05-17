using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using coursework.Domain.Model;
using coursework.Domain.UseCase;
using coursework.UI.Messenger;
using coursework.UI.Service.Interface;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace coursework.UI.ViewModel
{
    internal class MainViewVM : ObservableObject
    {
        Client client;
        Employee employee;
        GetEmployeeUseCase getEmployeeUseCase;
        GetClientUseCase getClientUseCase;
        INavigationService navigationService;
        string visibility, fio;
        BitmapImage img;
        User user;

        public Client Client
        {
            get => client;
            set => SetProperty(ref client, value);
        }
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
        public string Visibility
        {
            get => visibility;
            set => SetProperty(ref visibility, value);
        }
        public string Fio
        {
            get => fio;
            set => SetProperty(ref fio, value);
        }
        public BitmapImage Image
        {
            get => img;
            set => SetProperty(ref img, value);
        }

        public ICommand NavigateHomeCommand { get; set; }
        public ICommand NavigateAccountCommand { get; set; }
        public ICommand NavigateSettingsCommand { get; set; }
        public ICommand NavigateDashboardCommand { get; set; }
        public ICommand AlertCommand { get; set; }
        public ICommand YesNoCommand { get; set; }
        public ICommand NavigateLoginCommand { get; set; }

        public MainViewVM(GetClientUseCase getClientUseCase, GetEmployeeUseCase getEmployeeUseCase, INavigationService navigationService) 
        {
            this.getClientUseCase = getClientUseCase;
            this.getEmployeeUseCase = getEmployeeUseCase;
            NavigationService = navigationService;

            NavigateHomeCommand = new RelayCommand(NavigateProds);
            NavigateSettingsCommand = new RelayCommand(NavigationService.NavigateMainTo<SettingsViewModel>);
            NavigateAccountCommand = new RelayCommand(NavigateAccount);
            NavigateDashboardCommand = new RelayCommand(NavigateDashboard);
            NavigateLoginCommand = new RelayCommand(NavigateLogin);

            WeakReferenceMessenger.Default.Register<UserMessenger>(this, async (r, m) =>
            {
                Image = m.Value.Image;
                user = m.Value;

                if (m.Value.Role == 1)
                {
                    Client = await this.getClientUseCase.Execute(m.Value.Login);
                    Visibility = "Hidden";
                    Fio = Client.Lastname + " " + Client.Firstname + " " + Client.Middlename;
                }
                else
                {
                    Employee = await this.getEmployeeUseCase.Execute(m.Value.Login);
                    Visibility = "Visible";
                    Fio = Employee.Lastname + " " + Employee.Firstname + " " + Employee.Middlename;
                }
            });

            NavigationService.NavigateMainTo<ProductsViewModel>();
        }

        void NavigateAccount()
        {
            if (Client != null)
            {
                NavigationService.NavigateMainTo<AccountViewModel>();
                WeakReferenceMessenger.Default.Send(new ClientMessenger(Client));
                WeakReferenceMessenger.Default.Send(new UserMessenger(user));
            }
            else
            {
                NavigationService.NavigateMainTo<EmpAccountViewModel>();
                WeakReferenceMessenger.Default.Send(new EmployeeMessenger(Employee));
                WeakReferenceMessenger.Default.Send(new UserMessenger(user));
            }
        }

        void NavigateDashboard()
        {
            NavigationService.NavigateMainTo<DashboardViewModel>();
            WeakReferenceMessenger.Default.Send(new DashboardEmployeeMessenger(Employee));
        }
        void NavigateProds()
        {
            NavigationService.NavigateMainTo<ProductsViewModel>();
            WeakReferenceMessenger.Default.Send(new ClientMessenger(Client));
        }
        void NavigateLogin()
        {
            NavigationService.NavigateTo<LoginViewModel>();
            Client = null;
            Employee = null;
        }
    }
}
