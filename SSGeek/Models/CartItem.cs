using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSGeek.Models
{
  public class CartItem
  {
    private Product _product = new Product();
    public Product Product {
      get
      {
        return _product;
      }
      set
      {
        _product = value;
      }
    }
    public int Quantity { get; set; }

    public double Total { get { return _product.Price * Quantity; } }

  }
}