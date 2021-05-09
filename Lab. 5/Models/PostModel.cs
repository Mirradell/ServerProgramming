using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab._5.Models
{
    //Записи (ид, дата, текст, автор, изображение, лайки).
    public class Post
    {
        public int ID { get; set; }
        public DateTime createdDate { get; set; }
        public string Text { get; set; }
        public string ImageURL { get; set; }
        public int LikeCount { get; set; }
        public User Author { get; set; }
    }
}
