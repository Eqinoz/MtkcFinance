using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.DTOs
{
    public class TitleDto:IDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
