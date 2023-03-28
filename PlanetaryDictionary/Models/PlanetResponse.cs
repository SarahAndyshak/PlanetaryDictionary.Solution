using PlanetaryDictionary.Models;

namespace PlanetaryDictionary
{
  public class PlanetResponse
  {
    public List<Planet> Planets { get; set; } = new List<Planet>();
    public int Pages { get; set; }
    public int CurrentPage { get; set; }
  }
}