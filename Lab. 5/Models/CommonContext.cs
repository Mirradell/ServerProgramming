using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab._5.Models;

namespace Lab._5.Models
{
    public class CommonContext : DbContext
    {
        public DbSet<Post> posts { get; set; }
        public DbSet<User> users { get; set; }

        public CommonContext() { }

        // The following configures EF to create a Sqlite database file as `C:\blogging.db`.
        // For Mac or Linux, change this to `/tmp/blogging.db` or any other absolute path.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=C:\databases\common.db");
    }
}
