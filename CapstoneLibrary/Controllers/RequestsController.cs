using CapstoneLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneLibrary.Controllers
{
    public class RequestsController
    {
        private readonly AppDbContext _context = null!;
        public RequestsController(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Request> GetAll()
        {
            return _context.Requests.OrderBy(e => e.Description);
        }

        public Request GetByPK(int Id)
        {
            return _context.Requests.Find(Id);
        }

        public IEnumerable<Request> GetByDescriptionPartial(string subString)

        {
            IEnumerable<Request> requests = from e in _context.Requests
                                            where e.Description.contains(subString)
                                            orderby e.Description
                                            select e;
            return Requests;
        }
        public void Update(int Id, Request request)
        {
            if (Id != request.Id)
            {
                throw new ArgumentException("Request id doesn't match product instance!");
            }
            _context.Entry(request).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return;

            public Request Insert(Request request)
            {
                if (request.Id! = 0)
                {
                    throw new ArgumentException("Inserting a new request requires the Id be set to 0!");
                }
                _context.Requests.Add(request);
                _context.SaveChanges();
                return request;

            }
            public void Delete(int Id)
            {
                Request? request = GetByPK(int Id);
                if (request is null)
                {
                    throw new Exception("Request not found");
                }
                _context.Remove(request);
                _context.SaveChanges();
            }

        }
    }
}
