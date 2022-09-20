using CapstoneLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneLibrary.Controllers
{
    public class VendorsController
    {
        private readonly AppDbContext _context = null!;
        public VendorsController(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Vendor> GetAll()
        {
            return _context.Vendors.OrderBy(e => e.Name);
        }

        public Vendor GetByPK(int Id)
        {
            return _context.Vendors.Find(Id);
        }

        public IEnumerable<Vendor> GetByNamePartial(string subString)

        {
            IEnumerable<Vendor> vendors = from e in _context.Vendors
                                          where e.Name.contains(subString)
                                      orderby e.Name
                                      select e;
            return Vendors;
        }
        public void Update(int Id, Vendor vendor)
        {
            if (Id != vendor.Id)
            {
                throw new ArgumentException("Vendor id doesn't match vendor instance!");
            }
            _context.Entry(vendor).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return;

            public Vendor Insert(Vendor vendor)
            {
                if (vendor.Id! = 0)
                {
                    throw new ArgumentException("Inserting a new vendor requires the Id be set to 0!");
                }
                _context.Vendors.Add(vendor);
                _context.SaveChanges();
                return vendor;

            }
            public void Delete(int Id)
            {
                Vendor? vendor = GetByPK(int Id);
                if (vendor is null)
                {
                    throw new Exception("Vendor not found");
                }
                _context.Remove(vendor);
                _context.SaveChanges();
            }

        }
    }
}
