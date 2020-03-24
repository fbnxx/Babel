using Babel.Domain.Business;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Babel.Data.Context
{
    public class BabelDbContext : DbContext
    {
        public DbSet<Book> Book { get; set; }

        public BabelDbContext(DbContextOptions<BabelDbContext> options) : base(options)
        {

        }
    }
}
