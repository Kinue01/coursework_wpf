using CommunityToolkit.Mvvm.ComponentModel;

namespace coursework.UI.Service.Interface
{
    internal interface INavigationService
    {
        ObservableObject CurrentView { get; set; }
        ObservableObject CurrentMainView { get; set; }
        ObservableObject CurrentDashboardView { get; set; }
        void NavigateTo<T>() where T : ObservableObject;
        void NavigateMainTo<T>() where T : ObservableObject;
        void NavigateDashboardTo<T>() where T : ObservableObject;
    }
}
