using PchK22CNT3Lesson10Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PchK22CNT3Lesson10Db.Controllers
{
    public class PchHomeController : Controller
    {
        public ActionResult PchIndex()
        {
            // kiểm tra dữ liệu trong session
            if (Session["PchAccount"] ! = null)
            {
                var tvcAccount = Session["PchAccount") as PchAccount;
                ViewBag.FullNane • pchAccount.PchFulINane;
            }
            return View();
        }

        public ActionResult PchAbout()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult PchContact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}