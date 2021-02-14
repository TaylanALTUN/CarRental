using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BrandManager: IBrandService
    {
        private IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IDataResult<List<Brand>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandListed);
            }
            catch 
            {
                return new ErrorDataResult<List<Brand>>(Messages.BrandCantList);
            }
            
        }

        public IDataResult<List<Brand>> GetById(int id)
        {
            try
            {
                return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(c => c.Id == id),Messages.BrandListed);
            }
            catch
            {
                return new ErrorDataResult<List<Brand>>(Messages.BrandCantList);
            }
        }

        public IResult Add (Brand brand)
        {
            try
            {
                _brandDal.Add(brand);
                return new SuccessResut(Messages.BrandAdded);

            }
            catch 
            {
                return new ErrorResult(Messages.BrandCantAdd);
            }

            
        }

        public IResult Update(Brand brand)
        {
            try
            {
                _brandDal.Update(brand);
                return new SuccessResut(Messages.BrandUpdated);
            }
            catch
            {

                return new ErrorResult(Messages.BrandCantUpdate);
            }
        }

        public IResult Delete(Brand brand)
        {
            try
            {
                _brandDal.Delete(brand);
                return new SuccessResut(Messages.BrandDeleted);
            }
            catch 
            {

                return new ErrorResult(Messages.BrandCantDelete);
            }
        }
    }
}
