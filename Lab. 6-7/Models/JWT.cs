using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Lab._6.Models
{
    public class JWT
    {
        public string Token { get; set; }
        public string Username { get; set; }


        public JWT GetData()
        {
            var t = JsonConvert.DeserializeObject<JWT>(File.ReadAllText("Data/token.json"));
            Token = t.Token;
            Username = t.Username;
            return this;
        }

        public void SaveData()
        {
            File.WriteAllText("Data/token.json", JsonConvert.SerializeObject(this));
        }
    }
}
