using BlueWebChat.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueWebChat.Data
{
    public class Context : IdentityDbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Message>()
                .HasOne<AppUser>(a => a.appUser)
                .WithMany(d => d.Messages)
                .HasForeignKey(d => d.userId);
        }

        public DbSet<Message> Message { get; set; }
    }
}
