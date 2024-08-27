using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DoAnLTW.Models; // Đảm bảo rằng bạn sử dụng không gian tên đúng cho mô hình của bạn

namespace DoAnLTW.Areas.Admin.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ShopAppDbEntities _context; // Thay ApplicationDbContext bằng DbContext thực tế của bạn

        public CustomerController()
        {
            _context = new ShopAppDbEntities(); // Khởi tạo DbContext
        }

        // GET: Admin/Customer
        public ActionResult Index()
        {
            // Lấy danh sách khách hàng từ cơ sở dữ liệu
            var customers = _context.Customers.ToList(); // Thay _context.Customers bằng truy vấn đúng của bạn

            return View(customers); // Truyền danh sách khách hàng vào View
        }


        public ActionResult CustomerNew()
        {
            // Lấy danh sách khách hàng từ cơ sở dữ liệu
            var customers = _context.Customers.ToList(); // Thay _context.Customers bằng truy vấn đúng của bạn

            return View(customers); // Truyền danh sách khách hàng vào View
        }

        public ActionResult LoyalCustomer()
        {
            return View();
        }

        public ActionResult CustomerService()
        {
            // Lấy danh sách khách hàng tiềm năng từ cơ sở dữ liệu
            var potentialCustomers = _context.Customers
                .ToList();

            return View(potentialCustomers); // Truyền danh sách khách hàng tiềm năng vào View
        }
    }
}
