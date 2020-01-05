using System;
using System.Windows;
using MyApp.Commands;
using MyApp.Messengers;
using MyApp.Model;
using MyApp.ViewModel.PagesViewModels;

namespace MyApp.ViewModel
{
    public class MainWindowViewModel:BaseViewModel
    {
        private object _currentPage;

        public object CurrentPage
        {
            get => _currentPage;
            set => SetProperty(ref _currentPage, value);
        }

        public DelegateCommand CloseApplication { get; }
        public DelegateCommand AddNewUser { get; }
        public MainWindowViewModel()
        {
            CloseApplication = new DelegateCommand(GetVoid);
            AddNewUser  = new DelegateCommand(NewUser);

            CurrentPage = new DefaultViewModel();
        }
        private void NewUser()
        {
            CurrentPage = new AddNewUserViewModel();
        }

        private void GetVoid()
        {
            Application.Current.Shutdown();
        }
    }
}