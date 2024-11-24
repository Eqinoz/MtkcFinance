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
        List<Users> GetAll();
        List<Users> GetAllByCompany(string company);
        List<UserDetailDto> GetUserDetails();

        IResult Add(Users users);

        Users GetById(int id);


    }
}
