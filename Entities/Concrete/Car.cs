using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Car:IEntity
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public string Name { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }

        public static explicit operator Car(Expression<Func<Car, bool>> v)
        {
            throw new NotImplementedException();
        }
    }
}
