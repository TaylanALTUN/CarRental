using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal:ICarDal
    {
        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapProjectRentaCarContex context = new ReCapProjectRentaCarContex())
            {
                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (ReCapProjectRentaCarContex context = new ReCapProjectRentaCarContex())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public void Add(Car entity)
        {
            using (ReCapProjectRentaCarContex context = new ReCapProjectRentaCarContex())
            {
                var addCar = context.Add(entity);
                addCar.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Update(Car entity)
        {
            using (ReCapProjectRentaCarContex context = new ReCapProjectRentaCarContex())
            {
                var updateCar = context.Add(entity);
                updateCar.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (ReCapProjectRentaCarContex context = new ReCapProjectRentaCarContex())
            {
                var deleteCar = context.Add(entity);
                deleteCar.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
