using DoAnLTW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnLTW.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        readonly ShopAppDbEntities db = new ShopAppDbEntities();
        public ActionResult Index()
        { 
            var productInShop = db.Products.ToList();
            return View(productInShop);
        }
        public ActionResult Details(int id)
        {
            var product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

    }
}