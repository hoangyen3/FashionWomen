using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnLTW.Models;
namespace DoAnLTW.Controllers
{
    public class HomeController : Controller
    {
        ShopAppDbEntities db = new ShopAppDbEntities();
        // GET: Home
        public ActionResult Index()
        {
            // Lấy danh sách sản phẩm từ cơ sở dữ liệu
            var productInHome = db.Products.ToList();

            // Lấy thông báo từ TempData nếu có
            ViewBag.Message = TempData["Message"];

            // Trả về View với danh sách sản phẩm
            return View(productInHome);
        }

    }
}