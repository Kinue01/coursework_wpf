using CommunityToolkit.Mvvm.Input;
using coursework.Domain.Model;
using coursework.Domain.UseCase;
using coursework.UI.Service.Interface;
using coursework.UI.Utils;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace coursework.UI.Dialog.ViewModel
{
    class AddIngredViewModel : DialogViewModelBase<DialogResults>
    {
        string name;
        int weight;
        ObservableCollection<IngredType> types;
        IngredType currType;
        AddIngredUseCase addIngredUseCase;
        IDialogService dialogService;
        GetIngredTypesUseCase GetIngredTypesUseCase;

        public string Name
        {
            get => name; 
            set => SetProperty(ref name, value);
        }
        public int Weight
        {
            get => weight;
            set => SetProperty(ref weight, value);
        }
        public IngredType CurrType
        {
            get => currType; 
            set => SetProperty(ref currType, value);
        }
        public ObservableCollection<IngredType> Types
        {
            get => types;
            set => SetProperty(ref types, value);
        }

        public IAsyncRelayCommand YesCommand { get; set; }
        public ICommand NoCommand { get; set; }

        public AddIngredViewModel(AddIngredUseCase addIngredUseCase, IDialogService dialogService, GetIngredTypesUseCase getIngredTypesUseCase)
        {
            this.addIngredUseCase = addIngredUseCase;
            this.dialogService = dialogService;
            GetIngredTypesUseCase = getIngredTypesUseCase;

            YesCommand = new AsyncRelayCommand<IDialogWindow>(Yes);
            NoCommand = new RelayCommand<IDialogWindow>(No);

            Task.Run(GetTypes);
        }

        async Task Yes(IDialogWindow window)
        {
            if (CurrType != null)
            {
                if (!await addIngredUseCase.Execute(new Ingredient(0, Name, Weight, CurrType)))
                {
                    dialogService.OpenDialog(new AlertDialogViewModel("Ошибка", $"Не удалось добавить ингредиент {Name}"));
                }
                else
                {
                    CloseDialogWithResult(window, DialogResults.Yes);
                }
            }
            else
            {
                dialogService.OpenDialog(new AlertDialogViewModel("Ошибка", "Выберите тип ингредиента"));
            }
        }
        void No(IDialogWindow window)
        {
            CloseDialogWithResult(window, DialogResults.No);
        }
        async Task GetTypes()
        {
            Types = [];
            await foreach(var item in GetIngredTypesUseCase.Execute())
                Types.Add(item);
        }
    }
}
