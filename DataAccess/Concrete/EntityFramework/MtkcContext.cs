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
            optionsBuilder.UseSqlServer(@"server=YOSHI\YOSHI;Database=MTKC;Trusted_Connection=true;TrustServerCertificate=true");
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<PaymentType> PaymentType { get; set; }
        public DbSet<Title> Title { get; set; }
        public DbSet<PaymentList> PaymentList { get; set; }



    }
}
