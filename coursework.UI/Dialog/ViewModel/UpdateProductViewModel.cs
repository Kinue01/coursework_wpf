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
    internal class UpdateProductViewModel : DialogViewModelBase<DialogResults>
    {
        string name;
        int price, weight, prots, fats, carb;
        UpdateProductUseCase UpdateProductUseCase;
        Product Product;
        IDialogService DialogService;

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
        public int Price
        {
            get => price;
            set => SetProperty(ref price, value);
        }
        public int Weight
        {
            get => weight;
            set => SetProperty(ref weight, value);
        }
        public int Prots
        {
            get => prots;
            set => SetProperty(ref prots, value);
        }
        public int Fats
        {
            get => fats;
            set => SetProperty(ref fats, value);
        }
        public int Carb
        {
            get => carb;
            set => SetProperty(ref carb, value);
        }

        public ICommand YesCommand { get; set; }
        public ICommand NoCommand { get; set; }

        public UpdateProductViewModel(UpdateProductUseCase updateProductUseCase, IDialogService dialogService)
        {
            UpdateProductUseCase = updateProductUseCase;
            DialogService = dialogService;

            YesCommand = new AsyncRelayCommand<IDialogWindow>(Yes);
            NoCommand = new RelayCommand<IDialogWindow>(No);

            WeakReferenceMessenger.Default.Register<ProductMessenger>(this, (r, m) =>
            {
                Product = m.Value;

                Name = m.Value.ProductName;
                Price = m.Value.ProductPrice;
                Weight = m.Value.ProductWeight;
                Prots = m.Value.ProductProteins;
                Fats = m.Value.ProductFats;
                Carb = m.Value.ProductCarbohydrates;
            });
        }

        async Task Yes(IDialogWindow window)
        {
            if (!await UpdateProductUseCase.Execute(new Product(Product.ProductId, Name, Price, Prots, Fats, Carb, Weight, Product.imagestr)))
            {
                DialogService.OpenDialog(new AlertDialogViewModel("Ошибка", $"Не удалось обновить продукт {Product.ProductName}"));
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
