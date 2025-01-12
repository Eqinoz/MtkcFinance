using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class TitleManager:ITitleService
    {
         ITitleDal _titleDal;

         public TitleManager(ITitleDal title)
         {
             _titleDal=title;
         }
        public IDataResult<List<Title>> GetAll()
        {
            return new SuccessDataResult<List<Title>>(_titleDal.GetAll(), Messages.TitleList);
        }

        public IDataResult<Title> GetByName(string title)
        {
            return new SuccessDataResult<Title>(_titleDal.Get(x => x.TitleName ==title));
        }

       

        public IResult Add(Title title)
        {
            _titleDal.Add(title);
            return new SuccessResult(Messages.TitleAdd);

        }
    }
}
