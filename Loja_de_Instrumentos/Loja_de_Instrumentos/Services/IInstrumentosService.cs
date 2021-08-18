using Loja_de_Instrumentos.Models;
using System.Collections.Generic;

namespace Loja_de_Instrumentos.Services
{
    public interface IInstrumentosService
    {
        bool Create(Instrumento instrumento);
        bool Delete(int? id);
        Instrumento Get(int id);
        List<Instrumento> GetAll(string search = null, string type = null, bool order = false);
        bool Update(Instrumento instrumentoUpdate);
    }
}