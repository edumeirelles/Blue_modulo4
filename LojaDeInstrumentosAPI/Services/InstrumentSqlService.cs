using LojaDeInstrumentosAPI.Data;
using LojaDeInstrumentosAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LojaDeInstrumentosAPI.Services
{
    public class InstrumentSqlService : IInstrumentService
    {
        LojaDeInstrumentosAPIContext _context;
        public InstrumentSqlService(LojaDeInstrumentosAPIContext context)
        {
            _context = context;
        }
        public List<Instrument> All()
        {
            return _context.Instrument.ToList();
        }
        public bool Create(Instrument instrument)
        {
            try
            {
                instrument.created = DateTime.Now;
                _context.Add(instrument);
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
            if (!_context.Instrument.Any(x => x.Id == id))                
                return false;
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
        public Instrument Get(int? id)
        {
            return _context.Instrument.FirstOrDefault(x => x.Id == id);
        }

        public List<Instrument> InstrumentByUserRole(string getRole)
        {
            //var query1 =
            //        "USE LojaDeInstrumentosAPI "+
            //        "DECLARE @role varchar(10); "+
            //        $"SET @role = '{role}' "+
            //        "SELECT i.* FROM Instrument i " +
            //        "JOIN AspNetUsers u ON i.createdById = u.Id " +
            //        "JOIN AspNetUserRoles ur ON u.Id = ur.UserId " +
            //        "JOIN AspNetRoles r ON ur.RoleId = r.Id " +
            //        "WHERE r.Name = @role";

            var lquery1 =
                from instrument in _context.Set<Instrument>()
                join user in _context.Set<IdentityUser>()
                on instrument.createdById equals user.Id
                join userRoles in _context.Set<IdentityUserRole<string>>()
                on user.Id equals userRoles.UserId
                join role in _context.Set<IdentityRole>()
                on userRoles.RoleId equals role.Id
                where role.Name.ToUpper() == getRole
                select new Instrument()
                    {
                        Id = instrument.Id,
                        Brand = instrument.Brand,
                        Model = instrument.Model,
                        Description = instrument.Description,
                        Price = instrument.Price,
                        created = instrument.created,
                        updated = instrument.updated,
                        createdById = instrument.createdById,
                        updatedById = instrument.updatedById,
                    };

            return lquery1.ToList();
        }

        public bool Update(Instrument instrument)
        {
            if (!_context.Instrument.Any(x => x.Id == instrument.Id))
                return false;
            try
            {
                instrument.updated = DateTime.Now;
                _context.Update(instrument);
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