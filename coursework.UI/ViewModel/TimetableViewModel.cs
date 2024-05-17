using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using coursework.Domain.Model;
using coursework.Domain.UseCase;
using coursework.UI.Dialog.ViewModel;
using coursework.UI.Messenger;
using coursework.UI.Service.Interface;
using coursework.UI.Utils;
using System.Collections.ObjectModel;
using System.Windows;

namespace coursework.UI.ViewModel
{
    class TimetableViewModel : ObservableObject
    {
        ObservableCollection<Timesheet> timesheets;
        GetTimesheetUseCase GetTimesheetUseCase;
        DeleteTimesheetUseCase DeleteTimesheetUseCase;
        IDialogService dialogService;
        Timesheet currTimesheet;
        ObservableCollection<Employee> employees;
        Employee currEmployee;
        GetEmployeesUseCase GetEmployeesUseCase;
        FilterTimesheetByEmployeeUseCase FilterTimesheetByEmployeeUseCase;
        AddTimesheetViewModel AddTimesheetViewModel;
        Visibility isManager;

        public ObservableCollection<Timesheet> Timesheets
        {
            get => timesheets;
            set => SetProperty(ref timesheets, value);
        }
        public Timesheet CurrTimesheet
        {
            get => currTimesheet;
            set => SetProperty(ref currTimesheet, value);
        }
        public Employee CurrEmployee
        {
            get => currEmployee;
            set => SetProperty(ref currEmployee, value);
        }
        public ObservableCollection<Employee> Employees
        {
            get => employees;
            set => SetProperty(ref employees, value);
        }
        public Visibility IsManager
        {
            get => isManager;
            set => SetProperty(ref isManager, value);
        }

        public IAsyncRelayCommand DeleteCommand { get; set; }
        public IAsyncRelayCommand AddTimesheetCommand { get; set; }
        public IAsyncRelayCommand FilterByEmpCommand { get; set; }

        public TimetableViewModel(GetTimesheetUseCase getTimesheetUseCase, DeleteTimesheetUseCase deleteTimesheetUseCase, IDialogService dialogService, GetEmployeesUseCase getEmployeesUseCase, FilterTimesheetByEmployeeUseCase filterTimesheetByEmployeeUseCase, AddTimesheetViewModel addTimesheetViewModel)
        {
            GetTimesheetUseCase = getTimesheetUseCase;
            DeleteTimesheetUseCase = deleteTimesheetUseCase;
            this.dialogService = dialogService;
            GetEmployeesUseCase = getEmployeesUseCase;
            FilterTimesheetByEmployeeUseCase = filterTimesheetByEmployeeUseCase;
            AddTimesheetViewModel = addTimesheetViewModel;

            DeleteCommand = new AsyncRelayCommand(Delete);
            FilterByEmpCommand = new AsyncRelayCommand(FilterByEmp);
            AddTimesheetCommand = new AsyncRelayCommand(AddTimesheet);

            WeakReferenceMessenger.Default.Register<DashboardEmployeeMessenger>(this, (r, m) =>
            {
                if (m.Value.Position.PositionId == 3)
                {
                    IsManager = Visibility.Collapsed;
                }
                else
                {
                    IsManager = Visibility.Visible;
                }
            });

            Task.Run(GetEmps);
            Task.Run(GetTimesheet);
        }

        async Task GetTimesheet()
        {
            Timesheets = [];
            await foreach(var item in GetTimesheetUseCase.Execute())
                Timesheets.Add(item);
        }
        async Task Delete()
        {
            if (CurrTimesheet != null)
            {
                var res = dialogService.OpenDialog(new DeleteDialogViewModel("Удаление расписания", $"Вы точно хотите удалить расписание сотрудника №{CurrTimesheet.Employee.Id}"));
                if (res == DialogResults.Yes)
                {
                    if (await DeleteTimesheetUseCase.Execute(CurrTimesheet) == true)
                    {
                        await GetTimesheet();
                    }
                    else
                    {
                        dialogService.OpenDialog(new AlertDialogViewModel("Ошибка", "Не удалось удалить расписание"));
                    }
                }
            }
            else
            {
                dialogService.OpenDialog(new AlertDialogViewModel("Ошибка", "Выберите расписание"));
            }
            
        }
        async Task GetEmps()
        {
            Employees = [];
            Employees.Add(new Employee(0, "Все", "", "", "", "", 0, "", new Position(0, "", 0), DateTime.MinValue, DateOnly.MinValue, "", new Workshop(0, "", null, "", 0)));
            await foreach (var item in GetEmployeesUseCase.Execute())
                Employees.Add(item);
        }
        async Task FilterByEmp()
        {
            Timesheets.Clear();
            if (CurrEmployee.Id != 0)
            {
                await foreach (var item in FilterTimesheetByEmployeeUseCase.Execute(CurrEmployee.Id))
                    Timesheets.Add(item);
            }
            else
            {
                await GetTimesheet();
            }
        }
        async Task AddTimesheet()
        {
            var res = dialogService.OpenDialog(AddTimesheetViewModel);
            if (res == DialogResults.Yes)
            {
                await GetTimesheet();
            }
        }
    }
}