using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.BusinessLayer;

namespace WebApplication1.Controllers
{
    public class MyStaticController : Controller
    {
        // GET: MyStatic
        public ActionResult Index()
        {
            var list = MyLayer.GetStringList();

            return View(list);
        }
    }
}