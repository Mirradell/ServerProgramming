using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab._3.Models
{
    public class Portfolio
    {
        public string Category;
        public string ImageURL;
        public string TitleBig;
        public string TitleSmall;
    }
    public class PortfoliosModel
    {
        public List<Portfolio> items;
        public PortfoliosModel()
        {
            items = JsonConvert.DeserializeObject<List<Portfolio>>(File.ReadAllText("Data/portfolios.json"));
        }
    }
}
