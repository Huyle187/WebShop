using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Areas.Admin.Catalog;
using WebShop.Library;
using WebShop.Models;

namespace WebShop.Areas.Admin.Controllers
{
    public class AuthController : Controller
    {
        private QUANLYSHOPFOODEntities db = new QUANLYSHOPFOODEntities();
        private UserDAO _userDAO = new UserDAO();

        // GET: Admin/Auth
        public ActionResult Login()
        {
            ViewBag.StrError = "";
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection filed)
        {
            string user = filed["username"];
            string pass = Encryptor.ToMD5(filed["password"]);
            string error = "";

            Account acc_user = _userDAO.getRow(user);
            if (acc_user != null)
            {
                if (acc_user.enabled == 1)
                {
                    if (acc_user.access_level == 1)
                    {
                        //Login
                        if (acc_user.password.Equals(pass))
                        {
                            Session["UserAdmin"] = acc_user.username;
                            return RedirectToAction("Index", "Dashboard");
                        }
                        else
                        {
                            error = "Mật khẩu không chính xác!";
                        }
                    }
                    else
                    {
                        error = "Bạn không được phép đăng nhập!";
                    }
                }
                else
                {
                    error = "Tài khoản của bạn đang bị khóa!";
                }
            }
            else
            {
                error = "Tên đăng nhập không chính xác!";
            }

            ViewBag.StrError = "<div class = 'text-danger'>" + error + "</div>";
            return View();
        }

        public ActionResult Logout()
        {
            Session["UserAdmin"] = "";
            return Redirect("~/Admin/login");
        }

        // Admin/Register
        // Create New Account Admin
        public ActionResult CreateAccount()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAccount(Account account, string confirmPass)
        {
            string error = "";
            if (account == null) error = "Vui long nhap du lieu";
            else if (account.username == null) error = "Khong duoc de trong du lieu nay";
            else if (account.email == null) error = "Khong duoc de trong du lieu nay";
            else if (account.password == null) error = "Khong duoc de trong du lieu nay";
            else if (confirmPass == null) error = "Khong duoc de trong du lieu nay";

            if (confirmPass != account.password)
            {
                error = "Mat khau xac nhan khong chinh xac!";
            }

            //Save Account to Database
            if (ModelState.IsValid)
            {
                db.Accounts.Add(account);
                //db.SaveChanges();
            }
            return View();
        }
    }
}