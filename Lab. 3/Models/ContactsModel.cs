using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab._3.Models
{
    public class Contact
    {
        public string Name;
        public string Placeholder;
    }
    public class ContactsModel
    {
        public List<Contact> items;
        public ContactsModel()
        {
            items = JsonConvert.DeserializeObject<List<Contact>>(File.ReadAllText("Data/contact.json"));
        }
    }
}
