using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Models;
using PagedList;
using PagedList.Mvc;

namespace WebShop.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Admin/Dashboard

        private QUANLYSHOPFOODEntities db = new QUANLYSHOPFOODEntities();

        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            return View(db.SanPhams.ToList().OrderBy(x => x.MaHang).ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Details(int id)
        {
        }

        //Create New Product
        public ActionResult Create()
        {
        }
    }
}