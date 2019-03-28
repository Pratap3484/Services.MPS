using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Services.MPS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public class UserModel
        {
            public int UserId { get; set; }
            public string UserName { get; set; }
            public string Company { get; set; }
        }
        [HttpGet]
        public JsonResult GetData()
        {
            var usersList = new List<UserModel>
            {
                new UserModel
                {
                    UserId = 1,
                    UserName = "Ram",
                    Company = "Mindfire Solutions"
                },
                new UserModel
                {
                    UserId = 1,
                    UserName = "chand",
                    Company = "Mindfire Solutions"
                },
                new UserModel
                {
                    UserId = 1,
                    UserName = "Abc",
                    Company = "Abc Solutions"
                }
            };

            return Json(usersList,JsonRequestBehavior.AllowGet);
        }
    }
}
