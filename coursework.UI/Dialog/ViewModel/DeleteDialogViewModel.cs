using CommunityToolkit.Mvvm.Input;
using coursework.UI.Service.Interface;
using coursework.UI.Utils;
using System.Windows.Input;

namespace coursework.UI.Dialog.ViewModel
{
    class DeleteDialogViewModel : DialogViewModelBase<DialogResults>
    {
        public ICommand YesCommand { get; set; }
        public ICommand NoCommand { get; set; }

        public DeleteDialogViewModel(string title, string message) : base(title, message)
        {
            YesCommand = new RelayCommand<IDialogWindow>(Yes);
            NoCommand = new RelayCommand<IDialogWindow>(No);
        }

        void Yes(IDialogWindow window)
        {
            CloseDialogWithResult(window, DialogResults.Yes);
        }
        void No(IDialogWindow window)
        {
            CloseDialogWithResult(window, DialogResults.No);
        }
    }
}
