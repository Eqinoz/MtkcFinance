using Business.Abstract;
using Business.Constants;
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
                return new ErrorResult(Messages.UssersPswError);
            }

            _userDal.Add(users);

            return new SuccessResult(Messages.UsersAdd);
        }
         
        public IDataResult<List<Users>> GetAll()
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Users>>(Messages.PaymentInTıme);
            }
           return new SuccessDataResult<List<Users>>(_userDal.GetAll(),Messages.UsersAdd);
        }

        public IDataResult<List<Users>> GetAllByCompany(int company)
        {
            return new SuccessDataResult<List<Users>>(_userDal.GetAll(p=> p.CompanyId==company));
        }

        public IDataResult<List<Users>> GetAllByCompany(string company)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Users> GetById(int id)
        {
            return new SuccessDataResult<Users>(_userDal.Get(p=>p.Id == id));
        }

        public IDataResult<List<UserDetailDto>> GetUserDetails()
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<UserDetailDto>>(Messages.PaymentInTıme);
            }
           return new SuccessDataResult<List<UserDetailDto>>(_userDal.GetUserDetails());
        }
    }
}
