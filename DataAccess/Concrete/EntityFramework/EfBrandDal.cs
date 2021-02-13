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
    public class EfBrandDal:IBrandDal
    {
        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (ReCapProjectRentaCarContex context = new ReCapProjectRentaCarContex())
            {
                return filter == null ? context.Set<Brand>().ToList() : context.Set<Brand>().Where(filter).ToList();
            }
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            using (ReCapProjectRentaCarContex context = new ReCapProjectRentaCarContex())
            {
                return context.Set<Brand>().SingleOrDefault(filter);
            }
        }

        public void Add(Brand entity)
        {
            using (ReCapProjectRentaCarContex context = new ReCapProjectRentaCarContex())
            {
                var addBrand = context.Add(entity);
                addBrand.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Update(Brand entity)
        {
            using (ReCapProjectRentaCarContex context = new ReCapProjectRentaCarContex())
            {
                var updateBrand = context.Add(entity);
                updateBrand.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(Brand entity)
        {
            using (ReCapProjectRentaCarContex context = new ReCapProjectRentaCarContex())
            {
                var deleteBrand = context.Add(entity);
                deleteBrand.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
