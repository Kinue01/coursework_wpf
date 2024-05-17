using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using coursework.Domain.Model;
using coursework.Domain.UseCase;
using coursework.UI.Dialog.ViewModel;
using coursework.UI.Service.Interface;
using coursework.UI.Utils;
using System.Windows.Input;

namespace coursework.UI.ViewModel
{
    internal class RegistrationViewModel : ObservableObject
    {
        string fname, lname, mname, login, password, passrepeat, email, phone;
        DateTime birthday;
        AddClientUseCase addClientUseCase;
        INavigationService navigationService; 
        UVerification hash;
        IDialogService dialogService;

        public string Firstname
        {
            get => fname;
            set => SetProperty(ref fname, value);
        }
        public string Lastname
        {
            get => lname;
            set => SetProperty(ref lname, value);
        }
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }
        public string PassRepeat
        {
            get => passrepeat; 
            set => SetProperty(ref passrepeat, value);
        }
        public string Email
        {
            get => email; 
            set => SetProperty(ref email, value);
        }
        public string Login
        {
            get => login; 
            set => SetProperty(ref login, value);
        }
        public string Middlename
        {
            get => mname; 
            set => SetProperty(ref mname, value);
        }
        public DateTime Birthday
        {
            get => birthday; 
            set => SetProperty(ref birthday, value);
        }
        public INavigationService NavigationService
        {
            get => navigationService;
            set => SetProperty(ref navigationService, value);
        }
        public string Phone
        {
            get => phone;
            set => SetProperty(ref phone, value);
        }

        public IAsyncRelayCommand AddClientCommand { get; set; }
        public ICommand NavigateLoginCommand { get; set; }

        public RegistrationViewModel(AddClientUseCase addClientUseCase, INavigationService navigationService, UVerification hash, IDialogService dialogService)
        {
            this.addClientUseCase = addClientUseCase;
            this.hash = hash;
            NavigationService = navigationService;
            this.dialogService = dialogService;

            AddClientCommand = new AsyncRelayCommand(AddClient);
            NavigateLoginCommand = new RelayCommand(NavigationService.NavigateTo<LoginViewModel>);
        }

        async Task AddClient()
        {
            if (Password == PassRepeat)
            {
                string passhash = hash.GetSHA512Hash(Password);
                if (await addClientUseCase.Execute(new Client(0, Lastname, Firstname, Middlename, Login, DateOnly.FromDateTime(DateTime.Now), DateOnly.FromDateTime(Birthday)), new User(Login, passhash, Email, Phone, 0, "default.png")))
                {
                    NavigationService.NavigateTo<LoginViewModel>();
                }
                else
                {
                    dialogService.OpenDialog(new AlertDialogViewModel("Ошибка", "При регистрации произошла ошибка. Проверьте написание в поле Email."));
                }
            }
        }
    }
}
