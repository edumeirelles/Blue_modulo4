using LojaDeInstrumentosAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaDeInstrumentosAPI.Services
{
    public interface IInstrumentService
    {
        List<Instrument> All();
        Instrument Get(int? id);
        bool Create(Instrument instrument);
        bool Update(Instrument instrument);
        bool Delete(int? id);
        List<Instrument> InstrumentByUserRole(string role);
    }
}
