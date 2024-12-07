using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IPaymentTypeService
    {
        IDataResult<List<PaymentType>>  GetAll();
        IDataResult<PaymentType> GetById(string name);
        IResult Add(PaymentType paymentType);

    }
}
