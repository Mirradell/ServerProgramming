using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab._3.Models
{
    public class About
    {
        public string Title;
        public string SubTitle;
        public string TextLead;
        public string Text;
        public string ImageURL;
        public string AHref;
    }

    public class AboutModel
    {
        public List<About> items;
        public AboutModel()
        {
            items = JsonConvert.DeserializeObject<List<About>>(File.ReadAllText("Data/about.json"));
        }
    }
}
