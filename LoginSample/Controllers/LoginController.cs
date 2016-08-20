using LoginSample.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginSample.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(
            [Bind(Include ="username,password")]
            Login vm)
        {
            TempData["result"] = (ModelState.IsValid) ? "Login Success" : "Login Fail";
            return View();
        }
    }
}