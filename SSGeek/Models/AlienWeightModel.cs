using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSGeek.Models
{
  public class AlienWeightModel
  {
    private double _weight;
    private double _planetWeight;
    public string Planet { get; set; }
    public double Weight {
      get { return _weight; }
      set { _weight = value; }
    }

    public double PlanetWeight {
      get
      {
        return _planetWeight;
      }
    }

    public void SetPlanetWeight()
    {
      if (Planet.ToLower() == "mercury")
      {
        _planetWeight = _weight * 0.37;
      }
      if (Planet.ToLower() == "venus")
      {
        _planetWeight = _weight * 0.9;
      }
      if (Planet.ToLower() == "mars")
      {
        _planetWeight = _weight * 0.38;
      }
      if (Planet.ToLower() == "jupiter")
      {
        _planetWeight = _weight * 2.65;
      }
      if (Planet.ToLower() == "saturn")
      {
        _planetWeight = _weight * 1.13;
      }
      if (Planet.ToLower() == "uranus")
      {
        _planetWeight = _weight * 1.09;
      }
      if (Planet.ToLower() == "neptune")
      {
        _planetWeight = _weight * 1.43;
      }
      if (Planet.ToLower() == "pluto")
      {
        _planetWeight = _weight * 0.04;
      }
    }
  }
}