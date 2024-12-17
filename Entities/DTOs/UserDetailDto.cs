using Core;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UserDetailDto:IDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        public byte[] PswSalt {  get; set; }
        public byte[] PswHash { get; set; }
        public string Title { get; set; }
        public string CompanyName { get; set; }
        public bool Status { get; set; }

    }
}
