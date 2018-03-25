using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSGeek.Models
{
  public class ShoppingCart
  {
    public List<CartItem> _cart = new List<CartItem>();

    public double Total
    {
      get
      {
        return CalcTotal();
      }
    }

    public List<CartItem> Cart
    {
      get
      {
        return _cart;
      }
    }

    public void AddToCart(CartItem item)
    {
      bool dupeItem = false;
      foreach (var existingItem in _cart)
      {
        if (item.Product.ProductId == existingItem.Product.ProductId)
        {
          existingItem.Quantity += item.Quantity;
          dupeItem = true;
        }
      }

      if (!dupeItem)
      {
        _cart.Add(item);
      }
      _cart.Add(item);
    }

    private double CalcTotal()
    {
      double total = 0;
      foreach (var item in _cart)
      {
        total += item.Product.Price * item.Quantity;
      }

      return total;
    }
  }
}