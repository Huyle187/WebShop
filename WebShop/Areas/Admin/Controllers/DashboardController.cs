using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;
using WebShop.Areas.Admin.Catalog;

namespace WebShop.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Admin/Dashboard
        private QUANLYSHOPFOODEntities db = new QUANLYSHOPFOODEntities();

        private UserDAO _userDAO = new UserDAO();

        public ActionResult Index(int? page)
        {
            //int pageNumber = (page ?? 1);
            //int pageSize = 10;
            //return View(db.SanPhams.ToList().OrderBy(x => x.MaHang).ToPagedList(pageNumber, pageSize));
            return View(_userDAO.getList(page, "Index"));
        }

        public ActionResult Details(int id)
        {
            var product = db.SanPhams.FirstOrDefault(x => x.MaHang == id);
            if (product == null)
            {
                TempData["XMessage"] = new MyMessage("Not Fount the Product!", "danger");
                return RedirectToAction("Index");
            }
            return View(product);
        }

        //Create New Product
        [HttpGet]
        public ActionResult Create()
        {
            //Đưa dữ liệu vào Dropdown List
            ViewBag.MaNhaCungCap = new SelectList(db.NhaCungCaps.ToList(), "MaNhaCungCap", "TenNhaCungCap");
            ViewBag.MaLoaiHang = new SelectList(db.LoaiHangs.ToList(), "MaLoaiHang", "TenLoaiHang");

            return View();
        }

        [HttpPost]
        public ActionResult Create(SanPham product, HttpPostedFileBase imageFile)
        {
            ViewBag.MaNhaCungCap = new SelectList(db.NhaCungCaps.ToList(), "MaNhaCungCap", "TenNhaCungCap");
            ViewBag.MaLoaiHang = new SelectList(db.LoaiHangs.ToList(), "MaLoaiHang", "TenLoaiHang");

            if (imageFile == null)
            {
                TempData["CheckImage"] = new MyMessage("Vui lòng chọn hình ảnh", "danger");
            }
            else
            {
                product.HinhAnh = _userDAO.UploadFile(imageFile);
            }
            product.TrangThai = true;
            product.NgayCapNhat = DateTime.Now;
            if (ModelState.IsValid)
            {
                _userDAO.Create(product);
                TempData["XMessage"] = new MyMessage("Add " + product.TenHang + " is successfully!", "danger");
                return RedirectToAction("Index");
            }
            return View();
        }

        //Edit Product
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product = db.SanPhams.FirstOrDefault(x => x.MaHang == id);
            if (product == null)
            {
                TempData["XMessage"] = new MyMessage("Not Fount the Product to Update!", "danger");
                return RedirectToAction("Index");
            }

            ViewBag.MaNhaCungCap = new SelectList(db.NhaCungCaps.ToList(), "MaNhaCungCap", "TenNhaCungCap", product.MaNhaCungCap);
            ViewBag.MaLoaiHang = new SelectList(db.LoaiHangs.ToList(), "MaLoaiHang", "TenLoaiHang", product.MaLoaiHang);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(SanPham product, HttpPostedFileBase imageFile)
        {
            ViewBag.MaNhaCungCap = new SelectList(db.NhaCungCaps.ToList(), "MaNhaCungCap", "TenNhaCungCap", product.MaNhaCungCap);
            ViewBag.MaLoaiHang = new SelectList(db.LoaiHangs.ToList(), "MaLoaiHang", "TenLoaiHang", product.MaLoaiHang);

            if (imageFile != null)
            {
                //Update new Image
                product.HinhAnh = _userDAO.UploadFile(imageFile);
            }
            if (product.HinhAnh == null)
            {
                TempData["CheckImage"] = new MyMessage("Vui lòng chọn hình ảnh", "danger");
                return View(product);
            }
            product.TrangThai = true;
            product.NgayCapNhat = DateTime.Now;
            if (ModelState.IsValid)
            {
                _userDAO.Update(product);
                TempData["XMessage"] = new MyMessage("Update " + product.TenHang.ToUpper() + " is successfully!", "danger");
                return RedirectToAction("Index");
            }
            return View(product);
        }

        //Delete Product
        public ActionResult Delete(int id)
        {
            var product = db.SanPhams.Find(id);
            if (product == null)
            {
                TempData["XMessage"] = new MyMessage("Not Fount the Product to Delete!", "danger");
                return RedirectToAction("Index");
            }
            _userDAO.Delete(product);
            TempData["XMessage"] = new MyMessage("Delete " + product.TenHang.ToUpper() + " is successfully!", "danger");
            return RedirectToAction("Trash");
        }

        //Recycle Bin
        public ActionResult Trash(int? page)
        {
            return View(_userDAO.getList(page, "Trash"));
        }

        //Delete product into Recycle Bin
        public ActionResult Deltrash(int id)
        {
            var product = db.SanPhams.Find(id);
            if (product == null)
            {
                TempData["XMessage"] = new MyMessage("Not Fount the Product!", "danger");
                return RedirectToAction("Index");
            }

            //product.NgayCapNhat = DateTime.Now;
            product.TrangThai = false;

            _userDAO.Update(product);
            TempData["XMessage"] = new MyMessage("Delete " + product.TenHang.ToUpper() + " into Recycle Bin is successfully!", "danger");
            return RedirectToAction("Index");
        }

        //Recover product from Recycle Bin
        public ActionResult Retrash(int id)
        {
            var product = db.SanPhams.Find(id);
            if (product == null)
            {
                TempData["XMessage"] = new MyMessage("Not Fount the Product!", "danger");
                return RedirectToAction("Index");
            }

            //product.NgayCapNhat = DateTime.Now;
            product.TrangThai = true;

            _userDAO.Update(product);
            TempData["XMessage"] = new MyMessage("Recover " + product.TenHang.ToUpper() + " from Recycle Bin is successfully!", "danger");
            return RedirectToAction("Index");
        }

        public ActionResult Search(int? page, string text)
        {
            if (text == "")
            {
                return RedirectToAction("Index");
            }
            return View("Index", _userDAO.Search(page, text));
        }
    }
}