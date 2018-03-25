using SSGeek.DAL;
using SSGeek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSGeek.Controllers
{
  public class StoreController : Controller
  {

    public ActionResult Index()
    {
      ProductSqlDAL _dal = new ProductSqlDAL();
      var model = _dal.GetProducts();

      return View("Index", model);
    }

    public ActionResult Detail(string productID)
    {
      ProductSqlDAL _dal = new ProductSqlDAL();
      var product = _dal.GetProduct(int.Parse(productID));
      var model = new CartItem();

      model.Product = product;
      
      return View("Detail", model);
    }

    [HttpPost]
    public ActionResult AddToCart(CartItem item)
    {
      ProductSqlDAL _dal = new ProductSqlDAL();
      var queryString = HttpContext.Request.QueryString;
      var qs = queryString.GetValues("productId");
      
      
      item.Product = _dal.GetProduct(int.Parse(qs[0]));

      ShoppingCart cart = GetActiveShoppingCart();
      cart.AddToCart(item);

      return RedirectToAction("ViewCart");
    }

    public ActionResult ViewCart()
    {
      ShoppingCart cart = GetActiveShoppingCart();
      return View(cart);
    }

    private ShoppingCart GetActiveShoppingCart()
    {
      ShoppingCart cart = null;

      if(Session["ShoppingCart"] == null)
      {
        cart = new ShoppingCart();
        Session["ShoppingCart"] = cart;
      }
      else
      {
        cart = Session["ShoppingCart"] as ShoppingCart;
      }
      return cart;
    }

  }
}