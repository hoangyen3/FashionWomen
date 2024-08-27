using DoAnLTW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace DoAnLTW.Controllers
{
    public class AccountController : Controller
    {
        private readonly ShopAppDbEntities _context;

        // GET: Account
        public AccountController()
        {
            _context = new ShopAppDbEntities();
        }


        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var account = _context.Accounts
                .FirstOrDefault(a => a.Username == username && a.Password == password);

            if (account != null)
            {
                // Check if the user is an admin
                if (account.Username == "admin")
                {
                    // Redirect to the admin page
                    return RedirectToAction("Dashboard", "Admin");
                }
                else
                {
                    // Redirect to the customer page
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid username or password.";
                return View();
            }
        }
        // GET: /Account/Login
        public ActionResult Login()
        {
            return View();
        }

        

        public ActionResult Register()
        {
            return View();
        }
        public ActionResult ForgotPwd()
        {
            return View();
        }

    }
}