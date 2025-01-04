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
using Business.BusinessAspects.Autofac;
using Business.CCS;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
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
        [SecuredOperation("user.add,Admin")]
        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(Users users)
        {
          IResult result =  BusinessRules.Run(CheckIfUser(users.FirstName, users.LastName));
            if (result != null)
            {
                return result;
            }
            _userDal.Add(users);
            return new SuccessResult(Messages.UsersList);
        }

        public IResult Deleted(int id)
        {
            Users users = _userDal.Get(x => x.Id == id);
            if (users != null)
            {
                _userDal.Delete(users);
                return new Result(true, Messages.UsersDeleted);
            }

            return new Result(false, Messages.UsersNotDeleted);
        }

        public IDataResult<List<Users>> GetAll()
        {
            if (DateTime.Now.Hour == 20)
            {
                return new ErrorDataResult<List<Users>>(Messages.PaymentInTıme);
            }
            return new SuccessDataResult<List<Users>>(_userDal.GetAll(), Messages.UsersList);
        }


        public IDataResult<List<Users>> GetAllByCompany(int company)
        {
            return new SuccessDataResult<List<Users>>(_userDal.GetAll(p => p.CompanyId == company));
        }

        

        public IDataResult<List<UserDetailDto>> GetUserDetails()
        {
            
            return new SuccessDataResult<List<UserDetailDto>>(_userDal.GetUserDetails(), Messages.UsersList);
        }

        private IResult CheckIfUser(string userName, string userSurname)
        {
            var result = _userDal.GetAll(p => p.FirstName == userName && p.LastName == userSurname).Any();
            if (result)
            {
                return new ErrorResult(Messages.UserNameAlreadyExists);
            }

            return new SuccessResult();
        }

        public IDataResult<Users> GetByName(string name)
        {
            string[] _name = name.Split(' ');
            string userName, UserLastName;
            userName= _name[0];
            UserLastName = _name[1];
           var result= _userDal.Get(p => p.FirstName == userName && p.LastName==UserLastName);

           return new SuccessDataResult<Users>(result);
        }

        public List<Title> GetClaims(Users user)
        {
            return _userDal.GetClaims(user);
        }

        public Users GetByMail(string mail)
        {
            return _userDal.Get(u => u.Mail == mail);
        }
    }
}
