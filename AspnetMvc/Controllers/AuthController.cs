using AspnetMvc.Models;
using AspnetMvc.Database;
using AspnetMvc.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace AspnetMvc.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        // GET: Auth
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            var model = new Login
            {
                ReturnUrl = returnUrl
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(Login model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var db = new DataContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Email == model.Email);
                string encryptedPassword = Encrypt.EncrypText(model.Password);
                
                if(user.Email==model.Email && user.Password == encryptedPassword)
                {
                   
                    Session["user"] = user.Id;
                    var identity = new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.Name,user.Name),
                        new Claim(ClaimTypes.Email,user.Email),
                        new Claim(ClaimTypes.Country,user.Country)
                },"ApplicationCookie");
                    var ctx = Request.GetOwinContext();
                    var authManager = ctx.Authentication;
                    authManager.SignIn(identity);

                    return Redirect(GetRedirectUrl(model.ReturnUrl));
                }

            }
            ModelState.AddModelError("", "Email o password inválido");
            return View(model);
        }

        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("Index", "home");
            }
            return returnUrl;
        }

        public ActionResult Logout()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;
            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("Login", "Auth");
        }

        
        public ActionResult Registration(User model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new DataContext())
                {
                    var encryptedPassword = Encrypt.EncrypText(model.Password);
                    var user = db.Users.Create();
                    user.Password = encryptedPassword;
                    user.Email = model.Email;
                    user.Name = model.Name;
                    user.Country = model.Country;
                    db.Users.Add(user);
                    db.SaveChanges();
                }
            }
            else {
                ModelState.AddModelError("", "Uno o más campos deben ser llenados");
            }
            return View();
        }

    }
}