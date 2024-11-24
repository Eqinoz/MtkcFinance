using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PaymentTypeManager : IPaymentTypeService
    {
        IPaymentTypeDal _paymentTypeDal;

        public PaymentTypeManager(IPaymentTypeDal paymentTypeDal)
        {
            _paymentTypeDal= paymentTypeDal;
        }
        public List<PaymentType> GetAll()
        {
            return _paymentTypeDal.GetAll();
        }
    }
}
