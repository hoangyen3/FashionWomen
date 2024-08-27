using System.Linq;
using System.Web.Mvc;
using DoAnLTW.Models; // Thay đổi theo namespace của bạn
using System.Data.Entity; // Dành cho Entity Framework 6

namespace DoAnLTW.Areas.Admin.Controllers
{
    public class OdersController : Controller
    {
        private readonly ShopAppDbEntities _context = new ShopAppDbEntities(); // Thay đổi theo DbContext của bạn

        // GET: Admin/Oders
        public ActionResult Oders()
        {
            var orders = _context.Orders
                .Include(o => o.Customer) // Đảm bảo dữ liệu khách hàng được bao gồm
                .ToList();
            return View(orders);
        }

        public ActionResult OrderDetails(int id)
        {
           
            return View();
        }
        public ActionResult OderDetails() 
        {
            return View();
        }
        public ActionResult OdersNews()
        {
            // Lọc đơn hàng có Status là "Pending" trực tiếp từ cơ sở dữ liệu
            var pendingOrders = _context.Orders
                .Where(o => o.Status == "Pending")
                .Include(o => o.Customer) // Bao gồm dữ liệu khách hàng nếu cần
                .ToList();

            return View(pendingOrders);
        }
        public ActionResult OdersCancels()
        {
            // Lọc đơn hàng với trạng thái "Cancelled"
            var cancelledOrders = _context.Orders
                .Where(o => o.Status == "Cancelled")
                .Include(o => o.Customer) // Bao gồm dữ liệu khách hàng nếu cần
                .ToList();

            return View(cancelledOrders);// Truyền danh sách đơn hàng đã hủy vào view
        }


    }
}
