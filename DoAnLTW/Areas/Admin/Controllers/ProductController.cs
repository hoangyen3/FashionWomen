using DoAnLTW.Models;
using System.Linq;
using System.Web.Mvc;

namespace DoAnLTW.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly ShopAppDbEntities _context = new ShopAppDbEntities(); // Thay bằng tên DbContext thực tế

        // GET: Admin/ProductNew
        public ActionResult ProductNew()
        {
            var categories = _context.Categories.ToList();
            ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");
            return View();
        }
        // POST: Admin/ProductNew
        [HttpPost]
        public ActionResult ProductNew(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("ProductList");
            }
            // Nếu không hợp lệ, nạp lại danh sách category và hiển thị lại form
            var categories = _context.Categories.ToList();
            ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");
            return View(product);
        }

        public ActionResult ProductList()
        {
            // Lấy danh sách sản phẩm từ cơ sở dữ liệu
            var products = _context.Products.ToList();

            // Truyền dữ liệu sản phẩm đến view
            return View(products);
        }

        
        // GET: Admin/ProductList
        public ActionResult ProductInventory()
        {
            // Lấy danh sách sản phẩm từ cơ sở dữ liệu
            var products = _context.Products.ToList();

            // Truyền dữ liệu sản phẩm đến view
            return View(products);        }
        public ActionResult EditProduct()
        {
            var product = _context.Products.ToList();
            if (product == null)
            {
                return HttpNotFound(); // Handle the case where the product is not found
            }
            return View(product);
        }
        public ActionResult CrateProduct()
        {
            return View();
        }

    }
}

 
