using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab._3.Models
{
    public class Price
    {
        public string Title;
        public string SubTitle;
        public string Money;
        public string Currency;
        public string Amount;
        public string Month;
        public List<string> ContentAbl;
        public List<string> ContentDis;
    }

    public class PricesModel
    {
        public List<Price> items;
        public PricesModel()
        {
            items = JsonConvert.DeserializeObject<List<Price>>(File.ReadAllText("Data/prices.json"));
        }
    }
}
