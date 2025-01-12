using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Business.Constants;

namespace Business.Concrete
{
    public class PaymentTypeManager : IPaymentTypeService
    {
        IPaymentTypeDal _paymentTypeDal;

        public PaymentTypeManager(IPaymentTypeDal paymentTypeDal)
        {
            _paymentTypeDal= paymentTypeDal;
        }

        public IResult Add(PaymentType paymentType)
        {
            _paymentTypeDal.Add(paymentType);
            return new SuccessResult(Messages.PaymentTypeAdd);
        }

        public IResult Deleted(int id)
        {
            PaymentType paymentType = _paymentTypeDal.Get(x => x.Id == id);
            if (paymentType!=null)
            {
                _paymentTypeDal.Delete(paymentType);
                return new SuccessResult(Messages.PaymentTypeDeleted);
            }

            return new ErrorResult(Messages.PaymentTypeNotDeleted);
        }

        public IDataResult<List<PaymentType>> GetAll()
        {
            return new SuccessDataResult<List<PaymentType>>(_paymentTypeDal.GetAll(),Messages.PaymentList);
        }

        public IDataResult<PaymentType> GetById(string name)
        {
            return new SuccessDataResult<PaymentType>(_paymentTypeDal.Get(p => p.Payment_Type == name));
        }
    }
}
