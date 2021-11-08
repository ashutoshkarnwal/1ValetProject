using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Entities entity = new Entities();
            var devices = entity.Devices.ToList();
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
