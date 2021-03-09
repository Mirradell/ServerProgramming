using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab._3.Models
{
    public class Service
    {
        public string ImageURL;
        public string Title;
        public string Text;
    }
    public class ServiceModel
    {
        public List<Service> items;
        public List<string> spanClasses;

        public ServiceModel()
        {
            items = JsonConvert.DeserializeObject<List<Service>>(File.ReadAllText("Data/services.json"));
            spanClasses = new List<string>()
            {
                "icon icon-display",
                "icon icon-database",
                "icon icon-magic-wand",
                "icon icon-cloud"
            };
        }
    }
}
