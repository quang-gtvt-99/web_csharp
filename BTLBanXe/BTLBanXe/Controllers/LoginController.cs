using BTLBanXe.Models;
using LoginLogin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTLBanXe.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult LoginView()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginView(adminmodel model )
        {
           
            var result = new LoginModel().Login(model.User, model.Password);
            if(result && ModelState.IsValid)
            {
                
                var y = new adminmodel();
                y.x = new LoginModel().user(model.User);
                helperSession.setSession(new userSession() { User = model.User });
                return RedirectToAction("Index", "Edit");
            }
            else
            {
                ModelState.AddModelError("", "Sai tên đăng nhập hoặc mật khẩu .");
            }
            return View(model);
        }
        protected void SetAlert(string message, string type) { TempData["AlertMessage"] = message; if (type == "success") { TempData["AlertType"] = "alert-success"; } else if (type == "warning") { TempData["AlertType"] = "alert-warning"; } else if (type == "error") { TempData["AlertType"] = "alert-danger"; } }
    }
}