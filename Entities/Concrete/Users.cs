using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Users : IEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserSurname{ get; set; }
        public string? Mail { get; set; }
        public string? Psw { get; set; }
        public string? Phone { get; set; }
        public int? TitleId { get; set; }
        public int? CompanyId { get; set; }
    }
}
