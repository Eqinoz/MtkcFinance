using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.CCS;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using FluentValidation;
using ValidationException = FluentValidation.ValidationException;

namespace Business.Concrete
{
    
    public class UserManager : IUserService
    {
        IUserDal _userDal;


        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;

        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(Users users)
        {
            if (CheckIfUser(users.UserName, users.UserSurname).Success)
            {
                _userDal.Add(users);

            return new SuccessResult(Messages.UsersAdd);
            }

            return new ErrorResult();
        }

        public IDataResult<List<Users>> GetAll()
        {
            if (DateTime.Now.Hour == 20)
            {
                return new ErrorDataResult<List<Users>>(Messages.PaymentInTıme);
            }
            return new SuccessDataResult<List<Users>>(_userDal.GetAll(), Messages.UsersList);
        }

        public IDataResult<List<Users>> GetLogin(string mail, string psw)
        {
            if (_userDal.Get(p => p.Mail == mail && p.Psw == psw)!= null)
            {
                return new SuccessDataResult<List<Users>>();
            }

            return new ErrorDataResult<List<Users>>();
        }


        public IDataResult<List<Users>> GetAllByCompany(int company)
        {
            return new SuccessDataResult<List<Users>>(_userDal.GetAll(p => p.CompanyId == company));
        }

        public IDataResult<Users> GetById(int id)
        {
            return new SuccessDataResult<Users>(_userDal.Get(p => p.Id == id));
        }

        public IDataResult<List<UserDetailDto>> GetUserDetails()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<UserDetailDto>>(Messages.PaymentInTıme);
            }
            return new SuccessDataResult<List<UserDetailDto>>(_userDal.GetUserDetails(), Messages.UsersList);
        }

        private IResult CheckIfUser(string userName, string userSurname)
        {
            var result = _userDal.GetAll(p => p.UserName == userName && p.UserSurname == userSurname).Any();
            if (result)
            {
                return new ErrorResult(Messages.UserNameAlreadyExists);
            }

            return new SuccessResult();
        }
    }
}
