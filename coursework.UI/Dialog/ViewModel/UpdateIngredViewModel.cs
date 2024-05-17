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
    class UpdateIngredViewModel : DialogViewModelBase<DialogResults>
    {
        string name;
        int weight;
        ObservableCollection<IngredType> types;
        IngredType currType;
        IDialogService dialogService;
        GetIngredTypesUseCase GetIngredTypesUseCase;
        UpdateIngredUseCase UpdateIngredUseCase;
        Ingredient ingredient;

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

        public UpdateIngredViewModel(IDialogService dialogService, GetIngredTypesUseCase getIngredTypesUseCase, UpdateIngredUseCase updateIngredUseCase)
        {
            UpdateIngredUseCase = updateIngredUseCase;
            this.dialogService = dialogService;
            GetIngredTypesUseCase = getIngredTypesUseCase;

            YesCommand = new AsyncRelayCommand<IDialogWindow>(Yes);
            NoCommand = new RelayCommand<IDialogWindow>(No);

            WeakReferenceMessenger.Default.Register<IngredientMessenger>(this, (r, m) =>
            {
                ingredient = m.Value;

                Name = ingredient.Name;
                Weight = ingredient.Weight;
                CurrType = ingredient.Type;
            });

            Task.Run(GetTypes);
        }

        async Task Yes(IDialogWindow window)
        {
            if (!await UpdateIngredUseCase.Execute(new Ingredient(ingredient.Id, Name, Weight, CurrType)))
            {
                dialogService.OpenDialog(new AlertDialogViewModel("Ошибка", $"Не удалось обновить {Name}"));
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
        async Task GetTypes()
        {
            Types = [];
            await foreach (var item in GetIngredTypesUseCase.Execute())
                Types.Add(item);
        }
    }
}
