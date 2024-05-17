using coursework.UI.Service.Interface;
using coursework.UI.Utils;
using Microsoft.Win32;

namespace coursework.UI.Service.Impl
{
    class DialogService : IDialogService
    {
        public T OpenDialog<T>(DialogViewModelBase<T> vm)
        {
            IDialogWindow window = new DialogWindow
            {
                DataContext = vm
            };
            window.ShowDialog();
            return vm.DialogResult;
        }
        public string OpenFileDialog(string path)
        {
            var window = new OpenFileDialog
            {
                FileName = path,
                DefaultDirectory = "C:\\",
                DefaultExt = ".png",
                AddExtension = true,
                Multiselect = false
            };

            if (window.ShowDialog().GetValueOrDefault())
            {
                return window.SafeFileName;
            }
            else
            {
                return path;
            }
        }
    }
}
