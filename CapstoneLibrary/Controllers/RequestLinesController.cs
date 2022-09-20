using CapstoneLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneLibrary.Controllers
{
    public class RequestLinesController
    {
        private readonly AppDbContext _context = null!;
        public RequestLinesController(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<RequestLine> GetAll()
        {
            return _context.RequestLines.OrderBy(e => e.ProductId);
        }

        public RequestLine GetByPK(int Id)
        {
            return _context.RequestLines.Find(Id);
        }

        public IEnumerable<RequestLine> GetByProductIdPartial(string subString)

        {
            IEnumerable<RequestLine> RequestLines = from e in _context.RequestLines
                                                where e.ProductId.contains(subString)
                                            orderby e.ProductId
                                                select e;
            return RequestLines;
        }
        public void Update(int Id, RequestLine requestLine)
        {
            if (Id != requestLine.Id)
            {
                throw new ArgumentException("RequestLine id doesn't match product instance!");
            }
            _context.Entry(requestLine).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return;

            public RequestLine Insert(RequestLine requestLine)
            {
                if (requestLine.Id! = 0)
                {
                    throw new ArgumentException("Inserting a new requestLine requires the Id be set to 0!");
                }
                _context.RequestLines.Add(requestLine);
                _context.SaveChanges();
                return requestLine;

            }
            public void Delete(int Id)
            {
                RequestLine? requestLine = GetByPK(int Id);
                if (requestLine is null)
                {
                    throw new Exception("RequestLine not found");
                }
                _context.Remove(requestLine);
                _context.SaveChanges();
            }

        }
    }
}
