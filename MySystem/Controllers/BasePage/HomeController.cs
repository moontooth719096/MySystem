using MySystem.ViewModels.LikeWeb;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using MySystem.Models.LikeWeb;
using ConnetDB.MySystemDB;

namespace MySystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult index()
        {
            return View();
        }
    }
}
