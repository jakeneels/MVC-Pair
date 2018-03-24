using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSGeek.Models
{
  public class AlienTravelModel
  {
    //all values are derived from these
    public string Vehicle { get; set; }

    public string Planet { get; set; }

    private double _age;
    public double Age
    {
      get { return _age; }
      set { _age = value; }
    }
    //end derived

    private Dictionary<string, int> _transport =
      new Dictionary<string, int>() {{"walking"    ,  3 },
                                     {"car"        ,  100 },
                                     {"bullet train", 200},
                                     {"boeing 747"  , 570 },
                                     {"concorde"    , 1350 } };

    public int SpeedMPH { get { return _transport[Vehicle]; } }

    private double _travelTimeYears;
    public double TravelTimeYears { get { return _travelTimeYears; } }

    public double AgeArrival { get { return _age + _travelTimeYears; } }

    public void CalcTravelTimeAndAge()
    {
      const double HOURS_YEAR = 8765.82;
      double milesAway = 0;
      if (Planet.ToLower() == "mercury")
      {
        milesAway = 56974146;
      }
      if (Planet.ToLower() == "venus")
      {
        milesAway = 25724767;
      }
      if (Planet.ToLower() == "mars")
      {
        milesAway = 48678219;
      }
      if (Planet.ToLower() == "jupiter")
      {
        milesAway = 390674710;
      }
      if (Planet.ToLower() == "saturn")
      {
        milesAway = 792248270;
      }
      if (Planet.ToLower() == "uranus")
      {
        milesAway = 1692662530;
      }
      if (Planet.ToLower() == "neptune")
      {
        milesAway = 2703959960;
      }
      if (Planet.ToLower() == "pluto")
      {
        milesAway = 3600000000;
      }

      _travelTimeYears = (milesAway / SpeedMPH) / HOURS_YEAR;
    }
  }
}
