using CommunityToolkit.Mvvm.Input;
using coursework.UI.Service.Interface;
using coursework.UI.Utils;
using System.Windows.Input;

namespace coursework.UI.Dialog.ViewModel
{
    class AlertDialogViewModel : DialogViewModelBase<DialogResults>
    {
        public ICommand OKCommand { get; set; }

        public AlertDialogViewModel(string title, string message) : base(title, message)
        {
            OKCommand = new RelayCommand<IDialogWindow>(OK);
        }

        void OK(IDialogWindow window)
        {
            CloseDialogWithResult(window, DialogResults.Undefined);
        }
    }
}
