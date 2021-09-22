using Loja_de_Instrumentos.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Loja_de_Instrumentos.Data
{
    public class Context : IdentityDbContext
    {
        public Context(DbContextOptions<Context> options) :base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Message>()
                .HasOne<AppUser>(a => a.appUser)
                .WithMany(d => d.Messages)
                .HasForeignKey(d => d.userId);
        }

        public DbSet<Message> Message { get; set; }
        public DbSet<Instrumento> Instrumento { get; set; }
        public DbSet<Acessorio> Acessorio { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
      
    }
}
