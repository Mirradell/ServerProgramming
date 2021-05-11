using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Lab._6.Models
{
    //Пользователи (ид, имя, ник, подписки, подписчики, лайки);
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }

        [Display(Name = "UsersImage")]
        public string ImageURL { get; set; }
        public string About { get; set; }
        public virtual ICollection<User> Followers { get; set; } = new List<User>();
        public virtual ICollection<User> Following { get; set; } = new List<User>();
    }
}
