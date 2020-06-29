using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using moneyme_api.Models;

namespace moneyme_api.Models
{
    public class LoanContext : DbContext
    {
        public LoanContext(DbContextOptions<LoanContext> options) : base(options)
        {
        }

        public DbSet<Quote> Quotes { get; set; }

        public DbSet<CustomerRequestLoan> CustomerRequestLoan { get; set; }
        
    }
}
