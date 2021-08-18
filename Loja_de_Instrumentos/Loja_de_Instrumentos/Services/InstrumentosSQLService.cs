using Loja_de_Instrumentos.Data;
using Loja_de_Instrumentos.Models;
using System.Collections.Generic;
using System.Linq;

namespace Loja_de_Instrumentos.Services
{
    public class InstrumentosSQLService : IInstrumentosService
    {
        LojaDeInstrumentosContext _context;
        public InstrumentosSQLService(LojaDeInstrumentosContext context)
        {
            _context = context;
        }
        public List<Instrumento> GetAll(string search = null, string type = null, bool order = false)
        {
            var types = GetInstruments().FindAll(x => x.Type == type);
       
            if (type != null)
                return types;
            else
            {
                if (order)
                    return GetInstruments().OrderBy(x => x.Model).ToList();

                if (search != null)
                    return GetInstruments().FindAll(x => x.Brand.ToUpper().Contains(search.ToUpper()) || x.Model.ToUpper().Contains(search.ToUpper()));
                return GetInstruments();
            }
        }
        public Instrumento Get(int id)
        {
            return GetInstruments().FirstOrDefault(x => x.Id == id);
        }
        public bool Create(Instrumento instrumento)
        {
            try
            {
                _context.Add(instrumento);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(Instrumento instrumentoUpdate)
        {
            _context.Instrumento.Update(instrumentoUpdate);
            _context.SaveChanges();
            return true;
        }
        public bool Delete(int? id)
        {
            Instrumento instrumento = GetInstruments().FirstOrDefault(x => x.Id == id);
            _context.Instrumento.Remove(instrumento);
            _context.SaveChanges();
            return true;
        }
        List<Instrumento> GetInstruments()
        {
            List<Instrumento> instrumentos = _context.Instrumento.ToList();
            return instrumentos;
        }


    }
}
