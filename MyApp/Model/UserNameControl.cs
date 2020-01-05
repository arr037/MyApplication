using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyApp.Model
{
    public class UserNameControl:BaseViewModel
    {
        
        public UserNameControl(string name, string surname, string backgroundColor="")
        {
           
            Name = name;
            Surname = surname;
            BackgroundColor = backgroundColor;
        }
       
        
        [JsonProperty("Name")]
        public string Name { get; }
       
        [JsonProperty("Surname")]
        public string Surname { get; }
       
        [JsonProperty("BackgroundColor")]
        public string BackgroundColor { get;}
        
         [JsonProperty("UrlMainImage")]
        public string UrlMainImage { get;}
        
        [JsonProperty("Initials")]
        public string Initial =>
            Name.Remove(1, Name.Length - 1)+ Surname.Remove(1, Surname.Length - 1);
    }
}