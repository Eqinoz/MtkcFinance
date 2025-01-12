using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ITitleService
    {
        IDataResult<List<Title>> GetAll();
        IDataResult<Title> GetByName(string title);
        IResult Add(Title title);
    }
}
