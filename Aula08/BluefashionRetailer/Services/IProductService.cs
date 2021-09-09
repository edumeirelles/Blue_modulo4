using BluefashionRetailer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BluefashionRetailer.Services
{
    public interface IProductService
    {
        List<Product> All();
        Product Get(int? id);
        bool Create(Product product);
        bool Update(Product product);
        bool Delete(int? id);
    }
}
