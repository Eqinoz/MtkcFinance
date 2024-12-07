using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IPaymentListService
    {
        IDataResult<List<PaymentListDetailDto>> GetAll();
        IDataResult<PaymentListDetailDto> Get(int id);
        IDataResult<PaymentListDetailDto> Get(string name);
        IResult Add(PaymentList paymentList);
    }
}
