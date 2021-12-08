using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class HomeController : Controller
    {
        private QUANLYSHOPFOODEntities db = new QUANLYSHOPFOODEntities();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult LeftMenu()
        {
            var leftMenu = db.LoaiHangs.ToList();
            return PartialView(leftMenu);
        }
    }
}