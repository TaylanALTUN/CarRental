using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager:ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IDataResult<List<Car>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
            }
            catch
            {
                return new ErrorDataResult<List<Car>>(Messages.CarCantList);
            }
        }

        public IDataResult<List<Car>> GetById(int id)
        {
            try
            {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.Id == id), Messages.CarListed);
            }
            catch
            {
                return new ErrorDataResult<List<Car>>(Messages.CarCantList);
            }

        }

        public IResult Add(Car car)
        {
            try
            {
                if (car.Name.Length <= 2)
                {
                    return new ErrorResult(Messages.CarNameLengthMustBeMinimumTwo);
                }
                else if (car.DailyPrice <= 0)
                {
                    return new ErrorResult(Messages.CarDailyPriceMustBeMoreThanZero);
                }

                _carDal.Add(car);
                return new SuccessResut(Messages.CarAdded);

            }
            catch
            {
                return new ErrorResult(Messages.CarCantAdd);
            }
        }

        public IResult Update(Car car)
        {
            try
            {
                _carDal.Update(car);
                return new SuccessResut(Messages.CarUpdated);
            }
            catch
            {

                return new ErrorResult(Messages.CarCantUpdate);
            }
        }

        public IResult Delete(Car car)
        {
            try
            {
                _carDal.Delete(car);
                return new SuccessResut(Messages.CarDeleted);
            }
            catch
            {

                return new ErrorResult(Messages.CardCantDelete);
            }
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            try
            {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id), Messages.CarListed);
            }
            catch
            {
                return new ErrorDataResult<List<Car>>(Messages.CarCantList);
            }
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            try
            {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id), Messages.CarListed);
            }
            catch
            {
                return new ErrorDataResult<List<Car>>(Messages.CarCantList);
            }
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetails()
        {
            try
            {
                return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails(), Messages.CarListed);
            }
            catch
            {
                return new ErrorDataResult<List<CarDetailsDto>>(Messages.CarCantList);
            }
        }
    }
}
