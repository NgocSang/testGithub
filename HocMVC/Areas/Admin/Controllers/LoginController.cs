using HocMVC.Areas.Admin.code;
using HocMVC.Areas.Admin.Models;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HocMVC.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            //var result = new AccountModel().Login(model.UserName, model.PassWord);
            if (Membership.ValidateUser(model.UserName, model.PassWord) && ModelState.IsValid)
            {
                //SessionHelper.SetSession(new UserSession() { UserName = model.UserName });
                FormsAuthentication.SetAuthCookie(model.UserName, model.Remmember);
                return RedirectToAction("Index", "Home");
            }
            else {
                ModelState.AddModelError("", "Ten dang nhap hoac mat khau khong hop le");
            }
            return View(model);
        }
 
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}