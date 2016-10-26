using HocMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HocMVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var mesage = new MessageModel();
            mesage.welcome = "Chào mừng đến với Model";
            return View(mesage);
        }
    }
}