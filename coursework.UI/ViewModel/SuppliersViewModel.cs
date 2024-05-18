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

namespace coursework.UI.ViewModel
{
    class SuppliersViewModel : ObservableObject
    {
        ObservableCollection<Supplier> suppliers;
        GetSuppliersUseCase getSuppliersUseCase;
        IDialogService dialogService;
        DeleteSupplierUseCase deleteSupplierUseCase;
        Supplier currSupplier;
        AddSupplierViewModel addSupplierViewModel;
        UpdateSupplierViewModel updateSupplierViewModel;
        Visibility isAdmin;

        public ObservableCollection<Supplier> Suppliers
        {
            get => suppliers;
            set => SetProperty(ref suppliers, value);
        }
        public Supplier CurrSupplier
        {
            get => currSupplier;
            set => SetProperty(ref currSupplier, value);
        }
        public Visibility IsAdmin
        {
            get => isAdmin;
            set => SetProperty(ref isAdmin, value);
        }

        public IAsyncRelayCommand AddSupplierCommand { get; set; }
        public IAsyncRelayCommand DeleteSupplierCommand { get; set; }
        public IAsyncRelayCommand UpdateSupplierCommand { get; set; }

        public SuppliersViewModel(GetSuppliersUseCase getSuppliersUseCase, IDialogService dialogService, DeleteSupplierUseCase deleteSupplierUseCase, AddSupplierViewModel addSupplierViewModel, UpdateSupplierViewModel updateSupplierViewModel)
        {
            this.getSuppliersUseCase = getSuppliersUseCase;
            this.dialogService = dialogService;
            this.deleteSupplierUseCase = deleteSupplierUseCase;
            this.addSupplierViewModel = addSupplierViewModel;
            this.updateSupplierViewModel = updateSupplierViewModel;

            AddSupplierCommand = new AsyncRelayCommand(AddSupplier);
            UpdateSupplierCommand = new AsyncRelayCommand(UpdateSupplier);
            DeleteSupplierCommand = new AsyncRelayCommand(DeleteSupplier);

            WeakReferenceMessenger.Default.Register<DashboardEmployeeMessenger>(this, (r, m) =>
            {
                if (m.Value.Position.PositionId == 1 || m.Value.Position.PositionId == 2)
                {
                    IsAdmin = Visibility.Visible;
                }
                else
                {
                    IsAdmin = Visibility.Collapsed;
                }
            });

            GetSuppliers();
        }

        async Task GetSuppliers()
        {
            Suppliers = [];
            await foreach(var item in getSuppliersUseCase.Execute())
                Suppliers.Add(item);
        }
        async Task AddSupplier()
        {
            var res = dialogService.OpenDialog(addSupplierViewModel);
            if (res == Utils.DialogResults.Yes)
            {
                await GetSuppliers();
            }
        }
        async Task UpdateSupplier()
        {
            WeakReferenceMessenger.Default.Send(new SupplierMesenger(CurrSupplier));
            var res = dialogService.OpenDialog(updateSupplierViewModel);

            if (res == Utils.DialogResults.Yes)
            {
                await GetSuppliers();
            }
        }
        async Task DeleteSupplier()
        {
            if (CurrSupplier != null)
            {
                var res = dialogService.OpenDialog(new DeleteDialogViewModel("Удаление поставщика", $"Вы точно хотите удалить поставщика {CurrSupplier.SupplierName}"));
                if (res == Utils.DialogResults.Yes)
                {
                    if (await deleteSupplierUseCase.Execute(CurrSupplier.SupplierId))
                    {
                        await GetSuppliers();
                    }
                    else
                    {
                        dialogService.OpenDialog(new AlertDialogViewModel("Ошибка", $"Не удалось удалить поставщика {CurrSupplier.SupplierName}"));
                    }
                }
            }
            else
            {
                dialogService.OpenDialog(new AlertDialogViewModel("Ошибка", "Выберите поставщика"));
            }
        }
    }
}
