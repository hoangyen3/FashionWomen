using DoAnLTW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity; // For Entity Framework 6


namespace DoAnLTW.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        private readonly ShopAppDbEntities _context; // Your DbContext

        // Constructor to initialize the DbContext
        public AccountController()
        {
            _context = new ShopAppDbEntities(); // Initialize your DbContext
        }

        // GET: Admin/Account
        public ActionResult Index()
        {
            // Retrieve all accounts from the database
            var accounts = _context.Accounts
                                    .Include(a => a.Customer) // Eager load related Customer data
                                    .ToList();

            // Pass the accounts list to the view
            return View(accounts);
        }
        public ActionResult CreateAccount() 
        {
            return View();
        }
    }
}