using coursework.UI.Utils;

namespace coursework.UI.Service.Interface
{
    interface IDialogService
    {
        T OpenDialog<T>(DialogViewModelBase<T> vm);
        string OpenFileDialog(string path);
    }
}
