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
    class UpdateEmployeeViewModel : DialogViewModelBase<DialogResults>
    {
        Employee employee;
        User user;
        string lastname, firstname, middlename, passser, passnum, email, phone, education;
        ObservableCollection<Position> positions;
        ObservableCollection<Workshop> workshops;
        Position currPos;
        Workshop currWorkshop;
        DateTime birthday;
        GetWorkshopsUseCase GetWorkshopsUseCase;
        GetPositionsUseCase GetPositionsUseCase;
        UpdateEmployeeUseCase UpdateEmployeeUseCase;
        IDialogService DialogService;

        public string Lastname
        {
            get => lastname;
            set => SetProperty(ref lastname, value);
        }
        public string Firstname
        {
            get => firstname;
            set => SetProperty(ref firstname, value);
        }
        public string Middlename
        {
            get => middlename; 
            set => SetProperty(ref middlename, value);
        }
        public string PassportSer
        {
            get => passser; 
            set => SetProperty(ref passser, value);
        }
        public string PassportNum
        {
            get => passnum; 
            set => SetProperty(ref passnum, value);
        }
        public string Email
        {
            get => email; 
            set => SetProperty(ref email, value);
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
        public DateTime Birthday
        {
            get => birthday; 
            set => SetProperty(ref birthday, value);
        }
        public ObservableCollection<Position> Positions
        {
            get => positions; 
            set => SetProperty(ref positions, value);
        }
        public ObservableCollection<Workshop> Workshops
        {
            get => workshops; 
            set => SetProperty(ref workshops, value);
        }
        public Position CurrPos
        {
            get => currPos; 
            set => SetProperty(ref currPos, value);
        }
        public Workshop CurrWorkshop
        {
            get => currWorkshop; 
            set => SetProperty(ref currWorkshop, value);
        }

        public IAsyncRelayCommand YesCommand { get; set; }
        public ICommand NoCommand { get; set; }

        public UpdateEmployeeViewModel(GetUserByLoginUseCase getUserByLoginUseCase, GetPositionsUseCase getPositionsUseCase, GetWorkshopsUseCase getWorkshopsUseCase, UpdateEmployeeUseCase updateEmployeeUseCase, IDialogService dialogService)
        {
            GetPositionsUseCase = getPositionsUseCase;
            GetWorkshopsUseCase = getWorkshopsUseCase;
            UpdateEmployeeUseCase = updateEmployeeUseCase;
            DialogService = dialogService;

            YesCommand = new AsyncRelayCommand<IDialogWindow>(Yes);
            NoCommand = new RelayCommand<IDialogWindow>(No);

            WeakReferenceMessenger.Default.Register<EmployeeMessenger>(this, async (r, m) =>
            {
                employee = m.Value;

                user = await getUserByLoginUseCase.Execute(employee.Login);

                Lastname = employee.Lastname;
                Firstname = employee.Firstname;
                Middlename = employee.Middlename;
                PassportSer = employee.PassportSerial;
                PassportNum = employee.PassportNum;
                Education = employee.Education;
                Birthday = DateTime.Parse(employee.Birthday.ToString());

                Email = user.Email;
                Phone = user.PhoneNumber;
            });

            Task.Run(GetPos);
            Task.Run(GetWorkshops);
        }

        async Task Yes(IDialogWindow window)
        {
            if(!await UpdateEmployeeUseCase.Execute(new Employee(employee.Id, Lastname, Firstname, Middlename, PassportSer, PassportNum, employee.PayBonus, employee.Login, CurrPos, Birthday, employee.Hiredate, Education, CurrWorkshop), new User(user.Login, user.Password, Email, Phone, user.Role, user.imgstr)))
            {
                DialogService.OpenDialog(new AlertDialogViewModel("Ошибка", $"Не удалось обновить данные сотрудника №{employee.Id}"));
            }
            else
            {
                CloseDialogWithResult(window, DialogResults.Yes);
            }
        }
        void No(IDialogWindow window)
        {
            CloseDialogWithResult(window, DialogResults.No);
        }
        async Task GetPos()
        {
            Positions = [];
            await foreach(var item in GetPositionsUseCase.Execute())
                Positions.Add(item);
        }
        async Task GetWorkshops()
        {
            Workshops = [];
            await foreach(var item in GetWorkshopsUseCase.Execute())
                Workshops.Add(item);
        }
    }
}
