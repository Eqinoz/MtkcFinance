using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICompanyService
    {
        IDataResult<List<Company>> GetAll();
        IDataResult<Company> GetById(string name);
        IResult Add(Company company);
        IResult Delete(int id);

    }
}
