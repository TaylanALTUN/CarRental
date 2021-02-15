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
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }


        public IDataResult<List<RentalDetailsDto>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<RentalDetailsDto>>(_rentalDal.GetRentalDetails(), Messages.RentalListed);
            }
            catch
            {
                return new ErrorDataResult<List<RentalDetailsDto>>(Messages.RentalCantList);
            }
        }

        public IDataResult<List<Rental>> GetById(int id)
        {
            try
            {
                return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.Id == id), Messages.RentalListed);
            }
            catch
            {
                return new ErrorDataResult<List<Rental>>(Messages.RentalCantList);
            }
        }

        public IResult RentaCar(Rental rental)
        {
            try
            {
                if (rental.ReturnDate != null)
                {
                    return new ErrorResult(Messages.RentalReturnDateNotNull);
                }
                else if (IsCarAvailable(rental).Success)
                {
                    _rentalDal.Add(rental);
                    return new SuccessResut(Messages.RentalAdded);
                }
                else
                {
                    return new ErrorResult(Messages.RentalCarRented);
                }
            }
            catch
            {
                return new ErrorResult(Messages.RentalCantAdd);
            }
        }

        public IResult ReturnaCar(Rental rental)
        {
            try
            {
                if (rental.ReturnDate == null)
                { 
                    return new ErrorResult(Messages.RentalReturnDateIsNull);
                }
                
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
            catch (Exception ex)
            {

                return new ErrorResult(Messages.RentalCantUpdate);
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
            try
            {
                _rentalDal.Delete(rental);
                return new SuccessResut(Messages.RentalDeleted);
            }
            catch
            {

                return new ErrorResult(Messages.RentalCantDelete);
            }
        }

    }
}
