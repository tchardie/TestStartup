using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About(int? id)
        {
            ViewBag.Message = "Your application description page.";

            if(id.HasValue)
            {
                return Json(new ModelA{ Id = id.Value, Name = "TestName" });
            }

            return View();
        }

        public ActionResult Contact()
        {
            HttpContext.Session["userName"] = "MyUserName";

            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}