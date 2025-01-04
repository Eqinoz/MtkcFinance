using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class PaymentListManager:IPaymentListService
    {
         IPaymentListDal _paymentListDal;
         IUserService _userService;
        public PaymentListManager(IPaymentListDal paymentListDal, IUserService userService)
        {
            _paymentListDal= paymentListDal;
            _userService= userService;
        }

        public IResult Add(PaymentList paymentList)
        {
            _paymentListDal.Add(paymentList);
            return new SuccessResult(Messages.SuccessPaymentList);
        }

        public IResult Deleted(int id)
        {
            PaymentList paymentList = _paymentListDal.Get(x => x.Id == id);
            if (paymentList != null)
            {
                _paymentListDal.Delete(paymentList);
                return new Result(true, Messages.PaymentDeleted);
            }

            return new Result(false, Messages.PaymentNotDeleted);
        }

        public IDataResult<PaymentListDetailDto> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<PaymentListDetailDto> Get(string name)
        {
            var result = _paymentListDal.GetAll();
            return new SuccessDataResult<PaymentListDetailDto>();
        }

        

        public IDataResult<List<PaymentListDetailDto>> GetAll()
        {
            return new SuccessDataResult<List<PaymentListDetailDto>>(_paymentListDal.getPaymentListDetailDtos());
        }

        
    }
}
