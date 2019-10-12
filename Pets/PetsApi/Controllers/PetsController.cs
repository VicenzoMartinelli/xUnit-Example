using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pets.Core.Data;
using Pets.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetsApi.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class PetsController : ControllerBase
  {
    private readonly PetsContext _context;

    public PetsController(PetsContext context)
    {
      _context = context;
    }

    // GET: api/Pets
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pet>>> GetPets()
    {
      return await _context.Pets.ToListAsync();
    }

    // GET: api/Pets/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Pet>> GetPet(Guid id)
    {
      var pet = await _context.Pets.FindAsync(id);

      if (pet == null)
      {
        return NotFound();
      }

      return pet;
    }

    // PUT: api/Pets/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPet(Guid id, Pet pet)
    {
      _context.Entry(pet.SetId(id)).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!PetExists(id))
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

    // POST: api/Pets
    [HttpPost]
    public async Task<ActionResult<Pet>> PostPet(Pet pet)
    {
      _context.Pets.Add(pet);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetPet", new { id = pet.Id }, pet);
    }

    // DELETE: api/Pets/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Pet>> DeletePet(Guid id)
    {
      var pet = await _context.Pets.FindAsync(id);
      if (pet == null)
      {
        return NotFound();
      }

      _context.Pets.Remove(pet);
      await _context.SaveChangesAsync();

      return pet;
    }

    private bool PetExists(Guid id)
    {
      return _context.Pets.Any(e => e.Id == id);
    }
  }
}
