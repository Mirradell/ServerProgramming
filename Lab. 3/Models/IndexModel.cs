using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab._3.Models
{
    public class IndexModel
    {
        public List<string> imagesURLs;

        public IndexModel()
        {
            imagesURLs = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText("Data/indexes.json"));
        }
    }
}
