using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace Lab._3.Models
{
    public class Logos
    {
        public string LogoURL;
    }

    public class LogosModel
    {
        public List<Logos> items;
        public LogosModel()
        {
            items = JsonConvert.DeserializeObject<List<Logos>>(File.ReadAllText("Data/logos.json"));
        }
    }
}
