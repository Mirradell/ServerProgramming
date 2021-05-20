using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab._6.Models;

namespace Lab._6
{
    public class Program
    {
        private static void CreateDB()
        {
            using (var db = new CommonContext())
            {
                db.users.RemoveRange(db.users);
                db.posts.RemoveRange(db.posts);
                db.accounts.RemoveRange(db.accounts);
                db.SaveChanges();

                var users = new List<User>() {
                    new User
                    {
                        ID = 1,
                        Name = "Miracles Lee Cross",
                        UserName = "@UserName",
                        About = "Developer of web applications, JavaScript, PHP, Java, Python, Ruby, Java,Node.js etc.",
                        ImageURL = "https://picsum.photos/150/150"
                    },

                    new User
                    {
                        ID = 2,
                        Name = "Wonderful Bird",
                        UserName = "@FlyMe",
                        About = "Developer of web applications, JavaScript, PHP, Java, Python, Ruby, Java,Node.js etc.",
                        ImageURL = "https://picsum.photos/150/150"
                    }
                };

                var accounts = new List<Account>() {
                    new Account
                    {
                        ID = 1,
                        UserName = "@UserName",
                        Password = "12345"
                    },

                    new Account
                    {
                        ID = 2,
                        UserName = "@FlyMe",
                        Password = "12345"
                    }
                };

                var posts = new List<Post>()
                {
                    new Post
                    {
                        ID = 1,
                        Author = users[0],
                        createdDate = new DateTime(2021, 4, 26),
                        ImageURL = null,
                        LikeCount = 0,
                        Text = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Quo recusandae nulla rem eos ipsa praesentium esse magnam nemo dolor sequi fuga quia quaerat cum, obcaecati hic, molestias minima iste voluptates."
                    },

                    new Post
                    {
                        ID = 2,
                        Author = users[0],
                        createdDate = new DateTime(2021, 1, 1),
                        ImageURL = "https://picsum.photos/300/300",
                        LikeCount = 5,
                        Text = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Quo recusandae nulla rem eos ipsa praesentium esse magnam nemo dolor sequi fuga quia quaerat cum, obcaecati hic, molestias minima iste voluptates."
                    },

                    new Post
                    {
                        ID = 3,
                        Author = users[1],
                        createdDate = new DateTime(2021, 4, 16),
                        ImageURL = "https://picsum.photos/300/300",
                        LikeCount = 2,
                        Text = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Quo recusandae nulla rem eos ipsa praesentium esse magnam nemo dolor sequi fuga quia quaerat cum, obcaecati hic, molestias minima iste voluptates."
                    }
                };

                users.ForEach(user => db.users.Add(user));
                posts.ForEach(post => db.posts.Add(post));
                accounts.ForEach(account => db.accounts.Add(account));

                db.SaveChanges();
            }
        }

        public static void Main(string[] args)
        {
            CreateDB();
            CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
