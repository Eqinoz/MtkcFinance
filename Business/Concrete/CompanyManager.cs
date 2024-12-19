using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;

namespace Business.Concrete
{
    public class CompanyManager : ICompanyService
    {
        ICompanyDal _companyDal;
        public CompanyManager(ICompanyDal companyDal)
        {
            _companyDal = companyDal;
        }

        [SecuredOperation("company.add,Admin")]
        [ValidationAspect(typeof(CompanyValidator)) ]
        public IResult Add(Company company)
        {
            _companyDal.Add(company);
            return new SuccessResult();
        }
        [CacheAspect]
        public IDataResult<List<Company>> GetAll()
        {
            return new SuccessDataResult<List<Company>>(_companyDal.GetAll(), Messages.CompanyList);
        }


        public IDataResult<Company> GetById(string name)
        {
            return new SuccessDataResult<Company> (_companyDal.Get(p => p.CompanyName == name));
        }
    }
}
