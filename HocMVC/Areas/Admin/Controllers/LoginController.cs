
using HocMVC.Areas.Admin.Models;
using HocMVC.Common;
using HocMVC.Dao;
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
        
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = new UserDao();
                var count = result.login(model.UserName, Encryptor.MD5Hash(model.PassWord));
                switch (count)
                {
                    case -1:
                        ModelState.AddModelError("", "Tai khoa chua ton tai");
                        break;
                    case -2:
                        ModelState.AddModelError("", "Tai khoa dang bi khoa");
                        break;
                    case 1:
                        ModelState.AddModelError("", "Mat khau dang nhap sai");
                        break;
                    case 2:
                        var usersesion = result.GetbyID(model.UserName);
                        var session = new UserLogin();
                        session.UserName = usersesion.UserName;
                        session.UserID = usersesion.ID;
                        Session.Add(CommontStant.USER_SESSION, session);
                        return RedirectToAction("Index", "Home");
                        break;

                }
            }
            
            return View("Index");
        }
 
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}