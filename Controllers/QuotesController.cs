using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using moneyme_api.Models;

namespace moneyme_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly LoanContext _context;

        public QuotesController(LoanContext context)
        {
            _context = context;
        }

        // GET: api/Quotes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quote>>> GetQuotes()
        {
            return await _context.Quotes.ToListAsync();
        }

        // GET: api/Quotes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Quote>> GetQuote(long id)
        {
            var quote = await _context.Quotes.FindAsync(id);

            if (quote == null)
            {
                return NotFound();
            }

            return quote;
        }

        // PUT: api/Quotes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuote(long id, [FromBody] Quote quote)
        {
            //if (id != quote.id)
            //{
            //    return BadRequest();
            //}

            _context.Entry(quote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuoteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(quote);
        }

        // POST: api/Quotes
        [HttpPost]
        public async Task<ActionResult<Quote>> PostQuote([FromBody] Quote quote)
        {
            _context.Quotes.Add(quote);
            await _context.SaveChangesAsync();

            var result = new OkObjectResult(new { returnUrl = "http://localhost:3000/?" + quote.id.ToString() });
            return result;

        }

        // DELETE: api/Quotes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Quote>> DeleteQuote(long id)
        {
            var quote = await _context.Quotes.FindAsync(id);
            if (quote == null)
            {
                return NotFound();
            }

            _context.Quotes.Remove(quote);
            await _context.SaveChangesAsync();

            return quote;
        }

        private bool QuoteExists(long id)
        {
            return _context.Quotes.Any(e => e.id == id);
        }
    }
}
