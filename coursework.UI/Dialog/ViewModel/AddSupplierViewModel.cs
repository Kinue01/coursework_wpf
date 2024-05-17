using CommunityToolkit.Mvvm.Input;
using coursework.Domain.Model;
using coursework.Domain.UseCase;
using coursework.UI.Service.Interface;
using coursework.UI.Utils;
using System.Windows.Input;

namespace coursework.UI.Dialog.ViewModel
{
    internal class AddSupplierViewModel : DialogViewModelBase<DialogResults>
    {
        string name, address, phone, email, contact;
        AddSupplierUseCase AddSupplierUseCase;
        IDialogService dialogService;

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
        public string Address
        {
            get => address;
            set => SetProperty(ref address, value);
        }
        public string Phone
        {
            get => phone;
            set => SetProperty(ref phone, value);
        }
        public string Email
        {
            get => email; 
            set => SetProperty(ref email, value);
        }
        public string Contact
        {
            get => contact; 
            set => SetProperty(ref contact, value);
        }

        public IAsyncRelayCommand YesCommand { get; set; }
        public ICommand NoCommand { get; set; }

        public AddSupplierViewModel(AddSupplierUseCase addSupplierUseCase, IDialogService dialogService)
        {
            AddSupplierUseCase = addSupplierUseCase;
            this.dialogService = dialogService;

            YesCommand = new AsyncRelayCommand<IDialogWindow>(Yes);
            NoCommand = new RelayCommand<IDialogWindow>(No);
        }

        async Task Yes(IDialogWindow window)
        {
            if (!await AddSupplierUseCase.Execute(new Supplier(0, Name, Address, Phone, Email, Contact)))
            {
                dialogService.OpenDialog(new AlertDialogViewModel("Ошибка", $"Не удалось добавить поставщика {Name}"));
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
    }
}
