using MyFrame.Helper;
using MyFrame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFrame.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        public ActionResult Index()
        { 
            return View();
        }
        [HttpPost]
        public JsonResult Login(LoginViewModel userInfo)
        {

            return Json(new { success = true, msg=""});
        }
	}
}