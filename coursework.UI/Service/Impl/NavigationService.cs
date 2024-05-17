using CommunityToolkit.Mvvm.ComponentModel;
using coursework.UI.Service.Interface;

namespace coursework.UI.Service.Impl
{
    public class NavigationService : ObservableObject, INavigationService
    {
        ObservableObject currentView;
        ObservableObject currentMainView;
        ObservableObject currentDashboardView;
        readonly Func<Type, ObservableObject> _viewModelFactory;

        public ObservableObject CurrentView
        {
            get => currentView; 
            set => SetProperty(ref currentView, value);
        }
        public ObservableObject CurrentMainView 
        { 
            get => currentMainView;
            set => SetProperty(ref currentMainView, value);
        }
        public ObservableObject CurrentDashboardView 
        {
            get => currentDashboardView;
            set => SetProperty(ref currentDashboardView, value);
        }

        public NavigationService(Func<Type, ObservableObject> viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }

        public void NavigateTo<T>() where T : ObservableObject
        {
            ObservableObject vm = _viewModelFactory.Invoke(typeof(T));
            CurrentView = vm;
        }

        public void NavigateMainTo<T>() where T : ObservableObject
        {
            ObservableObject vm = _viewModelFactory.Invoke(typeof(T));
            CurrentMainView = vm;
        }

        public void NavigateDashboardTo<T>() where T : ObservableObject
        {
            ObservableObject vm = _viewModelFactory.Invoke(typeof(T));
            CurrentDashboardView = vm;
        }
    }
}
