using Consultorio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;

namespace Consultorio.Data
{
    public static class SeedDatabase
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
           
            int qtd_registros = 20;

            string[] nomes = new string[] { "Eduardo", "Jorge", "Janio", "Nivia", "Ricardo", "Eurico", "Italo", "Paula", "João", "Maria", "Arnold", "Tom", "Bruce", "Bob", "John", "Paul", "George", "Ringo", "David", "Zé" };
            string[] sobrenomes = new string[] { "Santos", "Silva", "Souza", "Teixeira", "Meirelles", "Nogueira", "Siveira", "Ferrari", "Barros", "Lino", "Russi", "Smith", "Nicacio", "Suzuki", "Utiama", "McCartney", "Guilmour", "Lennon", "Harrison", "Dylan" };

            using (var context = new ConsultorioContext(serviceProvider.GetRequiredService<DbContextOptions<ConsultorioContext>>()))
            {
                if (context.Paciente.Any())
                {
                    return;
                }
                for (int i = 0; i < qtd_registros; i++)
                {
                    Random rand = new Random();
                    var nomeCompleto = $"{nomes[rand.Next(0, nomes.Length)]} {sobrenomes[rand.Next(0, sobrenomes.Length)]}";

                    var nasc = new DateTime(1950, 1, 1);
                    int dias = (DateTime.Today - nasc).Days;
                    nasc = nasc.AddDays(rand.Next(dias));

                    string telefone = rand.Next(100000000, 999999999).ToString();
                    string ddd = rand.Next(10, 99).ToString();

                    context.Paciente.AddRange(
                        new Paciente
                        {
                            Nome = nomeCompleto,
                            Nascimento = nasc,
                            Telefone = $"{ddd} {telefone}"
                        });
                }
                context.SaveChanges();
            }

            
            
        }
    }
}
