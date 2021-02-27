using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal:EfEntityRepositoryBase<Car, CarRentalContext>,ICarDal
    {
        public List<CarDetailsDto> GetCarDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from cr in context.Cars
                    join b in context.Brands
                        on cr.BrandId equals b.Id
                    join cl in context.Colors
                        on cr.ColorId equals cl.Id
                    select new CarDetailsDto
                    {
                        CarName = cr.Name,
                        BrandName = b.Name,
                        ColorName = cl.Name,
                        DailyPrice = cr.DailyPrice

                    };
                return result.ToList();
            }
        }
        
    }
}
