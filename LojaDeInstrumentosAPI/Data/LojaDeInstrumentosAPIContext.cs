using LojaDeInstrumentosAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaDeInstrumentosAPI.Data
{
    public class LojaDeInstrumentosAPIContext: IdentityDbContext
    {
        public LojaDeInstrumentosAPIContext(DbContextOptions<LojaDeInstrumentosAPIContext> options) : base(options) { }
        
        public DbSet<Instrument> Instrument { get; set; }
    }
}
