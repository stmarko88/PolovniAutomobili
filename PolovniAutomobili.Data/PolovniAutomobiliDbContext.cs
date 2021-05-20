using Microsoft.EntityFrameworkCore;
using PolovniAutomobili.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolovniAutomobili.Data
{
    public class PolovniAutomobiliDbContext : DbContext
    {
        public PolovniAutomobiliDbContext(DbContextOptions<PolovniAutomobiliDbContext> options) : base(options)
        {

        }
        public DbSet<Automobil> Car { get; set; }
    }
}
