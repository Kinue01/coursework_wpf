using CommunityToolkit.Mvvm.Input;
using coursework.Domain.Model;
using coursework.Domain.UseCase;
using coursework.UI.Service.Interface;
using coursework.UI.Utils;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace coursework.UI.Dialog.ViewModel
{
    internal class AddWorkshopViewModel : DialogViewModelBase<DialogResults>
    {
        ObservableCollection<Employee> employees;
        Employee currEmployee;
        string name;
        AddWorkshopUseCase AddWorkshopUseCase;
        GetUserByLoginUseCase GetUserByLoginUseCase;
        GetEmployeesUseCase GetEmployeesUseCase;
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

        public IAsyncRelayCommand YesCommand { get; set; }
        public ICommand NoCommand { get; set; }

        public AddWorkshopViewModel(AddWorkshopUseCase addWorkshopUseCase, GetUserByLoginUseCase getUserByLoginUseCase, GetEmployeesUseCase getEmployeesUseCase, IDialogService dialogService)
        {
            AddWorkshopUseCase = addWorkshopUseCase;
            GetUserByLoginUseCase = getUserByLoginUseCase;
            GetEmployeesUseCase = getEmployeesUseCase;
            this.dialogService = dialogService;

            YesCommand = new AsyncRelayCommand<IDialogWindow>(Yes);
            NoCommand = new RelayCommand<IDialogWindow>(No);

            GetEmps();
        }

        async Task Yes(IDialogWindow window)
        {
            if (CurrEmployee != null)
            {
                var user = await GetUserByLoginUseCase.Execute(CurrEmployee.Login);
                if (user != null)
                {
                    if(!await AddWorkshopUseCase.Execute(new Workshop(0, Name, CurrEmployee, user.PhoneNumber, 0)))
                    {
                        dialogService.OpenDialog(new AlertDialogViewModel("Ошибка", "Не удалось добавить цех"));
                    }
                    else
                    {
                        CloseDialogWithResult(window, DialogResults.Yes);
                    }
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
            Employees = [];
            await foreach(var item in GetEmployeesUseCase.Execute())
                Employees.Add(item);
        }
    }
}
