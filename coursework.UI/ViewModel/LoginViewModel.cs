using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using coursework.Domain.Model;
using coursework.Domain.UseCase;
using coursework.UI.Dialog.ViewModel;
using coursework.UI.Messenger;
using coursework.UI.Service.Interface;
using System.Windows.Input;

namespace coursework.UI.ViewModel
{
    internal class LoginViewModel : ObservableObject
    {
        string login, password;
        GetUserUseCase getUserUseCase;
        User user;
        INavigationService navigationService;
        IDialogService dialogService;

        public string Login
        {
            get => login; 
            set => SetProperty(ref login, value);
        }
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }
        public User User
        {
            get => user;
            set => SetProperty(ref user, value);
        }
        public INavigationService NavigationService
        {
            get => navigationService;
            set => SetProperty(ref navigationService, value);
        }

        public IAsyncRelayCommand GetUserCommand { get; set; }
        public ICommand NavigateRegCommand { get; set; }

        public LoginViewModel(GetUserUseCase getUserUseCase, INavigationService navigationService, IDialogService dialogService)
        {
            this.getUserUseCase = getUserUseCase;
            NavigationService = navigationService;
            this.dialogService = dialogService;

            GetUserCommand = new AsyncRelayCommand(GetUser);
            NavigateRegCommand = new RelayCommand(NavigationService.NavigateTo<RegistrationViewModel>);
        }

        async Task GetUser()
        {
            User = await getUserUseCase.Execute(Login, Password);

            if (User != null)
            {
                NavigationService.NavigateTo<MainViewVM>();
                NavigationService.NavigateMainTo<ProductsViewModel>();
                WeakReferenceMessenger.Default.Send(new UserMessenger(User));
            }
            else
            {
                dialogService.OpenDialog(new AlertDialogViewModel("Ошибка", "Пароли не совпадают"));
            }
        }
    }
}
