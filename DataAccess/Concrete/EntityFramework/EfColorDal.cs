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
    public class EfColorDal:IColorDal
    {
        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (ReCapProjectRentaCarContex context = new ReCapProjectRentaCarContex())
            {
                return filter == null ? context.Set<Color>().ToList() : context.Set<Color>().Where(filter).ToList();
            }
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            using (ReCapProjectRentaCarContex context = new ReCapProjectRentaCarContex())
            {
                return context.Set<Color>().SingleOrDefault(filter);
            }
        }

        public void Add(Color entity)
        {
            using (ReCapProjectRentaCarContex context = new ReCapProjectRentaCarContex())
            {
                var addColor = context.Add(entity);
                addColor.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Update(Color entity)
        {
            using (ReCapProjectRentaCarContex context = new ReCapProjectRentaCarContex())
            {
                var updateColor = context.Add(entity);
                updateColor.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(Color entity)
        {
            using (ReCapProjectRentaCarContex context = new ReCapProjectRentaCarContex())
            {
                var deleteColor = context.Add(entity);
                deleteColor.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
