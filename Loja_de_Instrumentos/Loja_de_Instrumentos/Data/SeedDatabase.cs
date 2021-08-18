using Loja_de_Instrumentos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;

namespace Loja_de_Instrumentos.Data
{
    public static class SeedDatabase
    {
        public static void Initialize(IHost app)
        {
            using (var scope = app.Services.CreateScope())
            {
                Random rdn = new();

                var serviceProvider = scope.ServiceProvider;
                var context = serviceProvider.GetRequiredService<LojaDeInstrumentosContext>();
                context.Database.Migrate();
                if (!context.Instrumento.Any())
                {
                    context.Instrumento.Add(new Instrumento()
                    {
                        Type = "Guitarra",
                        Brand = "Fender",
                        Model = "Stratocaster",
                        Description = "A Fender Stratocaster é um modelo de guitarra elétrica desenhada por Leo Fender, " +
                        "George Fullerton e Freddie Tavares em 1954.",
                        Price = 9999.99,
                        Link = "https://images.musicstore.de/images/1280/fender-75th-anniversary-commemorative-stratocaster_1_GIT0055575-000.jpg"
                    });
                    context.Instrumento.Add(new Instrumento()
                    {
                        Type = "Guitarra",
                        Brand = "Gibson",
                        Model = "SG",
                        Description = "Gibson SG é um dos mais conhecidos modelo de guitarra " +
                        "elétrica, de corpo sólido surgido no começo dos anos 60.",
                        Price = 12999.99,
                        Link = "https://reference.vteximg.com.br/arquivos/ids/285617-1000-1000/frontal.jpg?v=636286502567700000"
                    });
                    context.Instrumento.Add(new Instrumento()
                    {
                        Type = "Violão",
                        Brand = "Martin",
                        Model = "DJR2E",
                        Description = "A C.F. Martin & Company é uma fabricante de violões dos Estados Unidos, estabelecida" +
                        " em 1833 por Christian Frederick Martin, que nasceu em 1796 na cidade de Markneukirchen na Alemanha.",
                        Price = 5999.99,
                        Link = "https://images-na.ssl-images-amazon.com/images/I/815LrvftyWL.jpg"
                    });
                    context.Instrumento.Add(new Instrumento()
                    {
                        Type = "Violão",
                        Brand = "Epiphone",
                        Model = "DR-100",
                        Description = "The DR-100 features chrome hardware, a 25.5' scale, 1.68' nut width, set mahogany neck with dot inlays, mahogany body and select spruce top.",
                        Price = 1499.99,
                        Link = "https://sc1.musik-produktiv.com/pic-100009980xl/epiphone-dr-100-na.jpg"
                    });
                    context.Instrumento.Add(new Instrumento()
                    {
                        Type = "Guitarra",
                        Brand = "Gibson",
                        Model = "Les Paul",
                        Description = "Gibson Les Paul é uma guitarra de corpo sólido que começou a ser vendida em 1952.",
                        Price = 24999.99,
                        Link = "https://x5music.vteximg.com.br/arquivos/ids/183227-1920-1920/GUITARRA-GIBSON-TRADITIONAL-LESPAUL-Honey-Burst-COM-CASE.jpg"
                    });
                    context.Instrumento.Add(new Instrumento()
                    {
                        Type = "Bateria",
                        Brand = "Pearl",
                        Model = "EXPORT EXX725S",
                        Description = "As lendas de amanhã tocam com a Pearl Export hoje. A Export Series agora incorpora a tecnologia de suspensão Pearl's S.S.T., montagem de tom Opti-Loc e acabamento Grindstone Sparkle.",
                        Price = 5199.99,
                        Link = "https://x5music.vteximg.com.br/arquivos/ids/170212-1920-1920/EXX725S-708.jpg"
                    });
                    context.SaveChanges();
                }
                if (!context.Categoria.Any())
                {
                    var instrumentos = context.Instrumento.ToList();
                    context.Categoria.Add(new Categoria()
                    {
                        InstrumentoCategoria = "Cordas",
                        InstrumentoId = instrumentos[0].Id
                    });
                    context.Categoria.Add(new Categoria()
                    {
                        InstrumentoCategoria = "Cordas",
                        InstrumentoId = instrumentos[1].Id
                    });
                    context.Categoria.Add(new Categoria()
                    {
                        InstrumentoCategoria = "Cordas",
                        InstrumentoId = instrumentos[2].Id
                    });
                    context.Categoria.Add(new Categoria()
                    {
                        InstrumentoCategoria = "Cordas",
                        InstrumentoId = instrumentos[3].Id
                    });
                    context.Categoria.Add(new Categoria()
                    {
                        InstrumentoCategoria = "Cordas",
                        InstrumentoId = instrumentos[4].Id
                    });
                    context.Categoria.Add(new Categoria()
                    {
                        InstrumentoCategoria = "Percussão",
                        InstrumentoId = instrumentos[5].Id
                    });
                    context.SaveChanges();
                }
                

            }
        }
    }
}
