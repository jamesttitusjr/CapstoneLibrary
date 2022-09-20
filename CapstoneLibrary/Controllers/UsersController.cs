using CapstoneLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneLibrary.Controllers
{
    public class UsersController
    {
        private readonly AppDbContext _context = null!;
        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.OrderBy(e => e.Firstname);
        }

        public User GetByPK(int Id)
        {
            return _context.Users.Find(Id);
        }

        public IEnumerable<User> GetByFirstnamePartial(string subString)

        {
            IEnumerable<User> users = from e in _context.Users
                                          where e.Firstname.contains(subString)
                                              orderby e.Firstname
                                              select e;
            return Users;
        }
        public void Update(int Id, User user)
        {
            if (Id != user.Id)
            {
                throw new ArgumentException("User id doesn't match user instance!");
            }
            _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return;

            public User Insert(User user)
            {
                if (user.Id! = 0)
                {
                    throw new ArgumentException("Inserting a new user requires the Id be set to 0!");
                }
                _context.Users.Add(user);
                _context.SaveChanges();
                return user;

            }
            public void Delete(int Id)
            {
                User? user = GetByPK(int Id);
                if (user is null)
                {
                    throw new Exception("User not found");
                }
                _context.Remove(user);
                _context.SaveChanges();
            }

        }
    }
}
