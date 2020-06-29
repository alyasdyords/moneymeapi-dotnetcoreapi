using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using moneyme_api.Models;

namespace moneyme_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerRequestLoansController : ControllerBase
    {
        private readonly LoanContext _context;

        public CustomerRequestLoansController(LoanContext context)
        {
            _context = context;
        }

        // GET: api/CustomerRequestLoans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerRequestLoan>>> GetCustomerRequestLoan()
        {
            return await _context.CustomerRequestLoan.ToListAsync();
        }

        // GET: api/CustomerRequestLoans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerRequestLoan>> GetCustomerRequestLoan(long id)
        {
            var customerRequestLoan = await _context.CustomerRequestLoan.FindAsync(id);

            if (customerRequestLoan == null)
            {
                return NotFound();
            }

            return customerRequestLoan;
        }

        // PUT: api/CustomerRequestLoans/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerRequestLoan(long id, CustomerRequestLoan customerRequestLoan)
        {
            if (id != customerRequestLoan.id)
            {
                return BadRequest();
            }

            _context.Entry(customerRequestLoan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerRequestLoanExists(id))
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

        // POST: api/CustomerRequestLoans
        [HttpPost]
        public async Task<ActionResult<CustomerRequestLoan>> PostCustomerRequestLoan([FromBody] CustomerRequestLoan customerRequestLoan)
        {
            _context.CustomerRequestLoan.Add(customerRequestLoan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomerRequestLoan", new { id = customerRequestLoan.id }, customerRequestLoan);
        }

        // DELETE: api/CustomerRequestLoans/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomerRequestLoan>> DeleteCustomerRequestLoan(long id)
        {
            var customerRequestLoan = await _context.CustomerRequestLoan.FindAsync(id);
            if (customerRequestLoan == null)
            {
                return NotFound();
            }

            _context.CustomerRequestLoan.Remove(customerRequestLoan);
            await _context.SaveChangesAsync();

            return customerRequestLoan;
        }

        private bool CustomerRequestLoanExists(long id)
        {
            return _context.CustomerRequestLoan.Any(e => e.id == id);
        }
    }
}
