using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using MyApp.Messengers;
using MyApp.Model;
using MyApp.MVVMNavigation;
using MyApp.ViewModel.PagesViewModels;
using Newtonsoft.Json;

namespace MyApp.ViewModel.ControlsViewModel
{
    public class UserNameControlViewModel:BaseViewModel
    {
        private ObservableCollection<UserNameControl> _items;

        public ObservableCollection<UserNameControl> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        public UserNameControlViewModel()
        {
            Messenger.Default.Register<UserNameControl>(this, AddUserToCollection);
            

            Items =File.Exists("users.json") ? JsonConvert.DeserializeObject<ObservableCollection<UserNameControl>>(File.ReadAllText("users.json")) : new ObservableCollection<UserNameControl>();

            Items.CollectionChanged += (s, e) =>
            {
                File.WriteAllText("users.json", JsonConvert.SerializeObject(Items));
            };
        }

        private void AddUserToCollection(UserNameControl obj)
        {
            var b = Items.Where(x => x.Name == obj.Name && x.Surname == obj.Surname).ToArray();
                            
            if (b.Length > 0)
            {
                MessageBox.Show("Такой пользователь уже существует");
                return;
            }
            Items.Add(obj);
            Navigator.NavigateTo(new DefaultViewModel());
        }
    }
}