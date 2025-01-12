using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class HistoryPaymentList:IEntity
    {
        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DatePaid { get; set; }
        public int UsersId { get; set; }
        public int TitleId { get; set; }
        public int CompanyId { get; set; }
        public string PlaceOfPayment { get; set; }
        public decimal Price { get; set; }
        public int PaymentTypeId { get; set; }
        public string Description { get; set; }
        
    }
}
