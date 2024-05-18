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
    class EmployeesViewModel : ObservableObject
    {
        ObservableCollection<Employee> employees;
        GetEmployeesUseCase getEmployeesUseCase;
        string queryFio;
        DateTime queryBirthday;
        FilterEmployeesByBirthdayUseCase filterEmployeesByBirthdayUseCase;
        FilterEmployeesByFioUseCase filterEmployeesByFioUseCase;
        INavigationService navigationService;
        IDialogService dialogService;
        Employee currEmp;
        DeleteEmployeeUseCase deleteEmployeeUseCase;
        UpdateEmployeeViewModel updateEmployeeViewModel;
        Visibility isWorkshopHead;

        public ObservableCollection<Employee> Employees
        {
            get => employees;
            set => SetProperty(ref employees, value);
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
        public INavigationService NavigationService
        {
            get => navigationService;
            set => SetProperty(ref navigationService, value);
        }
        public Employee CurrEmp
        {
            get => currEmp;
            set => SetProperty(ref currEmp, value);
        }
        public Visibility IsWorkshopHead
        {
            get => isWorkshopHead;
            set => SetProperty(ref isWorkshopHead, value);
        }

        public IAsyncRelayCommand FilterFioCommand { get; set; }
        public IAsyncRelayCommand FilterBirthCommand { get; set; }
        public ICommand NavigateAddEmpCommand { get; set; }
        public IAsyncRelayCommand DeleteDialogCommand { get; set; }
        public IAsyncRelayCommand UpdateEmplCommand { get; set; }

        public EmployeesViewModel(GetEmployeesUseCase getEmployeesUseCase, FilterEmployeesByBirthdayUseCase filterEmployeesByBirthdayUseCase, FilterEmployeesByFioUseCase filterEmployeesByFioUseCase, INavigationService navigationService, IDialogService dialogService, DeleteEmployeeUseCase deleteEmployeeUseCase, UpdateEmployeeViewModel updateEmployeeViewModel)
        {
            this.getEmployeesUseCase = getEmployeesUseCase;
            this.filterEmployeesByBirthdayUseCase = filterEmployeesByBirthdayUseCase;
            this.filterEmployeesByFioUseCase = filterEmployeesByFioUseCase;
            NavigationService = navigationService;
            this.dialogService = dialogService;
            this.deleteEmployeeUseCase = deleteEmployeeUseCase;
            this.updateEmployeeViewModel = updateEmployeeViewModel;

            FilterBirthCommand = new AsyncRelayCommand(FilterBirthday);
            FilterFioCommand = new AsyncRelayCommand(FilterFio);
            NavigateAddEmpCommand = new RelayCommand(NavigationService.NavigateDashboardTo<AddEmployeeViewModel>);
            DeleteDialogCommand = new AsyncRelayCommand(DeleteDialog);
            UpdateEmplCommand = new AsyncRelayCommand(UpdateEmpl);

            WeakReferenceMessenger.Default.Register<DashboardEmployeeMessenger>(this, (r, m) =>
            {
                if (m.Value.Position.PositionId == 5)
                {
                    IsWorkshopHead = Visibility.Visible;
                }
                else if (m.Value.Position.PositionId == 3 || m.Value.Position.PositionId == 4)
                {
                    IsWorkshopHead = Visibility.Collapsed;
                }
                else
                {
                    IsWorkshopHead = Visibility.Visible;
                }
            });

            GetEmps();
        }

        async Task GetEmps()
        {
            Employees = [];
            await foreach (var item in getEmployeesUseCase.Execute())
                Employees.Add(item);
        }
        async Task FilterFio()
        {
            Employees.Clear();
            if (QueryFio != "")
            {
                await foreach(var item in filterEmployeesByFioUseCase.Execute(QueryFio))
                    Employees.Add(item);
            }
                
            else
                await GetEmps();
        }
        async Task FilterBirthday()
        {
            Employees.Clear();
            if (QueryBirthday != DateTime.MinValue)
            {
                await foreach (var item in filterEmployeesByBirthdayUseCase.Execute(DateOnly.FromDateTime(QueryBirthday)))
                    Employees.Add(item);
            }
            else
                await GetEmps();
        }
        async Task DeleteDialog()
        {
            if (CurrEmp != null)
            {
                var res = dialogService.OpenDialog(new DeleteDialogViewModel("Удаление сотрудника", $"Вы точно хотите удалить сотрудника №{CurrEmp.Id}"));
                if (res == Utils.DialogResults.Yes)
                {
                    if (await deleteEmployeeUseCase.Execute(CurrEmp.Id))
                    {
                        await GetEmps();
                    }
                    else
                    {
                        dialogService.OpenDialog(new AlertDialogViewModel("Ошибка", $"Не удалось удалить сотрудника №{CurrEmp.Id}"));
                    }
                }
            }
            else
            {
                dialogService.OpenDialog(new AlertDialogViewModel("Ошибка", "Выберите сотрудника"));
            }
        }
        async Task UpdateEmpl()
        {
            WeakReferenceMessenger.Default.Send(new EmployeeMessenger(CurrEmp));
            var res = dialogService.OpenDialog(updateEmployeeViewModel);

            if (res == Utils.DialogResults.Yes)
            {
                await GetEmps();
            }
        }
    }
}
