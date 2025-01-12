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
    public class EfPaymentListDal:EfEntityRepositoryBase<PaymentList,MtkcContext>,IPaymentListDal
    {
        public List<PaymentListDetailDto> getPaymentListDetailDtos()
        {
            using (MtkcContext context = new MtkcContext() )
            {
                var result = from pl in context.PaymentList
                    join c in context.Company on pl.CompanyId equals c.Id
                    join u in context.Users on pl.UsersId equals u.Id
                    join pt in context.PaymentType on pl.PaymentTypeId equals pt.Id
                    join t in context.Title on pl.TitleId equals t.Id

                    select new PaymentListDetailDto
                    {
                        Id = pl.Id,
                        DateAdded = pl.DateAdded,
                        UserName = u.FirstName+" "+u.LastName ,
                        Title = t.TitleName,
                        CompanyName = c.CompanyName,
                        PaymentOfPlace = pl.PlaceOfPayment,
                        PaymentType = pt.Payment_Type,
                        Price = pl.Price,
                        Description = pl.Description
                    };
                return result.ToList();

            }
        }
    }
}
