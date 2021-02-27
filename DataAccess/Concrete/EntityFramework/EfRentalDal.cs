using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal: EfEntityRepositoryBase<Rental, CarRentalContext>,IRentalDal
    {
        public List<RentalDetailsDto> GetRentalDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from r in context.Rentals 
                    join cr in context.Cars 
                        on r.CarId equals cr.Id 
                    join cs in context.Customers 
                        on r.CustomerId equals cs.Id
                             select new RentalDetailsDto
                             {
                                 Id = r.Id,
                                 CarName = cr.Name,
                                 CustomerName = cs.CompanyName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
