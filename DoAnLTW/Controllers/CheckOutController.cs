using DoAnLTW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnLTW.Controllers
{
    public class CheckOutController : Controller
    {
        // GET: CheckOut
        ShopAppDbEntities db = new ShopAppDbEntities();

        public ActionResult Index()
        {
            var cart = GetCart();
            if (cart == null || cart.Items.Count == 0)
            {
                TempData["Message"] = "Your cart is empty!";
                return RedirectToAction("Index");
            }

            var model = new CheckoutViewModel
            {
                Cart = cart,
                ReturnUrl = Request.UrlReferrer?.ToString()
            };

            return View(model);
        }

        // Phương thức GetCart để lấy giỏ hàng từ phiên làm việc hiện tại
        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
[HttpPost]
public ActionResult PlaceOrder()
{
    // Giả sử giỏ hàng được lưu trong session dưới dạng List<CartItem>
    var cartItems = Session["CartItems"] as List<CartItem>;

    if (cartItems == null || !cartItems.Any())
    {
        return RedirectToAction("Index", "Home"); // Hoặc trang lỗi nếu giỏ hàng trống
    }

    // Tạo đơn hàng mới
    var order = new Order
    {
        OrderDate = DateTime.Now,
        TotalAmount = CalculateTotalAmount(cartItems) + 50, // Tổng cộng với chi phí vận chuyển
        Status = "Pending",
    };

    // Lưu đơn hàng vào cơ sở dữ liệu
    db.Orders.Add(order);
    db.SaveChanges();

    // Xóa giỏ hàng hoặc thực hiện các thao tác cần thiết
    Session["CartItems"] = null;

    // Hiển thị thông báo thành công
    TempData["SuccessMessage"] = "Đặt hàng thành công!";

    // Chuyển hướng đến trang quản lý đơn hàng trong admin
    return RedirectToAction("OrdersNews", "Orders", new { area = "Admin" });
}


        private int CalculateTotalAmount(List<CartItem> cartItems)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult OrderSuccess(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Tạo đối tượng Order và gán các thuộc tính từ OrderViewModel
                var order = new Order
                {
                    CustomerId = model.CustomerId,
                    ShippingAddress = model.Address,
                    PaymentMethod = model.PaymentMethod,
                    Notes = model.Notes,
                    OrderDate = DateTime.Now,
                    TotalAmount = CalculateTotalAmount(model.ProductId, model.Quantity),
                    Status = "Pending" // Trạng thái ban đầu của đơn hàng
                };

                // Lưu đơn hàng vào database
                using (var dbContext = new ShopAppDbEntities())
                {
                    dbContext.Orders.Add(order);
                    dbContext.SaveChanges();
                }

                // Trả về kết quả thành công
                return Json(new { success = true });
            }

            // Nếu có lỗi, trả về kết quả thất bại
            return Json(new { success = false, message = "Order failed" });
        }

        // Phương thức tính tổng tiền đơn hàng
        private decimal CalculateTotalAmount(int productId, int quantity)
        {
            // Ví dụ tính tổng tiền dựa trên ProductId và Quantity
            using (var dbContext = new ShopAppDbEntities())
            {
                var product = dbContext.Products.Find(productId);
                if (product != null)
                {
                    return product.Price * quantity;
                }
                return 0;
            }
        }
    }
}