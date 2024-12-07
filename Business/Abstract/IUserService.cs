using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<Users>> GetAll();
        IDataResult<List<Users>> GetLogin(string mail, string psw);
        IDataResult<List<Users>> GetAllByCompany(int companyId);
        IDataResult<List<UserDetailDto>> GetUserDetails();
        IDataResult<Users> GetById(int id);
        IDataResult<Users> GetByName(string name, string lastname);
        IResult Add(Users users);

        


    }
}
