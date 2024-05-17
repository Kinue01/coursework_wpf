using CommunityToolkit.Mvvm.Input;
using coursework.Domain.Model;
using coursework.Domain.UseCase;
using coursework.UI.Service.Interface;
using coursework.UI.Utils;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace coursework.UI.Dialog.ViewModel
{
    internal class AddTimesheetViewModel : DialogViewModelBase<DialogResults>
    {
        ObservableCollection<Employee> employees;
        Employee currEmp;
        DateTime start, end;
        AddTimesheetUseCase AddTimesheetUseCase;
        GetEmployeesUseCase GetEmployeesUseCase;
        IDialogService dialogService;

        public ObservableCollection<Employee> Employees
        {
            get => employees;
            set => SetProperty(ref employees, value);
        }
        public Employee CurrEmployee
        {
            get => currEmp;
            set => SetProperty(ref currEmp, value);
        }
        public DateTime Start
        {
            get => start; 
            set => SetProperty(ref start, value);
        }
        public DateTime End
        {
            get => end; 
            set => SetProperty(ref end, value);
        }

        public IAsyncRelayCommand YesCommand { get; set; }
        public ICommand NoCommand { get; set; }

        public AddTimesheetViewModel(AddTimesheetUseCase addTimesheetUseCase, GetEmployeesUseCase getEmployeesUseCase, IDialogService dialogService)
        {
            AddTimesheetUseCase = addTimesheetUseCase;
            GetEmployeesUseCase = getEmployeesUseCase;
            this.dialogService = dialogService;

            YesCommand = new AsyncRelayCommand<IDialogWindow>(Yes);
            NoCommand = new RelayCommand<IDialogWindow>(No);

            Employees = [];

            Task.Run(GetEmps);
        }

        async Task Yes(IDialogWindow window)
        {
            if (CurrEmployee != null)
            {
                if (!await AddTimesheetUseCase.Execute(new Timesheet(CurrEmployee, Start, End)))
                {
                    dialogService.OpenDialog(new AlertDialogViewModel("Ошибка", $"Не удалось добавить расписание для сотрудника №{CurrEmployee.Id}"));
                }
                else
                {
                    CloseDialogWithResult(window, DialogResults.Yes);
                }
            }
            else
            {
                dialogService.OpenDialog(new AlertDialogViewModel("Ошибка", "Выберите сотрудника"));
            }
        }
        void No(IDialogWindow window)
        {
            CloseDialogWithResult(window, DialogResults.No);
        }
        async Task GetEmps()
        {
            await foreach(var item in GetEmployeesUseCase.Execute())
                Employees.Add(item);
        }
    }
}
