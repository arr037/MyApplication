using System.Windows;
using MyApp.ViewModel;

namespace MyApp.MVVMNavigation
{
    public static class Navigator
    {
        public static void NavigateTo(object obj)
        {
            if (Application.Current.MainWindow?.DataContext is MainWindowViewModel window) 
                window.CurrentPage = obj;
        }
    }
}