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
            optionsBuilder.UseSqlServer(@"Server=mtkc.c9sq2as4s1oa.eu-central-1.rds.amazonaws.com;Database=MTKC;User Id=admin;Password=Sinan7980;TrustServerCertificate=True;");
            string connectionString = "";

        }

        public DbSet<Users> Users { get; set; } 
        public DbSet<Company> Company { get; set; } 
        public DbSet<PaymentType> PaymentType { get; set; }
        public DbSet<Title> Title { get; set; }
        public DbSet<PaymentList> PaymentList { get; set; }
        public DbSet<HistoryPaymentList> HistoryPaymentList { get; set; }



    }
}
