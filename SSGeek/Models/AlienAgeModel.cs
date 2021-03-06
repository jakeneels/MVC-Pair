﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSGeek.Models
{
  public class AlienAgeModel
  {
    private double _age;
    private double _planetage;
    public string Planet { get; set; }
    public double Age
    {
      get { return _age; }
      set { _age = value; }
    }

    public double PlanetAge
    {
      get
      {
        return _planetage;
      }
    }

    public void SetPlanetAge()
    {
      if (Planet.ToLower() == "mercury")
      {
        _planetage = _age * 4.153;
      }
      if (Planet.ToLower() == "venus")
      {
        _planetage = _age * 1.626;
      }
      if (Planet.ToLower() == "mars")
      {
        _planetage = _age *0.532;
      }
      if (Planet.ToLower() == "jupiter")
      {
        _planetage = _age / 11.862;
      }
      if (Planet.ToLower() == "saturn")
      {
        _planetage = _age /29.456;
      }
      if (Planet.ToLower() == "uranus")
      {
        _planetage = _age / 84.07;
      }
      if (Planet.ToLower() == "neptune")
      {
        _planetage = _age /164.81;
      }
      if (Planet.ToLower() == "pluto")
      {
        _planetage = _age / 247.7;
      }
    }
  }
}