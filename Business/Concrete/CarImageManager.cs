using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager: ICarImageService
    {
        private ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImageListed);
        }
        

        public IDataResult<List<CarImage>> GetById(int id)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.Id == id), Messages.CarImageListed);
        }


        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(
                CheckIfCarImageContLimit(carImage.CarId)
            );

            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            string filepath = _carImageDal.Get(p => p.Id == carImage.Id).ImagePath;

            carImage.ImagePath = FileHelper.Update(filepath, file);
            carImage.Date = DateTime.Now;

            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        public IResult Delete(CarImage carImage)
        {
            string filepath = _carImageDal.Get(p => p.Id == carImage.Id).ImagePath;

            bool isDeleted = FileHelper.Delete(filepath);

            if (isDeleted)
            {
                _carImageDal.Delete(carImage);
                return new SuccessResult(Messages.CarImageDeleted); 
            }
            else
            {
                return new ErrorResult(Messages.CarImageCantDelete);
            }
        }

        private IResult CheckIfCarImageContLimit(int carid)
        {
            var carImagecount = _carImageDal.GetAll(p => p.CarId == carid).Count;

            if (carImagecount >= 5)
            {
                return new ErrorResult(Messages.CarImageCaountLimitFull);
            }

            return new SuccessResult();
        }

    }
}
