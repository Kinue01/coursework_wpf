using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using coursework.Domain.Model;
using coursework.Domain.UseCase;
using coursework.UI.Messenger;
using coursework.UI.Service.Interface;
using coursework.UI.Utils;
using System.Windows.Input;

namespace coursework.UI.Dialog.ViewModel
{
    internal class UpdateSupplierViewModel : DialogViewModelBase<DialogResults>
    {
        string name, address, phone, email, contact;
        UpdateSupplierUseCase UpdateSupplierUseCase;
        int id;
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

        public UpdateSupplierViewModel(UpdateSupplierUseCase updateSupplierUseCase, IDialogService dialogService)
        {
            UpdateSupplierUseCase = updateSupplierUseCase;
            this.dialogService = dialogService;

            YesCommand = new AsyncRelayCommand<IDialogWindow>(Yes);
            NoCommand = new RelayCommand<IDialogWindow>(No);

            WeakReferenceMessenger.Default.Register<SupplierMesenger>(this, (r, m) =>
            {
                Name = m.Value.SupplierName;
                Address = m.Value.SupplierAddress;
                Phone = m.Value.SupplierPhone;
                Email = m.Value.SupplierEmail;
                Contact = m.Value.SupplierContact;
                id = m.Value.SupplierId;
            });
        }

        async Task Yes(IDialogWindow window)
        {
            if (!await UpdateSupplierUseCase.Execute(new Supplier(id, Name, Address, Phone, Email, Contact)))
            {
                dialogService.OpenDialog(new AlertDialogViewModel("Ошибка", $"Не удалось обновить поставщика {Name}"));
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
