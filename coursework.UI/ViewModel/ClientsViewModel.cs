using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using coursework.Domain.Model;
using coursework.Domain.UseCase;
using coursework.UI.Dialog.ViewModel;
using coursework.UI.Service.Interface;
using System.Collections.ObjectModel;

namespace coursework.UI.ViewModel
{
    class ClientsViewModel : ObservableObject
    {
        ObservableCollection<Client> clients;
        GetClientsUseCase getClientsUseCase;
        string queryFio;
        DateTime queryBirthday;
        FilterClientsByBirthdayUseCase filterClientsByBirthdayUseCase;
        FilterClientsByFioUseCase filterClientsByFioUseCase;
        IDialogService dialogService;
        Client currClient;
        DeleteClientUseCase deleteClientUseCase;

        public ObservableCollection<Client> Clients
        {
            get => clients;
            set => SetProperty(ref clients, value);
        }
        public DateTime QueryBirthday
        {
            get => queryBirthday;
            set => SetProperty(ref queryBirthday, value);
        }
        public string QueryFio
        {
            get => queryFio;
            set => SetProperty(ref queryFio, value);
        }
        public Client CurrClient
        {
            get => currClient;
            set => SetProperty(ref currClient, value);
        }

        public IAsyncRelayCommand FilterByFio { get; set; }
        public IAsyncRelayCommand FilterByBirthday { get; set; }
        public IAsyncRelayCommand DeleteClientCommand { get; set; }

        public ClientsViewModel(GetClientsUseCase getClientsUseCase, FilterClientsByBirthdayUseCase filterClientsByBirthdayUseCase, FilterClientsByFioUseCase filterClientsByFioUseCase, IDialogService dialogService, DeleteClientUseCase deleteClientUseCase)
        {
            this.getClientsUseCase = getClientsUseCase;
            this.filterClientsByBirthdayUseCase = filterClientsByBirthdayUseCase;
            this.filterClientsByFioUseCase = filterClientsByFioUseCase;
            this.dialogService = dialogService;
            this.deleteClientUseCase = deleteClientUseCase;

            FilterByFio = new AsyncRelayCommand(FilterFio);
            FilterByBirthday = new AsyncRelayCommand(FilterBirthday);
            DeleteClientCommand = new AsyncRelayCommand(DeleteClient);

            Task.Run(GetClients);
        }

        async Task GetClients()
        {
            Clients = [];
            await foreach (var item in getClientsUseCase.Execute())
                Clients.Add(item);
        }
        async Task FilterFio()
        {
            Clients.Clear();
            if (QueryFio != "")
            {
                await foreach (var item in filterClientsByFioUseCase.Execute(QueryFio))
                    Clients.Add(item);
            } 
            else
                await GetClients();
        }
        async Task FilterBirthday()
        {
            Clients.Clear();
            if (QueryBirthday != null && QueryBirthday != DateTime.MinValue)
            {
                await foreach (var item in filterClientsByBirthdayUseCase.Execute(DateOnly.FromDateTime(QueryBirthday)))
                    Clients.Add(item);
            }
            else
                await GetClients();
        }
        async Task DeleteClient()
        {
            if (CurrClient != null)
            {
                var res = dialogService.OpenDialog(new DeleteDialogViewModel("Удаление клиента", $"Вы точно хотите удалить клиента №{CurrClient.Id}"));
                if (res == Utils.DialogResults.Yes)
                {
                    if (await deleteClientUseCase.Execute(CurrClient))
                    {
                        await GetClients();
                    }
                    else
                    {
                        dialogService.OpenDialog(new AlertDialogViewModel("Ошибка", $"Не удалось удалить клиента №{CurrClient.Id}"));
                    }
                }
            }
            else
            {
                dialogService.OpenDialog(new AlertDialogViewModel("Ошибка", "Выберите клиента"));
            }
        }
    }
}
