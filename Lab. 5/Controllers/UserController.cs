using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab._5.Models;
using System.Web;

namespace Lab._5.Controllers
{
    public class UserController : Controller
    {
        // GET: IndexController
        public ActionResult Index()
        {
            return View("Pages/Index.cshtml");
        }

        // GET: IndexController/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Id = id;
            return View("Pages/Index.cshtml");
        }

        // GET: IndexController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IndexController/Create
        [HttpPost]
       // [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)  
        {
            var authorId = int.Parse(collection["AuthorId"]);
            //var photo = Request.Files[0].InputStream.FileName;
            //var photo = GetImageFromRequest();
            if (authorId != 0)
                using (var db = new CommonContext())
                {
                    var post = new Post
                    {
                        Author = db.users.Find(authorId),
                        createdDate = DateTime.Now,
                        LikeCount = 0,
                        Text = collection["Text"],
                        ImageURL = collection["ImageURL"]
                    };
                    db.posts.Add(post);
                    db.SaveChanges();
                }

            return Details(authorId);
        }

        // GET: IndexController/Edit/5
        public ActionResult Edit(int id)
        {
            using (var db = new CommonContext())
            {
                var post = db.posts.Find(id);
                if (post != null)
                {
                    post.createdDate = DateTime.Now;
                    db.posts.Update(post);
                    db.SaveChanges();
                }
            }

            return View("Pages/Index.cshtml");
        }

        // POST: IndexController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: IndexController/Delete/5
        public ActionResult Delete(int id)
        {
            DeletePostFromDB(id);
            return View("Pages/Index.cshtml");
        }

        // POST: IndexController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private void DeletePostFromDB(int id)
        {
            using (var db = new CommonContext())
            {
                var post = db.posts.Find(id);
                if (post != null)
                {
                    db.Remove(post);
                    db.SaveChanges();
                }
            }
        }
    
        /*
        private static WebImage GetImageFromRequest()
        {
            System.Web.HttpContext.
            var request = HttpContext.Current.Request;

            if (request.Files.Length == 0)
            {
                return null;
            }

            try
            {
                var postedFile = request.Files[0];
                var image = new WebImage(postedFile.InputStream)
                {
                    FileName = postedFile.FileName
                };
                return image;
            }
            catch
            {
                // The user uploaded a file that wasn't an image or an image format that we don't understand
                return null;
            }
        }//*/
    }
}
