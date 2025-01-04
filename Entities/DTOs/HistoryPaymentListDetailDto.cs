using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.DTOs
{
    public class HistoryPaymentListDetailDto:IDto
    {
        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DatePaid { get; set; }
        public string UserName { get; set; }
        public string CompanyName { get; set; }
        public string PaymentOfPlace { get; set; }
        public string PaymentType { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
