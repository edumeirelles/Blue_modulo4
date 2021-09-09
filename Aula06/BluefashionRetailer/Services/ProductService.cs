using BluefashionRetailer.Data;
using BluefashionRetailer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BluefashionRetailer.Services
{
    public class ProductService : IProductService
    {
        BFRContext _context;

        public ProductService(BFRContext context)
        {
            _context = context;
        }
        public List<Product> All()
        {
            return _context.Product.ToList();
        }

        public bool Create(Product product)
        {
            try
            {
                _context.Add(product);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int? id)
        {
            if (!_context.Product.Any(x => x.Id == id))
                throw new Exception("Produto não existe");
            try
            {
                _context.Remove(this.Get(id));
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Product Get(int? id)
        {
            return _context.Product.FirstOrDefault(x => x.Id == id);
        }

        public bool Update(Product product)
        {
            if (!_context.Product.Any(x => x.Id == product.Id))
                throw new Exception("Produto não existe");

            try
            {
                _context.Update(product);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
