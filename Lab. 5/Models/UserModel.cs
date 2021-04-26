using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Lab._5.Models
{
    //Пользователи (ид, имя, ник, подписки, подписчики, лайки);
    public class User
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }

        [Display(Name = "UsersImage")]
        public string ImageURL { get; set; }
        public string About { get; set; }
        public List<User> Followers { get; set; }
        public List<User> Following { get; set; }
    }
    public class UserModel
    {
        public User item;
        public UserModel()
        {
            item = JsonConvert.DeserializeObject<User>(File.ReadAllText("Data/users.json"));
        }
    }
}
