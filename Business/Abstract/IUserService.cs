using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<Users>> GetAll();
        List<Title> GetClaims(Users  user);
        Users GetByMail(string mail);
        IDataResult<List<Users>> GetAllByCompany(int companyId);
        IDataResult<List<UserDetailDto>> GetUserDetails();
        
        IDataResult<Users> GetByName(string name, string lastname);
        IResult Add(Users users);

        


    }
}
