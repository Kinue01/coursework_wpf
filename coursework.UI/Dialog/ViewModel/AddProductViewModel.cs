using CommunityToolkit.Mvvm.Input;
using coursework.Domain.Model;
using coursework.Domain.UseCase;
using coursework.UI.Service.Interface;
using coursework.UI.Utils;
using System.Windows.Input;

namespace coursework.UI.Dialog.ViewModel
{
    class AddProductViewModel : DialogViewModelBase<DialogResults>
    {
        string name;
        int price, weight, prots, fats, carb;
        AddProductUseCase addProductUseCase;
        IDialogService dialogService;

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

        public AddProductViewModel(AddProductUseCase addProductUseCase, IDialogService dialogService)
        {
            this.addProductUseCase = addProductUseCase;
            this.dialogService = dialogService;

            YesCommand = new AsyncRelayCommand<IDialogWindow>(Yes);
            NoCommand = new RelayCommand<IDialogWindow>(No);
        }

        async Task Yes(IDialogWindow window)
        {
            if (!await addProductUseCase.Execute(new Product(0, Name, Price, Prots, Fats, Carb, Weight, "prodDefault.png")))
            {
                dialogService.OpenDialog(new AlertDialogViewModel("Ошибка", $"Не удалось добавить продукт {Name}"));
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
