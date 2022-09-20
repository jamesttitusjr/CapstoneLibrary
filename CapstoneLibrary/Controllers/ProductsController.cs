using CapstoneLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneLibrary.Controllers
{
    public class ProductsController
    {
        private readonly AppDbContext _context = null!;
        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.OrderBy(e => e.Name);
        }

        public Product GetByPK(int Id)
        {
            return _context.Products.Find(Id);
        }

        public IEnumerable<Product> GetByNamePartial(string subString)

        {
            IEnumerable<Product> products = from e in _context.Products
                                           where e.Name.contains(subString)
                                          orderby e.Name
                                          select e;
            return Products;
        }
        public void Update(int Id, Product product)
        {
            if (Id != product.Id)
            {
                throw new ArgumentException("Product id doesn't match product instance!");
            }
            _context.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return;

            public Product Insert(Product product)
            {
                if (product.Id! = 0)
                {
                    throw new ArgumentException("Inserting a new product requires the Id be set to 0!");
                }
                _context.Products.Add(product);
                _context.SaveChanges();
                return product;

            }
            public void Delete(int Id)
            {
                Product? product = GetByPK(int Id);
                if (product is null)
                {
                    throw new Exception("Product not found");
                }
                _context.Remove(product);
                _context.SaveChanges();
            }

        }
    }
}
