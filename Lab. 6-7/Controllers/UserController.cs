using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab._6.Models;
using System.Web;
using Microsoft.AspNetCore.Authorization;

namespace Lab._6.Controllers
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
                    var author = db.users.Find(authorId);
                    if (new JWT().GetData().Username == author.UserName)
                    {
                        var post = new Post
                        {
                            Author = author,
                            createdDate = DateTime.Now,
                            LikeCount = 0,
                            Text = collection["Text"],
                            ImageURL = collection["ImageURL"] == "" ? null : collection["ImageURL"].ToString()
                        };
                        db.posts.Add(post);
                        db.SaveChanges();
                    }
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

        public IActionResult SignUp()
        {
            ViewBag.Hello = "Создать учетную запись";
            ViewBag.Button = "Создать";
            ViewBag.Type = "SignUp";
            return View("Pages/SignUp.cshtml");
        }

        public IActionResult LogIn()
        {
            ViewData["Hello"] = "Войти";
            ViewData["Button"] = "Войти";
            ViewData["Type"] = "LogIn";
            return View("Pages/SignUp.cshtml");
        }

        [HttpPost]
        public IActionResult EnterUser(IFormCollection collection)
        {
            var userName = collection["UserName"].ToString();
            var password = collection["Password"].ToString();
            ViewBag.Button = "Войти";

            if (userName == "" || password == "")
            {
                ViewBag.Error = "Wrong data to log in!";
                return View("Pages/SignUp.cshtml");
            }

            int id = -1;
            using (var db = new CommonContext())
            {
                if (db.accounts.Count() > 0 && !db.accounts.Any(x => x.UserName == userName))
                {
                    ViewBag.Error = "User with same login doesn't exists!";
                    return View("Pages/SignUp.cshtml");
                }
                var account = db.accounts.First(x => x.UserName == userName);
                if (account.Password != password)
                {
                    ViewBag.Error = "Wrong data to log in!";
                    return View("Pages/SignUp.cshtml");
                }

                id = db.users.First(x => x.UserName == userName).ID;
            }

            new JWT
            {
                Token = DateTime.Now.ToString(),
                Username = userName
            }.SaveData();

            return Details(id);
        }

        [HttpPost]
        public IActionResult CreateUser(IFormCollection collection)
        {
            var userName = collection["UserName"].ToString();
            var password = collection["Password"].ToString();
            ViewBag.Button = "Создать";

            if (userName == "" || password == "")
            {
                ViewBag.Error = "Wrong data to sign up!";
                return View("Pages/SignUp.cshtml");
            }

            int id = -1;
            using (var db = new CommonContext())
            {
                if (db.accounts.Count() > 0 && db.accounts.Any(x => x.UserName == userName))
                {
                    ViewBag.Error = "User with same login aslready exists!";
                    return View("Pages/SignUp.cshtml");
                }

                var account = new Account
                {
                    UserName = userName,
                    Password = password
                };

                id = db.users.Count() + 1;
                var user = new User
                {
                    ID = id,
                    Name = "",
                    UserName = userName,
                    About = "",
                    ImageURL = "https://picsum.photos/150/150"
                };

                db.accounts.Add(account);
                db.users.Add(user);
                db.SaveChanges();
            }

            new JWT
            {
                Token = DateTime.Now.ToString(),
                Username = userName
            }.SaveData();

            return Details(id);
        }
    }
}
