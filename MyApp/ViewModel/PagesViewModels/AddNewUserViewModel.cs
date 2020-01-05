using System;
using System.Collections.Generic;
using Microsoft.Win32;
using MyApp.Commands;
using MyApp.Messengers;
using MyApp.Model;
using MyApp.ViewModel.ControlsViewModel;

namespace MyApp.ViewModel.PagesViewModels
{
    public class AddNewUserViewModel:BaseViewModel
    {
        private string _name;
        private string _surname;
        private List<string> _colors;
        private string _selectedColor;

        public string SelectedColor
        {
            get => _selectedColor;
            set => SetProperty(ref _selectedColor, value);
        }

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public string Surname
        {
            get => _surname;
            set => SetProperty(ref _surname, value);
        }

        public List<string> Colors
        {
            get => _colors;
            set => SetProperty(ref _colors, value);
        }

        public DelegateCommand AddToCollection { get; }
        public AddNewUserViewModel()
        {
            Colors = new List<string>();
            AddToCollection = new DelegateCommand(AddCollection);
            
            Colors.Add("7A1FA2");
            Colors.Add("7F55C2");
            Colors.Add("004C3F");
            Colors.Add("00887A");
            Colors.Add("0288D1");
            Colors.Add("689F39");
            Colors.Add("00579C");
            Colors.Add("EC407A");
            Colors.Add("33691E");
            Colors.Add("C2175B");
            Colors.Add("F5511E");
            
        }

        private void AddCollection()
        {
            if(string.IsNullOrWhiteSpace(Name))
                return;
            if(string.IsNullOrWhiteSpace(Surname))
                return;
            if(string.IsNullOrEmpty(SelectedColor))
                return;

            var b = new UserNameControl(Name,Surname,SelectedColor);
            
            Messenger.Default.Send(b);
        }
    }
}