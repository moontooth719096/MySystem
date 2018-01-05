using MySystem.ViewModels.LikeWeb;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using MySystem.Models.LikeWeb;
using ConnetDB.MySystemDB;

namespace MySystem.Controllers
{
    public class LikeWebController : Controller
    {
        //
        // GET: /LikeWeb/
        public ActionResult LikeWebMainPage()
        {
            WebDataViewModel model = new WebDataViewModel();
            

            model.getWebdataDB();
            if (!string.IsNullOrEmpty(model.Message))
            {
                return View(model);
            }
            model.getWebType();
            if (!string.IsNullOrEmpty(model.Message))
            {
                return View(model);
            }
            Session["WebDataList"] = model.WebDataList;

            return View(model);
        }
        public JsonResult LikeWebMainPage1()
        {
            WebDataViewModel model = new WebDataViewModel();
            model.getWebdataDB();

            return Json(model.WebDataList, "success");
        }
        #region 新增頁面
        public ActionResult LikeWebAddPage()
        {
            WebDataViewModel model = new WebDataViewModel();
            model.getWebType();
            if (!string.IsNullOrEmpty(model.Message))
            {
                return null;
            }
            return View(model);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult LikeWebAddPage(WebDataViewModel model)
        {
            /*WebDataDB model = new WebDataDB();
            if (!string.IsNullOrEmpty(WebName) || !string.IsNullOrEmpty(WebType) || !string.IsNullOrEmpty(WebURL))
            {
                string ErrorMessage = "";
                model.WebName = WebName;
                model.WebType = WebType;
                model.WebURL = WebURL;
                //ErrorMessage = model.addWebdataDB(WebName, WebType, WebURL);
            }*/
            return new RedirectResult("/LikeWeb/LikeWebMainPage");
        }
        #endregion

        #region 修改頁面
        public ActionResult LikeWebModifyPage(string WebName)
        {
            ViewBag.Title = "編輯頁面";
            WebDataViewModel model = new WebDataViewModel();
            model.WebDataList = Session["WebDataList"] as List<WebDataModel>;
            model.getWebType();
            if (!string.IsNullOrEmpty(model.Message))
            {
                return View(model);
            }
            WebDataModel SelectData = new WebDataModel();
            SelectData = model.WebDataList.Where(x => x.WebName == WebName).FirstOrDefault();
            model.WebName = SelectData.WebName;
            model.WebTypeNeme = SelectData.WebTypeNeme;
            model.WebURL = SelectData.WebURL;
            return View(model);
        }
        [HttpPost]
        public ActionResult LikeWebModifyPage(WebDataDB model)
        {

            return new RedirectResult("/LikeWeb/LikeWebMainPage");
        }
        #endregion
    }
}
