using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WishlistService.Data;
using WishlistService.Models;

namespace WishlistService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistController : ControllerBase
    {
        private readonly WishlistDbContext _context;

        public WishlistController(WishlistDbContext context)
        {
            _context = context;
        }

        // GET: api/wishlist
        [HttpGet]
        public async Task<IActionResult> GetAllWishlists()
        {
            var wishlists = await _context.Wishlists.Include(w => w.Items).ToListAsync();
            return Ok(wishlists);
        }

        // GET: api/wishlist/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWishlist(int id)
        {
            var wishlist = await _context.Wishlists.Include(w => w.Items).FirstOrDefaultAsync(w => w.Id == id);

            if (wishlist == null)
                return NotFound();

            return Ok(wishlist);
        }

        // POST: api/wishlist
        [HttpPost]
        public async Task<IActionResult> CreateWishlist([FromBody] Wishlist wishlist)
        {
            wishlist.CreatedAt = DateTime.UtcNow;
            _context.Wishlists.Add(wishlist);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetWishlist), new { id = wishlist.Id }, wishlist);
        }

        // PUT: api/wishlist/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWishlist(int id, [FromBody] Wishlist wishlist)
        {
            if (id != wishlist.Id)
                return BadRequest();

            _context.Entry(wishlist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Wishlists.Any(w => w.Id == id))
                    return NotFound();

                throw;
            }

            return NoContent();
        }

        // DELETE: api/wishlist/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWishlist(int id)
        {
            var wishlist = await _context.Wishlists.FindAsync(id);
            if (wishlist == null)
                return NotFound();

            _context.Wishlists.Remove(wishlist);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
