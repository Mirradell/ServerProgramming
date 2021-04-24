using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab._4.Controllers
{
    public class PostsController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Pages/Index.cshtml");
        }

        public string NewPost()
        {
            return "New Post";
        }

        public IActionResult Like(int likesCount)
        {
            likesCount++;
            ViewData["like"] = likesCount;
            return View("~/Pages/Index.cshtml");
        }

        public string Edit()
        {
            return "Edit";
        }

        public string Delete()
        {
            return "Delete";
        }
    }
}
