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
using Core.Aspects.Autofac.Transaction;
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

        //[SecuredOperation("company.add,Admin")]
        [ValidationAspect(typeof(CompanyValidator)) ]
        //[CacheRemoveAspect("ICompanyService.GetAll,ICompanyService.Delete,ICompanyService.Add")]
        //[TransactionScopeAspect]
        public IResult Add(Company company)
        {
            _companyDal.Add(company);
            return new Result(true, Messages.CompanyAdd);
            
        }
       // [CacheRemoveAspect("ICompanyService.GetAll,ICompanyService.Delete,ICompanyService.Add")]
        public IResult Delete(int id)
        {
            Company company = _companyDal.Get(x => x.Id == id);
            if (company!=null)
            {
                _companyDal.Delete(company);
                return new Result(true, Messages.CompanyDeleted);
            }

            return new Result(false, Messages.CompanyNotDeleted);

        }
        
        //[CacheRemoveAspect("ICompanyService.GetAll,ICompanyService.Delete,ICompanyService.Add")]
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
