using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Handi_Crafti_API_Backend.Data;
using Handi_Crafti_API_Backend.DataBase.DBModels;

namespace Handi_Crafti_API_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public OffersController(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        // GET: api/Offers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Offer>>> GetOffers()
        {
          if (_db.Offers == null)
          {
              return NotFound();
          }
            return await _db.Offers.ToListAsync();
        }

        // GET: api/Offers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Offer>> GetOffer(Guid id)
        {
          if (_db.Offers == null)
          {
              return NotFound();
          }
            var offer = await _db.Offers.FindAsync(id);

            if (offer == null)
            {
                return NotFound();
            }

            return offer;
        }

        // PUT: api/Offers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOffer(Guid id, Offer offer)
        {
            if (id != offer.Id)
            {
                return BadRequest();
            }

            _db.Entry(offer).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfferExists(id))
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

        // POST: api/Offers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Offer>> PostOffer(Offer offer)
        {
          if (_db.Offers == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Offers'  is null.");
          }
            _db.Offers.Add(offer);
            await _db.SaveChangesAsync();

            return CreatedAtAction("GetOffer", new { id = offer.Id }, offer);
        }

        // DELETE: api/Offers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOffer(Guid id)
        {
            if (_db.Offers == null)
            {
                return NotFound();
            }
            var offer = await _db.Offers.FindAsync(id);
            if (offer == null)
            {
                return NotFound();
            }

            _db.Offers.Remove(offer);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        private bool OfferExists(Guid id)
        {
            return (_db.Offers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
