using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.DTOs
{
    public class PaymentListDetailDto:IDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public string CompanyName { get; set; }
        public string PaymentOfPlace { get; set; }
        public string PaymentType { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
