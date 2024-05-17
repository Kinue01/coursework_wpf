using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using coursework.Domain.Model;
using coursework.Domain.UseCase;
using coursework.UI.Dialog.ViewModel;
using coursework.UI.Messenger;
using coursework.UI.Service.Interface;
using System.Windows.Media.Imaging;

namespace coursework.UI.ViewModel
{
    internal class EmpAccountViewModel : ObservableObject
    {
        Employee employee;
        BitmapImage image;
        string fio;
        User user;
        IDialogService dialogService;
        UpdateEmpAccViewModel UpdateEmpAccViewModel;
        GetUserByLoginUseCase GetUserByLoginUseCase;
        GetEmployeeByIdUseCase GetEmployeeByIdUseCase;

        public Employee Employee
        {
            get => employee; 
            set => SetProperty(ref employee, value);
        }
        public User User
        {
            get => user;
            set => SetProperty(ref user, value);
        }
        public string Fio
        {
            get => fio;
            set => SetProperty(ref fio, value);
        }

        public IAsyncRelayCommand UpdateEmpDataCommand { get; set; }

        public EmpAccountViewModel(IDialogService dialogService, UpdateEmpAccViewModel updateEmpAccViewModel, GetEmployeeByIdUseCase getEmployeeByIdUseCase, GetUserByLoginUseCase getUserByLoginUseCase)
        {
            this.dialogService = dialogService;
            UpdateEmpAccViewModel = updateEmpAccViewModel;
            GetEmployeeByIdUseCase = getEmployeeByIdUseCase;
            GetUserByLoginUseCase = getUserByLoginUseCase;

            UpdateEmpDataCommand = new AsyncRelayCommand(UpdateEmpData);

            WeakReferenceMessenger.Default.Register<EmployeeMessenger>(this, (r, m) =>
            {
                Employee = m.Value;
                Fio = Employee.Lastname + " " + Employee.Firstname + " " + Employee.Middlename;
            });
            WeakReferenceMessenger.Default.Register<UserMessenger>(this, (r, m) =>
            {
                User = m.Value;
            });
        }

        async Task UpdateEmpData()
        {
            WeakReferenceMessenger.Default.Send(new UserMessenger(User));
            WeakReferenceMessenger.Default.Send(new EmployeeMessenger(Employee));

            var res = dialogService.OpenDialog(UpdateEmpAccViewModel);

            if (res == Utils.DialogResults.Yes)
            {
                User = await GetUserByLoginUseCase.Execute(User.Login);
                Employee = await GetEmployeeByIdUseCase.Execute(Employee.Id);
            }
        }
    }
}