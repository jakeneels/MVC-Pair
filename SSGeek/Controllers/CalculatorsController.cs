using SSGeek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSGeek.Controllers
{
  public class CalculatorsController : Controller
  {
    // INSTRUCTIONS
    // As a part of each exercise you will need to 
    // - develop a view for AlienAge, AlienWeight, and AlienTravel that displays a form to submit data
    // - develop a model for the forms to bind to when the form request is submitted
    // - create a new action to process the form submission (e.g. AlienAgeResult, AlienWeightResult, etc.)
    // - create a view that displays the submitted form result


   
    //Created an AlienWeight and AlienWeightResult Action

    public ActionResult AlienWeight()
    {
      return View("AlienWeight");
    }

    public ActionResult AlienWeightResult(AlienWeightModel model)
    {
      //?Planet = Mercury & EarthWeight = 55
      var queryString = HttpContext.Request.QueryString;
      var qs = queryString.GetValues("EarthWeight");
      int _weight;
      
      if (int.TryParse(qs[0], out _weight))
      {
        model.Weight = _weight;
      }
      model.SetPlanetWeight();
      return View("AlienWeightResult", model);
    }

  
    // GET: Calculators/AlienAge

    public ActionResult AlienAge()
    {
      return View("AlienAge");
    }

    public ActionResult AlienAgeResult(AlienAgeModel model)
    {
      //?Planet = Mercury & EarthWeight = 55
      var queryString = HttpContext.Request.QueryString;
      var qs = queryString.GetValues("EarthAge");
      int _age;

      if (int.TryParse(qs[0], out _age))
      {
        model.Age = _age;
      }
      model.SetPlanetAge();
      return View("AlienAgeResult", model);
    }

    //TODO: Create an AlienTravel and AlienTravelResult Action
    public ActionResult AlienTravel()
    {
      return View("AlienTravel");
    }

    public ActionResult AlienTravelResult(AlienTravelModel model)
    {
      //?Planet = Mercury & EarthWeight = 55
      var queryString = HttpContext.Request.QueryString;
      model.Vehicle = queryString.GetValues("vehicle")[0];

      var qs = queryString.GetValues("earthAge")[0];
      int _age;

      if (int.TryParse(qs, out _age))
      {
        model.Age = _age;
      }

      model.CalcTravelTimeAndAge();
      return View("AlienTravelResult", model);
    }   
  }
}