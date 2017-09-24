using MySystem.Models;
using MySystem.ViewModels.MusicPlayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySystem.Controllers
{
    public class MusicPlayerController : Controller
    {
        //
        // GET: /Default1/

        public ActionResult MusicPlayerPage()
        {
            MusicPlayerViewModel model = new MusicPlayerViewModel();
            model.getMusicList();
            return View(model);
        }

    }
}
