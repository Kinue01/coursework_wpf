using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using coursework.Domain.Model;
using coursework.Domain.UseCase;
using coursework.UI.Messenger;
using coursework.UI.Service.Interface;
using coursework.UI.Utils;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace coursework.UI.Dialog.ViewModel
{
    class UpdateClientAccViewModel : DialogViewModelBase<DialogResults>
    {
        string lastname, firstname, middlename, login, pass, phone, email, imgpath;
        BitmapImage image;
        IDialogService dialogService;
        User user;
        Client client;
        UpdateClientUseCase UpdateClientUseCase;
        UVerification uVerification;

        public string Firstname
        {
            get => firstname; 
            set => SetProperty(ref firstname, value);
        }
        public string Lastname
        {
            get => lastname;
            set => SetProperty(ref lastname, value);
        }
        public string Middlename
        {
            get => middlename;
            set => SetProperty(ref middlename, value);
        }
        public string Login
        {
            get => login;
            set => SetProperty(ref login, value);
        }
        public string Phone
        {
            get => phone; 
            set => SetProperty(ref phone, value);
        }
        public string Email
        {
            get => email; 
            set => SetProperty(ref email, value);
        }
        public string Password
        {
            get => pass; 
            set => SetProperty(ref pass, value);
        }
        public BitmapImage Image
        {
            get => image; 
            set => SetProperty(ref image, value);
        }

        public IAsyncRelayCommand YesCommand { get; set; }
        public ICommand NoCommand { get; set; }
        public ICommand UpdateImageCommand { get; set; }

        public UpdateClientAccViewModel(IDialogService dialogService, UpdateClientUseCase updateClientUseCase, UVerification uVerification)
        {
            this.dialogService = dialogService;
            this.uVerification = uVerification;
            UpdateClientUseCase = updateClientUseCase;

            YesCommand = new AsyncRelayCommand<IDialogWindow>(Yes);
            NoCommand = new RelayCommand<IDialogWindow>(No);
            UpdateImageCommand = new RelayCommand(UpdateImage);

            WeakReferenceMessenger.Default.Register<UserMessenger>(this, (r, m) =>
            {
                user = m.Value;

                Login = user.Login;
                Phone = user.PhoneNumber;
                Email = user.Email;
                Image = user.Image;
                imgpath = user.imgstr;
            });

            WeakReferenceMessenger.Default.Register<ClientMessenger>(this, (r, m) =>
            {
                client = m.Value;

                Lastname = client.Lastname;
                Firstname = client.Firstname;
                Middlename = client.Middlename;
            });
        }

        async Task Yes(IDialogWindow window)
        {
            if (!await UpdateClientUseCase.Execute(new Client(client.Id, Lastname, Firstname, Middlename, Login, client.RegDate, client.Birthday), new User(Login, uVerification.GetSHA512Hash(Password), Email, Phone, user.Role, imgpath)))
            {
                dialogService.OpenDialog(new AlertDialogViewModel("Ошибка", "Не удалось обновить данные профиля"));
            }
            else
            {
                CloseDialogWithResult(window, DialogResults.Yes);
            }
        }
        void No(IDialogWindow window)
        {
            CloseDialogWithResult(window, DialogResults.No);
        }
        void UpdateImage()
        {
            imgpath = dialogService.OpenFileDialog(imgpath);
        }
    }
}
