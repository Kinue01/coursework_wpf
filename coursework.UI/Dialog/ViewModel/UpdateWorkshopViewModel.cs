using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using coursework.Domain.Model;
using coursework.Domain.UseCase;
using coursework.UI.Messenger;
using coursework.UI.Service.Interface;
using coursework.UI.Utils;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace coursework.UI.Dialog.ViewModel
{
    internal class UpdateWorkshopViewModel : DialogViewModelBase<DialogResults>
    {
        ObservableCollection<Employee> employees;
        Employee currEmployee;
        string name;
        GetUserByLoginUseCase GetUserByLoginUseCase;
        UpdateWorkshopUseCase UpdateWorkshopUseCase;
        Workshop workshop;
        GetEmployeesUseCase GetEmployeesUseCase;
        int currInd;
        IDialogService dialogService;

        public ObservableCollection<Employee> Employees
        {
            get => employees;
            set => SetProperty(ref employees, value);
        }
        public Employee CurrEmployee
        {
            get => currEmployee;
            set => SetProperty(ref currEmployee, value);
        }
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
        public int CurrInd
        {
            get => currInd;
            set => SetProperty(ref currInd, value);
        }

        public IAsyncRelayCommand YesCommand { get; set; }
        public ICommand NoCommand { get; set; }

        public UpdateWorkshopViewModel(GetUserByLoginUseCase getUserByLoginUseCase, UpdateWorkshopUseCase updateWorkshopUseCase, GetEmployeesUseCase getEmployeesUseCase, IDialogService dialogService)
        {
            GetUserByLoginUseCase = getUserByLoginUseCase;
            UpdateWorkshopUseCase = updateWorkshopUseCase;
            GetEmployeesUseCase = getEmployeesUseCase;
            this.dialogService = dialogService;

            WeakReferenceMessenger.Default.Register<WorkshopMessenger>(this, async (r, m) =>
            {
                await GetEmps();

                workshop = m.Value;

                Name = workshop.WorkshopName;
                CurrEmployee = workshop.WorkshopChief;
            });

            NoCommand = new RelayCommand<IDialogWindow>(No);
            YesCommand = new AsyncRelayCommand<IDialogWindow>(Yes);
        }

        async Task Yes(IDialogWindow window)
        {
            var user = await GetUserByLoginUseCase.Execute(CurrEmployee.Login);
            if (user != null)
            {
                if (!await UpdateWorkshopUseCase.Execute(new Workshop(workshop.WorkshopId, Name, CurrEmployee, user.PhoneNumber, workshop.WorkshopStaffCount)))
                {
                    dialogService.OpenDialog(new AlertDialogViewModel("Ошибка", $"Не удалось обновить цех {workshop.WorkshopName}"));
                }
                else
                {
                    CloseDialogWithResult(window, DialogResults.Yes);
                }
            }
            else
            {
                dialogService.OpenDialog(new AlertDialogViewModel("Ошибка", "Такого пользователя не существует"));
            }
        }
        void No(IDialogWindow window)
        {
            CloseDialogWithResult(window, DialogResults.No);
        }
        async Task GetEmps()
        {
            Employees = [];
            await foreach (var item in GetEmployeesUseCase.Execute())
                Employees.Add(item);
        }
    }
}
