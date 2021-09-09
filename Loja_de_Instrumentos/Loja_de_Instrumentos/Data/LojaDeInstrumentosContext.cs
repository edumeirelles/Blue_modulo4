using Loja_de_Instrumentos.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Loja_de_Instrumentos.Data
{
    public class LojaDeInstrumentosContext : IdentityDbContext
    {
        public LojaDeInstrumentosContext(DbContextOptions<LojaDeInstrumentosContext> options) :base(options)
        {
                
        }
        public DbSet<Instrumento> Instrumento { get; set; }
        public DbSet<Acessorio> Acessorio { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
      
    }
}
