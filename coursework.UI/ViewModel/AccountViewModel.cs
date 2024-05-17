using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using coursework.Domain.Model;
using coursework.Domain.UseCase;
using coursework.UI.Dialog.ViewModel;
using coursework.UI.Messenger;
using coursework.UI.Service.Interface;

namespace coursework.UI.ViewModel
{
    class AccountViewModel : ObservableObject
    {
        Client client;
        string fio;
        User user;
        IDialogService dialogService;
        UpdateClientAccViewModel UpdateClientAccViewModel;
        GetUserByLoginUseCase GetUserByLoginUseCase;
        GetClientByIdUseCase GetClientByIdUseCase;

        public Client Client
        {
            get => client; 
            set => SetProperty(ref client, value);
        }
        public string Fio
        {
            get => fio;
            set => SetProperty(ref fio, value);
        }
        public User User
        {
            get => user;
            set => SetProperty(ref user, value);
        }

        public IAsyncRelayCommand UpdateClientDataCommand { get; set; }

        public AccountViewModel(IDialogService dialogService, UpdateClientAccViewModel updateClientAccViewModel, GetClientByIdUseCase getClientByIdUseCase, GetUserByLoginUseCase getUserByLoginUseCase)
        {
            this.dialogService = dialogService;
            UpdateClientAccViewModel = updateClientAccViewModel;
            GetClientByIdUseCase = getClientByIdUseCase;
            GetUserByLoginUseCase = getUserByLoginUseCase;

            UpdateClientDataCommand = new AsyncRelayCommand(UpdateClientData);

            WeakReferenceMessenger.Default.Register<ClientMessenger>(this, (r, m) =>
            {
                Client = m.Value;
                Fio = Client.Lastname + " " + Client.Firstname + " " + Client.Middlename;
            });
            WeakReferenceMessenger.Default.Register<UserMessenger>(this, (r, m) =>
            {
                User = m.Value;
            });
        }

        async Task UpdateClientData()
        {
            WeakReferenceMessenger.Default.Send(new UserMessenger(User));
            WeakReferenceMessenger.Default.Send(new ClientMessenger(Client));

            var res = dialogService.OpenDialog(UpdateClientAccViewModel);
            if (res == Utils.DialogResults.Yes)
            {
                User = await GetUserByLoginUseCase.Execute(User.Login);
                Client = await GetClientByIdUseCase.Execute(Client.Id);
            }
        }
    }
}
