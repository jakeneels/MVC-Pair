using SSGeek.DAL;
using SSGeek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSGeek.Controllers
{
  public class ForumController : Controller
  {
    //public ActionResult Index()
    //{
    //  return RedirectToAction("Forum", "Planets"); //<-- if user goes to .com/ this redirects to .com/planets/index
    //}
    public ActionResult Forum()
    {
      if (TempData["message"] == null)
      {
        TempData["message"] = "Welcome!";
      }

      ForumPostSqlDAL _dal = new ForumPostSqlDAL();

      var model = _dal.GetAllPosts();

      return View("Forum", model);
    }

    public ActionResult NewPost()
    {
      return View("NewPost");
    }

    [HttpPost]
    public ActionResult NewPost(ForumPost model)
    {
      ForumPostSqlDAL _dal = new ForumPostSqlDAL();

      bool successful = _dal.SaveNewPost(model);

      //If successful:

      if (successful)
      {
        SetMessage("Your post was successfully added");
      }
      else
      {
        SetMessage("There was an error adding your post!");
      }

      return RedirectToAction("Forum");
    }

    private void SetMessage(string text)
    {
      TempData["message"] = text;
    }
  }
}