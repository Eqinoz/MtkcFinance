using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<Users, MtkcContext>, IUserDal
    {
        public List<Title> GetClaims(Users users)
        {
            using (MtkcContext context = new MtkcContext())
            {
                var result = from t in context.Title
                    where users.TitleId == t.Id
                    select new Title
                    {
                        Id = t.Id,
                        TitleName = t.TitleName
                    };
                return result.ToList();
            }
        }

        public List<UserDetailDto> GetUserDetails()
        {
            using (MtkcContext context = new MtkcContext())
            {
                var result = from u in context.Users
                             join c in context.Company on u.CompanyId equals c.Id
                             join t in context.Title on u.TitleId equals t.Id
                             select new UserDetailDto
                             {
                                 Id = u.Id,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 CompanyName = c.CompanyName,
                                 PswSalt = u.PswSalt,
                                 PswHash = u.PswHash,
                                 Title = t.TitleName,
                                 UserEmail = u.Mail,
                                 UserPhone = u.Phone,
                                 Status = u.Status
                             };
                return result.ToList();

            }
        }
    }
}
