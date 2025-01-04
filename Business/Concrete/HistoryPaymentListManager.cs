using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class HistoryPaymentListManager:IHistoryPaymentListService
    {
        private IHistoryPaymentListDal _paymentListDal;

        public HistoryPaymentListManager(IHistoryPaymentListDal paymentListDal)
        {
            _paymentListDal = paymentListDal;
        }
        public IDataResult<List<HistoryPaymentListDetailDto>> GetAll()
        {
            return new SuccessDataResult<List<HistoryPaymentListDetailDto>>(_paymentListDal.getHistoryPaymentListDetailDtos());
        }

        public IResult Add(HistoryPaymentList historyPaymentList)
        {
            _paymentListDal.Add(historyPaymentList);
            return new Result(true, "Başarılı");
        }

        

        
    }
}
