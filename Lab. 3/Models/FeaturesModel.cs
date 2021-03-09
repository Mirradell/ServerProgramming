using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab._3.Models
{
    public class Features
    {
        public string Title;
        public string Text;
        public string Class;
        public string ImageURL;
    }

    public class FeaturesModel
    {
        public List<Features> itemsLeft, itemsRight, itemsServices;
        public FeaturesModel()
        {
            var t = JsonConvert.DeserializeObject<Dictionary<string, List<Features>>>(File.ReadAllText("Data/features.json"));
            itemsLeft = t["Left"];
            itemsRight = t["Right"];
            itemsServices = t["Services"];
        }
    }
}
