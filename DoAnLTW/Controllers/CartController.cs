using DoAnLTW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web.Mvc;

public class CartController : Controller
{
    private ShopAppDbEntities db = new ShopAppDbEntities(); // Database context

    public ActionResult Index()
    {
        var cart = Session["Cart"] as Cart;
        if (cart == null)
        {
            cart = new Cart();
            Session["Cart"] = cart;
        }

        var model = new CartIndexViewModel
        {
            Cart = cart,
            ReturnUrl = Request.UrlReferrer?.AbsolutePath ?? Url.Action("Index", "Home")
        };

        return View(model);
    }

    /*  [HttpPost] 
      public ActionResult AddToCart(int productId)
      {
          var product = db.Products.Find(productId);
          if (product != null)
          {
              var cart = Session["Cart"] as Cart;
              if (cart == null)
              {
                  cart = new Cart();
                  Session["Cart"] = cart;
              }

              cart.AddItem(product, 1); // Thêm sản phẩm vào giỏ hàng với số lượng 1

              // Lưu thông báo vào TempData
              TempData["Message"] = "Sản phẩm đã được thêm vào giỏ hàng thành công!";
          }

          return RedirectToAction("Index");
      }*/
    [HttpPost]
    public ActionResult AddToCart(int productId, int quantity)
    {
        var product = db.Products.Find(productId);
        if (product != null)
        {
            var cart = Session["Cart"] as Cart;
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }

            cart.AddItem(product, quantity); // Thêm sản phẩm vào giỏ hàng

            TempData["Message"] = "Sản phẩm đã được thêm vào giỏ hàng thành công!";
        }

        return RedirectToAction("Index", "Cart");
    }
    public ActionResult RemoveFromCart(int productId, string returnUrl)
    {
        var cart = Session["Cart"] as Cart;
        if (cart != null)
        {
            cart.RemoveItem(productId);
        }

        return Redirect(returnUrl);
    }

}
