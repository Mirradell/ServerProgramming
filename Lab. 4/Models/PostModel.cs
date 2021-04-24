using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab._4.Models
{
    //Записи (ид, дата, текст, автор, изображение, лайки).
    public class Post
    {
        public string ID { get; set; }
        public DateTime createdDate { get; set; }
        public string Text { get; set; }
        public string ImageURL { get; set; }
        public int LikeCount { get; set; }
        public int UserId { get; set; }
        public User Author {get; set;}
    }

    public class PostModel
    {
        public List<Post> items;
        private User users = new Lab._4.Models.UserModel().item;

        public PostModel()
        {
            items = JsonConvert.DeserializeObject<List<Post>>(File.ReadAllText("Data/posts.json"));

            foreach (var post in items)
            {
                post.Author = users;
            }
        }
    }
}
