// using System.Linq;
// using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanetaryDictionary.Models;

namespace PlanetaryDictionary.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PlanetsController : ControllerBase
  {
    private readonly PlanetaryDictionaryContext _db;

    public PlanetsController(PlanetaryDictionaryContext db)
    {
      _db = db;
    }

    [HttpGet("page/{page}")]
    public async Task<ActionResult<List<Planet>>> GetPlanets(int page)
    {
      if (_db.Planets == null)
        return NotFound();

      var pageResults = 2f;
      var pageCount = Math.Ceiling(_db.Planets.Count() / pageResults);

      var planets = await _db.Planets
                      .Skip((page - 1) * (int)pageResults)
                      .Take((int)pageResults)
                      .ToListAsync();
      
      var response = new PlanetResponse
      {
        Planets = planets,
        CurrentPage = page,
        Pages = (int)pageCount
      };

      return Ok(response);
    }
    

// lesson's version of returning all planets as list
    [HttpGet]
    public async Task<List<Planet>> Get(string name, string funFact, string climate, string lifeFormDetails, int population, int minimumPopulation)
    {
      IQueryable<Planet> query = _db.Planets.AsQueryable();

      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }

      if(funFact != null)
      {
        query = query.Where(entry => entry.FunFact == funFact);
      }

      if(climate != null)
      {
        query = query.Where(entry => entry.Climate == climate);
      }

      if(lifeFormDetails != null)
      {
        query = query.Where(entry => entry.LifeFormDetails == lifeFormDetails);
      }


      // this is where they changed from !0 to > to be able to query by age; they also used minimumAge instead of age: 
      // if (minimumAge > 0)
      // {
      //   query = query.Where(entry => entry.Age >= minimumAge);
      // }
      if(population != 0) 
      {
        query = query.Where(entry => entry.Population == population);
      }

      if(minimumPopulation > 0)
      {
        query = query.Where(entry => entry.Population >= minimumPopulation);
      }

      return await query.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Planet>> GetPlanet(int id)
    {
      Planet planet = await _db.Planets.FindAsync(id);

      if (planet == null)
      {
        return NotFound();
      }

      return planet;
    }

    [HttpPost]
    public async Task<ActionResult<Planet>> Post(Planet planet)
    {
      _db.Planets.Add(planet);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetPlanet), new { id = planet.PlanetId }, planet);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Planet planet)
    {
      if (id != planet.PlanetId)
      {
        return BadRequest();
      }

      _db.Planets.Update(planet);

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!PlanetExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    private bool PlanetExists(int id)
    {
      return _db.Planets.Any(e => e.PlanetId == id);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePlanet(int id)
    {
      Planet planet = await _db.Planets.FindAsync(id);
      if (planet == null)
      {
        return NotFound();
      }

      _db.Planets.Remove(planet);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}

