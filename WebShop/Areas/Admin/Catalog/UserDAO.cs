using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebShop.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;
using WebShop.Models.ViewModels;

namespace WebShop.Areas.Admin.Catalog
{
    public class UserDAO
    {
        private QUANLYSHOPFOODEntities db = new QUANLYSHOPFOODEntities();

        public IPagedList<SanPham> getList(int? pageIndex, string page = "Index")
        {
            int pageNumber = (pageIndex ?? 1);
            int pageSize = 2;
            if (page == "Index")
            {
                var list = db.SanPhams.Where(p => p.TrangThai == true)
                    .ToList()
                    .OrderBy(m => m.MaHang)
                    .ToPagedList(pageNumber, pageSize);
                return list;
            }
            else
            {
                var list = db.SanPhams.Where(p => p.TrangThai == false)
                   .ToList()
                   .OrderBy(d => d.NgayCapNhat)
                   .ToPagedList(pageNumber, pageSize);
                return list;
            }
        }

        public string UploadFile(HttpPostedFileBase imageFile)
        {
            var fileName = Path.GetFileName(imageFile.FileName);
            var path = Path.Combine(HttpContext.Current.Server.MapPath("~/Public/images"), fileName);
            if (!System.IO.File.Exists(path))
            {
                imageFile.SaveAs(path);
            }
            return fileName;
        }

        public void Create(SanPham product)
        {
            db.SanPhams.Add(product);
            db.SaveChanges();
        }

        public void Update(SanPham product)
        {
            //db.Entry(product).State = System.Data.Entity.EntityState.Modified;
            //db.SaveChanges();
            var _product = db.SanPhams.Find(product.MaHang);

            _product.TenHang = product.TenHang;
            _product.MaNhaCungCap = product.MaNhaCungCap;
            _product.MaLoaiHang = product.MaLoaiHang;
            _product.HinhAnh = product.HinhAnh;
            _product.MoTa = product.MoTa;
            _product.NgayCapNhat = product.NgayCapNhat;
            _product.SoLuongTon = product.SoLuongTon;
            _product.GiaBan = product.GiaBan;
            _product.TrangThai = product.TrangThai;

            db.SaveChanges();
        }

        public void Delete(SanPham product)
        {
            db.SanPhams.Remove(product);
            db.SaveChanges();
        }

        public IPagedList<SanPham> Search(int? pageIndex, string stringSearch)
        {
            var textBox = stringSearch.ToLower();
            int pageNumber = (pageIndex ?? 1);
            int pageSize = 10;

            var list = db.SanPhams.Where(p => p.TenHang.Contains(stringSearch) ||
                                                p.NhaCungCap.TenNhaCungCap.Contains(stringSearch) ||
                                                p.LoaiHang.TenLoaiHang.Contains(stringSearch) ||
                                                p.GiaBan.ToString() == textBox)
                .OrderBy(m => m.MaHang)
                .ToList()
                .ToPagedList(pageNumber, pageSize);
            return list;
        }
    }
}