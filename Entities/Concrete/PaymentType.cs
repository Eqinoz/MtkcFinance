using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class PaymentType:IEntity
    {
        public int Id { get; set; }
        public string? Payment_Type { get; set; }
    }
}
