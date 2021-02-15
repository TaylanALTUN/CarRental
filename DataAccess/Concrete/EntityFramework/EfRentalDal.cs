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
    public class EfRentalDal: EfEntityRepositoryBase<Rental,ReCapProjectRentaCarContex>,IRentalDal
    {
        public List<RentalDetailsDto> GetRentalDetails()
        {
            using (ReCapProjectRentaCarContex context = new ReCapProjectRentaCarContex())
            {
                var result = from r in context.Rentals 
                    join cr in context.Cars 
                        on r.CarId equals cr.Id 
                    join cs in context.Customers 
                        on r.CustomerId equals cs.Id
                             select new RentalDetailsDto
                             {
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
