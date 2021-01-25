using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

            var username = HttpContext.Session["userName"];

            ViewBag.Message = "Your contact page.";

            return View();
        }

        public List<string> GetListOfUsers(int? id)
        {
            var users = new List<string>();

            if(id.HasValue)
            {
                var counter = 5;
                if(id.Value == 3)
                {
                    counter = 3;
                }

                for(int i = 0; i < counter; i++)
                {
                    users.Add("User-" + i);
                }
            }

            return users;
        }

        public async Task<List<string>> GetListAsync()
        {
            return await BuildList();
        }

        private async Task<List<string>> BuildList()
        {
            var list = new List<string>();

            for(int i = 0; i < 100; i++)
            {
                list.Add("item-" + i);
            }

            return list;
        }
    }
}