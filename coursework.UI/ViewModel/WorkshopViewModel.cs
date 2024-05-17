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
    class WorkshopViewModel : ObservableObject
    {
        ObservableCollection<Workshop> workshops;
        GetWorkshopsUseCase GetWorkshopsUseCase;
        Workshop currWorkshop;
        IDialogService dialogService;
        DeleteWorkshopUseCase DeleteWorkshopUseCase;
        AddWorkshopViewModel AddWorkshopViewModel;
        UpdateWorkshopViewModel UpdateWorkshopViewModel;
        Visibility isAdmin;

        public ObservableCollection<Workshop> Workshops
        {
            get => workshops;
            set => SetProperty(ref workshops, value);
        }
        public Workshop CurrWorkshop
        {
            get => currWorkshop;
            set => SetProperty(ref currWorkshop, value);
        }
        public Visibility IsAdmin
        {
            get => isAdmin;
            set => SetProperty(ref isAdmin, value);
        }

        public IAsyncRelayCommand DeleteWorkshopCommand { get; set; }
        public IAsyncRelayCommand AddWorkshopCommand { get; set; }
        public IAsyncRelayCommand UpdateWorkshopCommand { get; set; }

        public WorkshopViewModel(GetWorkshopsUseCase getWorkshopsUseCase, IDialogService dialogService, AddWorkshopViewModel addWorkshopViewModel, UpdateWorkshopViewModel updateWorkshopViewModel, DeleteWorkshopUseCase deleteWorkshopUseCase)
        {
            GetWorkshopsUseCase = getWorkshopsUseCase;
            this.dialogService = dialogService;
            AddWorkshopViewModel = addWorkshopViewModel;
            UpdateWorkshopViewModel = updateWorkshopViewModel;
            DeleteWorkshopUseCase = deleteWorkshopUseCase;

            DeleteWorkshopCommand = new AsyncRelayCommand(DeleteWorkshop);
            AddWorkshopCommand = new AsyncRelayCommand(AddWorkshop);
            UpdateWorkshopCommand = new AsyncRelayCommand(UpdateWorkshop);

            WeakReferenceMessenger.Default.Register<DashboardEmployeeMessenger>(this, (r, m) =>
            {
                if (m.Value.Position.PositionId == 1 || m.Value.Position.PositionId == 2)
                {
                    IsAdmin = Visibility.Visible;
                }
                else
                {
                    IsAdmin = Visibility.Collapsed;
                }
            });

            Task.Run(GetWorkshops);
        }

        async Task GetWorkshops()
        {
            Workshops = [];
            await foreach(var item in GetWorkshopsUseCase.Execute())
                Workshops.Add(item);
        }
        async Task DeleteWorkshop()
        {
            if (CurrWorkshop != null)
            {
                var res = dialogService.OpenDialog(new DeleteDialogViewModel("Удаление цеха", $"Вы точно хотите удалить {CurrWorkshop.WorkshopName}"));
                if (res == Utils.DialogResults.Yes)
                {
                    if (await DeleteWorkshopUseCase.Execute(CurrWorkshop) == true)
                    {
                        await GetWorkshops();
                    }
                    else
                    {
                        dialogService.OpenDialog(new AlertDialogViewModel("Ошибка", "Не удалось удалить цех"));
                    }
                }
            }
            else
            {
                dialogService.OpenDialog(new AlertDialogViewModel("Ошибка", "Выберите цех"));
            }
        }
        async Task AddWorkshop()
        {
            var res = dialogService.OpenDialog(AddWorkshopViewModel);
            if (res == Utils.DialogResults.Yes)
            {
                await GetWorkshops();
            }
        }
        async Task UpdateWorkshop()
        {
            WeakReferenceMessenger.Default.Send(new WorkshopMessenger(CurrWorkshop));
            var res = dialogService.OpenDialog(UpdateWorkshopViewModel);

            if (res == Utils.DialogResults.Yes)
            {
                await GetWorkshops();
            }
        }
    }
}
