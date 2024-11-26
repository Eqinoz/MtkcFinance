using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CompanyManager : ICompanyService
    {
        ICompanyDal _companyDal;
        public CompanyManager(ICompanyDal companyDal)
        {
            _companyDal = companyDal;
        }

        public IResult Add(Company company)
        {
            if (company.CompanyName.Length<=5)
            {
                return new ErrorResult(Messages.CompanyNameError);
            }

            _companyDal.Add(company);
            return new SuccessResult();
        }

        public IDataResult<List<Company>> GetAll()
        {
            return new SuccessDataResult<List<Company>>(_companyDal.GetAll(), Messages.CompanyList);
        }

        public IDataResult<List<Company>> GetById(int id)
        {
            return new SuccessDataResult<List<Company>>(_companyDal.GetAll(p => p.Id == id));
        }

        public IDataResult<List<Company>> GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
