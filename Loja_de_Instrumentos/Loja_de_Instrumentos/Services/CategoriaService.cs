using Loja_de_Instrumentos.Data;
using Loja_de_Instrumentos.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Loja_de_Instrumentos.Services
{
    public class CategoriaService : ICategoriaService
    {
        LojaDeInstrumentosContext _context;
        public CategoriaService(LojaDeInstrumentosContext context)
        {
            _context = context;
        }
        public List<Categoria> GetAll()
        {
            return _context.Categoria.Include(x => x.Instrumento).ToList();
        }
        public List<Categoria> Get(string categoria)
        {
            return _context.Categoria.Where(x => x.InstrumentoCategoria == categoria).ToList();
        }
        public bool Create(Categoria categoria)
        {
            try
            {
                _context.Categoria.Add(categoria);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(Categoria categoriaUpdate)
        {
            _context.Categoria.Update(categoriaUpdate);
            _context.SaveChanges();
            return true;
        }
        public bool Delete(int? id)
        {
            Categoria categoria = GetCategoria().FirstOrDefault(x => x.Id == id);
            _context.Categoria.Remove(categoria);
            _context.SaveChanges();
            return true;
        }
        List<Categoria> GetCategoria()
        {
            List<Categoria> categoria = _context.Categoria.ToList();
            return categoria;
        }
    }
}
