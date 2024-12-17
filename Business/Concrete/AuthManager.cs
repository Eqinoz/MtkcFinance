using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Concrete.EntityFramework;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<Users> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            MtkcContext context = new MtkcContext();
            var company =  context.Company.Where(x => x.CompanyName == userForRegisterDto.CompanyName).FirstOrDefault();
            var title = context.Title.Where(x => x.TitleName == userForRegisterDto.TitleName).FirstOrDefault();
            var user = new Users()
            {
                Mail = userForRegisterDto.mail,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PswHash = passwordHash,
                PswSalt = passwordSalt,
                Phone = userForRegisterDto.Phone,
                TitleId = title.Id,
                CompanyId = company.Id,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<Users>(user, Messages.UserRegistered);
        }

        public IDataResult<Users> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<Users>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PswHash, userToCheck.PswSalt))
            {
                return new ErrorDataResult<Users>(Messages.PasswordError);
            }

            return new SuccessDataResult<Users>(userToCheck, Messages.SuccessfulLogin);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(Users user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }
    }
}
