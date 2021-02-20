using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }


        public IDataResult<List<RentalDetailsDto>> GetAll()
        {
            return new SuccessDataResult<List<RentalDetailsDto>>(_rentalDal.GetRentalDetails(), Messages.RentalListed);
        }

        public IDataResult<List<Rental>> GetById(int id)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.Id == id), Messages.RentalListed);
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult RentaCar(Rental rental)
        {
            if (IsCarAvailable(rental).Success)
            {
                //ValidationTool.Validate(new RentalValidator(), rental);
                _rentalDal.Add(rental);
                return new SuccessResut(Messages.RentalAdded);
            }
            return new ErrorResult(Messages.RentalCarRented);
        }

        public IResult ReturnaCar(Rental rental)
        {
                if (IsCarAvailable(rental).Success)
                {
                    return new ErrorResult(Messages.RentalCarNotFound);
                }
                else
                {
                    _rentalDal.Update(rental);
                    return new SuccessResut(Messages.RentalUpdated);
                }
        }

        public IResult IsCarAvailable(Rental rental)
        {
            var result = _rentalDal.Get(r => r.CarId == rental.CarId && r.ReturnDate == null);
            if (result == null)
            {
                return new SuccessResut();
            }
            else
            {
                return new ErrorResult();
            }
        }

        public IResult DeleteRentalInfo(Rental rental)
        {
                _rentalDal.Delete(rental);
                return new SuccessResut(Messages.RentalDeleted);
        }

    }
}
