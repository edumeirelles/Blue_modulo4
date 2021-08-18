using Loja_de_Instrumentos.Models;
using System.Collections.Generic;

namespace Loja_de_Instrumentos.Services
{
    public interface ICategoriaService
    {
        bool Create(Categoria categoria);
        bool Delete(int? id);
        List<Categoria> Get(string categoria);
        List<Categoria> GetAll();
        bool Update(Categoria categoriaUpdate);
    }
}