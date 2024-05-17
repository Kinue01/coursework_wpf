using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using coursework.Domain.Model;
using coursework.Domain.UseCase;
using coursework.UI.Messenger;
using coursework.UI.Service.Interface;
using coursework.UI.Utils;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace coursework.UI.Dialog.ViewModel
{
    class UpdateEmpAccViewModel : DialogViewModelBase<DialogResults>
    {
        Employee employee;
        User user;
        string lastname, firstname, middlename, passser, passnum, email, phone, education, login, pass, imgpath;
        DateTime birthday;
        UpdateEmployeeUseCase UpdateEmployeeUseCase;
        IDialogService DialogService;
        BitmapImage image;
        UVerification verification;

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
        public string Login
        {
            get => login;
            set => SetProperty(ref login, value);
        }
        public string Password
        {
            get => pass;
            set => SetProperty(ref pass, value);
        }
        public DateTime Birthday
        {
            get => birthday;
            set => SetProperty(ref birthday, value);
        }
        public User User
        {
            get => user;
            set => SetProperty(ref user, value);
        }
        public BitmapImage Image
        {
            get => image; 
            set => SetProperty(ref image, value);
        }

        public IAsyncRelayCommand YesCommand { get; set; }
        public ICommand NoCommand { get; set; }
        public ICommand UpdateImageCommand { get; set; }

        public UpdateEmpAccViewModel(UpdateEmployeeUseCase updateEmployeeUseCase, IDialogService dialogService, UVerification verification)
        {
            DialogService = dialogService;
            UpdateEmployeeUseCase = updateEmployeeUseCase;
            this.verification = verification;

            YesCommand = new AsyncRelayCommand<IDialogWindow>(Yes);
            NoCommand = new RelayCommand<IDialogWindow>(No);
            UpdateImageCommand = new RelayCommand(UpdateImage);

            WeakReferenceMessenger.Default.Register<UserMessenger>(this, (r, m) =>
            {
                User = m.Value;

                Login = User.Login;
                Email = User.Email;
                Phone = User.PhoneNumber;
                Image = User.Image;
                imgpath = User.imgstr;
            });

            WeakReferenceMessenger.Default.Register<EmployeeMessenger>(this, async (r, m) =>
            {
                employee = m.Value;

                Lastname = employee.Lastname;
                Firstname = employee.Firstname;
                Middlename = employee.Middlename;
                PassportSer = employee.PassportSerial;
                PassportNum = employee.PassportNum;
                Education = employee.Education;
                Birthday = DateTime.Parse(employee.Birthday.ToString());
            });
        }

        async Task Yes(IDialogWindow window)
        {
            if (!await UpdateEmployeeUseCase.Execute(new Employee(employee.Id, Lastname, Firstname, Middlename, PassportNum, PassportSer, employee.PayBonus, Login, employee.Position, Birthday, employee.Hiredate, Education, employee.Workshop), new User(Login, verification.GetSHA512Hash(Password), Email, Phone, user.Role, imgpath)))
            {
                DialogService.OpenDialog(new AlertDialogViewModel("Ошибка", "Не удалось обновить профиль"));
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
        void UpdateImage()
        {
            imgpath = DialogService.OpenFileDialog(User.imgstr);
        }
    }
}
