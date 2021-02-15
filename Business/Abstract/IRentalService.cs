using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<RentalDetailsDto>> GetAll();
        IDataResult<List<Rental>> GetById(int id);
        IResult RentaCar(Rental rental);
        IResult ReturnaCar(Rental rental);
        IResult IsCarAvailable(Rental rental);
        IResult DeleteRentalInfo(Rental rental);
    }
}
