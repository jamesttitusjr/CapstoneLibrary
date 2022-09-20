using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneLibrary.Models
{
    public class AppDbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            string connStr = @"server=localhost\sqlexpress;" +
                              "database=PRS;" +
                              "trusted_connection=true;";
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(connStr);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
    }
}
