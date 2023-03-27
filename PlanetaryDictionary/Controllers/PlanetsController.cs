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

    [HttpGet]
    public async Task<List<Planet>> Get(string name, string funFact, string climate, string lifeFormDetails, int population)
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

      if(population != 0)
      {
        query = query.Where(entry => entry.Population == population);
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

