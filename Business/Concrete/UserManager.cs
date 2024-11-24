using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(Users users)
        {
            if (users.Psw.Length <= 7)
            {
                return new ErrorResult("Kullanıcı'nın Şifresi 8 Karakterden Küçük Olduğu İçin Eklenemedi.");
            }

            _userDal.Add(users);

            return new SuccessResult("Kullanıcı Eklendi");
        }
         
        public List<Users> GetAll()
        {
           return _userDal.GetAll();
        }

        public List<Users> GetAllByCompany(int company)
        {
            return _userDal.GetAll(p=> p.CompanyId==company);
        }

        public List<Users> GetAllByCompany(string company)
        {
            throw new NotImplementedException();
        }

        public Users GetById(int id)
        {
            return _userDal.Get(p=>p.Id == id);
        }

        public List<UserDetailDto> GetUserDetails()
        {
           return _userDal.GetUserDetails();
        }
    }
}
