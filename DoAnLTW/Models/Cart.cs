using DoAnLTW.Models;
using System.Collections.Generic;
using System.Linq;

public class Cart
{
    public List<CartItem> Items { get; set; } = new List<CartItem>();
    public int TotalPrice { get; internal set; }
    public object TotalItems { get; internal set; }

    public decimal ComputeTotalValue()
    {
        return Items.Sum(item => item.Product.Price * item.Quantity);
    }

    public void AddItem(Product product, int quantity)
    {
        var item = Items.FirstOrDefault(p => p.Product.ProductId == product.ProductId);
        if (item == null)
        {
            Items.Add(new CartItem { Product = product, Quantity = quantity });
        }
        else
        {
            item.Quantity += quantity;
        }
    }

    public void RemoveItem(int productId)
    {
        var item = Items.FirstOrDefault(p => p.Product.ProductId == productId);
        if (item != null)
        {
            Items.Remove(item);
        }
    }

}
