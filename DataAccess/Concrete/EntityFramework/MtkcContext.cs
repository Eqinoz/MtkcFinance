using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class MtkcContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:mtkc.database.windows.net,1433;Initial Catalog=mtk;Persist Security Info=False;User ID=sinan;Password=Ozuncu13579;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        public DbSet<Users> Users { get; set; } 
        public DbSet<Company> Company { get; set; } 
        public DbSet<PaymentType> PaymentType { get; set; }
        public DbSet<Title> Title { get; set; }
        public DbSet<PaymentList> PaymentList { get; set; }



    }
}
