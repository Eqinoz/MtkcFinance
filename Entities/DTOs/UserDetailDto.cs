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
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        public string Psw {  get; set; }
        public string Title { get; set; }
        public string CompanyName { get; set; }

    }
}
