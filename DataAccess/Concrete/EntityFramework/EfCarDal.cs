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
    public class EfCarDal:EfEntityRepositoryBase<Car,ReCapProjectRentaCarContex>,ICarDal
    {
        public List<CarDetailsDto> GetCarDetails()
        {
            using (ReCapProjectRentaCarContex context = new ReCapProjectRentaCarContex())
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


        //public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        //{
        //    using (ReCapProjectRentaCarContex context = new ReCapProjectRentaCarContex())
        //    {
        //        return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
        //    }
        //}

        //public Car Get(Expression<Func<Car, bool>> filter)
        //{
        //    using (ReCapProjectRentaCarContex context = new ReCapProjectRentaCarContex())
        //    {
        //        return context.Set<Car>().SingleOrDefault(filter);
        //    }
        //}

        //public void Add(Car entity)
        //{
        //    using (ReCapProjectRentaCarContex context = new ReCapProjectRentaCarContex())
        //    {
        //        var addCar = context.Add(entity);
        //        addCar.State = EntityState.Added;
        //        context.SaveChanges();
        //    }
        //}

        //public void Update(Car entity)
        //{
        //    using (ReCapProjectRentaCarContex context = new ReCapProjectRentaCarContex())
        //    {
        //        var updateCar = context.Add(entity);
        //        updateCar.State = EntityState.Modified;
        //        context.SaveChanges();
        //    }
        //}

        //public void Delete(Car entity)
        //{
        //    using (ReCapProjectRentaCarContex context = new ReCapProjectRentaCarContex())
        //    {
        //        var deleteCar = context.Add(entity);
        //        deleteCar.State = EntityState.Deleted;
        //        context.SaveChanges();
        //    }
        //}
    }
}
