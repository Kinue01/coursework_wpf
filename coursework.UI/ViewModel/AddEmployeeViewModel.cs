using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using coursework.Domain.Model;
using coursework.Domain.UseCase;
using coursework.UI.Dialog.ViewModel;
using coursework.UI.Service.Interface;
using coursework.UI.Utils;
using System.Windows.Input;

namespace coursework.UI.ViewModel
{
    internal class AddEmployeeViewModel : ObservableObject
    {
        string fname, lname, mname, login, password, passrepeat, email, phone, education, passSer, passNum;
        DateTime birthday;
        INavigationService navigationService;
        List<Workshop> workshops;
        List<Position> positions;
        Workshop currWorkshop;
        Position currPosition;
        AddEmployeeUseCase addEmployeeUseCase;
        GetWorkshopsUseCase getWorkshopsUseCase;
        GetPositionsUseCase getPositionsUseCase;
        UVerification uVerification;
        IDialogService dialogService;

        public string Firstname
        {
            get => fname;
            set => SetProperty(ref fname, value);
        }
        public string Lastname
        {
            get => lname;
            set => SetProperty(ref lname, value);
        }
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }
        public string PassRepeat
        {
            get => passrepeat;
            set => SetProperty(ref passrepeat, value);
        }
        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }
        public string Login
        {
            get => login;
            set => SetProperty(ref login, value);
        }
        public string Middlename
        {
            get => mname;
            set => SetProperty(ref mname, value);
        }
        public DateTime Birthday
        {
            get => birthday;
            set => SetProperty(ref birthday, value);
        }
        public INavigationService NavigationService
        {
            get => navigationService;
            set => SetProperty(ref navigationService, value);
        }
        public string Phone
        {
            get => phone;
            set => SetProperty(ref phone, value);
        }
        public string Education
        {
            get => education;
            set => SetProperty(ref education, value);
        }
        public List<Workshop> Workshops
        {
            get => workshops;
            set => SetProperty(ref workshops, value);
        }
        public List<Position> Positions
        {
            get => positions;
            set => SetProperty(ref positions, value);
        }
        public Position CurrPosition
        {
            get => currPosition;
            set => SetProperty(ref currPosition, value);
        }
        public Workshop CurrWorkshop
        {
            get => currWorkshop;
            set => SetProperty(ref currWorkshop, value);
        }
        public string PassSer
        {
            get => passSer;
            set => SetProperty(ref passSer, value);
        }
        public string PassNum
        {
            get => passNum;
            set => SetProperty(ref passNum, value);
        }

        public IAsyncRelayCommand AddEmpCommand { get; set; }
        public ICommand NavigateEmpsCommand { get; set; }

        public AddEmployeeViewModel(AddEmployeeUseCase addEmployeeUseCase, GetWorkshopsUseCase getWorkshopsUseCase, GetPositionsUseCase getPositionsUseCase, UVerification uVerification, IDialogService dialogService, INavigationService navigationService)
        {
            this.addEmployeeUseCase = addEmployeeUseCase;
            this.getPositionsUseCase = getPositionsUseCase;
            this.getWorkshopsUseCase = getWorkshopsUseCase;
            this.uVerification = uVerification;
            this.dialogService = dialogService;
            NavigationService = navigationService;

            AddEmpCommand = new AsyncRelayCommand(AddEmp);
            NavigateEmpsCommand = new RelayCommand(NavigationService.NavigateDashboardTo<EmployeesViewModel>);

            Task.Run(GetPoses);
            Task.Run(GetWorks);
        }

        async Task AddEmp()
        {
            if (Password == PassRepeat)
            {
                string passhash = uVerification.GetSHA512Hash(Password);
                var birth = DateTime.SpecifyKind(Birthday, DateTimeKind.Utc);
                if (await addEmployeeUseCase.Execute(new Employee(0, Lastname, Firstname, Middlename, PassSer, PassNum, 0, Login, CurrPosition, birth, DateOnly.FromDateTime(DateTime.Now), Education, CurrWorkshop), new User(Login, passhash, Email, Phone, 2, "default.png")))
                {
                    NavigationService.NavigateDashboardTo<EmployeesViewModel>();
                }
                else
                {
                    dialogService.OpenDialog(new AlertDialogViewModel("Ошибка", "Не удалось добавить сотрудника. Проверьте поля Email и Телефон"));
                }
            }
            else
            {
                dialogService.OpenDialog(new AlertDialogViewModel("Ошибка", "Пароли не совпадают"));
            }
        }
        async Task GetPoses()
        {
            Positions = [];
            await foreach (var item in getPositionsUseCase.Execute())
                Positions.Add(item);
        }
        async Task GetWorks()
        {
            Workshops = [];
            await foreach(var item in getWorkshopsUseCase.Execute())
                Workshops.Add(item);
        }
    }
}
