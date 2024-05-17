using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using coursework.UI.Service.Interface;
using System.Windows;
using System.Windows.Input;

namespace coursework.UI.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
        INavigationService navigationService;

        public INavigationService NavigationService
        {
            get => navigationService;
            set => SetProperty(ref navigationService, value);
        }

        public ICommand ExitCommand { get; set; }
        public ICommand MinWindowCommand { get; set; }

        public MainViewModel(INavigationService navigationService)
        { 
            NavigationService = navigationService;

            NavigationService.NavigateTo<LoginViewModel>();

            ExitCommand = new RelayCommand(Exit);
            MinWindowCommand = new RelayCommand(Hide);
        }

        void Exit()
        {
            Application.Current.Shutdown();
        }

        void Hide()
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }
    }
}
