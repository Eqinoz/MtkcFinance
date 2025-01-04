using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfHistoryPaymentList:EfEntityRepositoryBase<HistoryPaymentList,MtkcContext>,IHistoryPaymentListDal
    {
        public List<HistoryPaymentListDetailDto> getHistoryPaymentListDetailDtos()
        {
            using (MtkcContext context = new MtkcContext())
            {
                var result = from hpl in context.HistoryPaymentList
                    join c in context.Company on hpl.CompanyId equals c.Id
                    join u in context.Users on hpl.UsersId equals u.Id
                    join pt in context.PaymentType on hpl.PaymentTypeId equals pt.Id
                    select new HistoryPaymentListDetailDto
                    {
                        Id = hpl.Id,
                        DateAdded = hpl.DateAdded,
                        DatePaid = hpl.DatePaid,
                        UserName = u.FirstName + " " + u.LastName,
                        CompanyName = c.CompanyName,
                        PaymentOfPlace = hpl.PlaceOfPayment,
                        PaymentType = pt.Payment_Type,
                        Price = hpl.Price,
                        Description = hpl.Description
                    };
                return result.ToList();
            }
        }
    }
}
