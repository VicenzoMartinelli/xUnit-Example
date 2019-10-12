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
  [Route("pets-banhos")]
  [ApiController]
  public class BanhoPetsController : ControllerBase
  {
    private readonly PetsContext _context;

    public BanhoPetsController(PetsContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BanhoPet>>> GetBanhos()
    {
      return await _context.Banhos.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BanhoPet>> GetBanhoPet(Guid id)
    {
      var banhoPet = await _context.Banhos.FindAsync(id);

      if (banhoPet == null)
      {
        return NotFound();
      }

      return banhoPet;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutBanhoPet(Guid id, BanhoPet banhoPet)
    {
      if (id != banhoPet.Id)
      {
        return BadRequest();
      }

      _context.Entry(banhoPet).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!BanhoPetExists(id))
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

    [HttpPost]
    public async Task<ActionResult<BanhoPet>> PostBanhoPet(BanhoPet banhoPet)
    {
      _context.Banhos.Add(banhoPet);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetBanhoPet", new { id = banhoPet.Id }, banhoPet);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<BanhoPet>> DeleteBanhoPet(Guid id)
    {
      var banhoPet = await _context.Banhos.FindAsync(id);
      if (banhoPet == null)
      {
        return NotFound();
      }

      _context.Banhos.Remove(banhoPet);
      await _context.SaveChangesAsync();

      return banhoPet;
    }

    private bool BanhoPetExists(Guid id)
    {
      return _context.Banhos.Any(e => e.Id == id);
    }
  }
}
