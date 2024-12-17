using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryUserDal : IUserDal
    {
        List<Users> _users;
        public InMemoryUserDal()
        {
            _users = new List<Users> {
                new Users{Id=1, FirstName= "Sinan",LastName= "Özuncu", CompanyId=1, Mail="eee@", Phone="8888", TitleId= 1 }
                
            };
        }
        public void Add(Users user)
        {
            throw new NotImplementedException();
        }

        public void Delete(Users user)
        {
            throw new NotImplementedException();
        }

        public Users Get(Expression<Func<Users, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Users> GetAll()
        {
            return _users;
        }

        public List<Users> GetAll(Expression<Func<Users, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Title> GetClaims(Users users)
        {
            throw new NotImplementedException();
        }

        public List<UserDetailDto> GetUserDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Users user)
        {
            throw new NotImplementedException();
        }
    }
}
