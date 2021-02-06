using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDAL:ICarDAL
    {
        private List<Car> _cars;

        public InMemoryCarDAL()
        {
            _cars = new List<Car>
            {
                new Car(){ Id = 1, BrandId= 1, ColorId = 1, DailyPrice = 700, Description = "Desc 1", ModelYear = 2019},
                new Car(){ Id = 2, BrandId= 1, ColorId = 1, DailyPrice = 750, Description = "Desc 2", ModelYear = 2020},
                new Car(){ Id = 3, BrandId= 2, ColorId = 2, DailyPrice = 800, Description = "Desc 3", ModelYear = 2020},
                new Car(){ Id = 4, BrandId= 2, ColorId = 2, DailyPrice = 830, Description = "Desc 3", ModelYear = 2020},
                new Car(){ Id = 5, BrandId= 3, ColorId = 3, DailyPrice = 850, Description = "Desc 4", ModelYear = 2021},
                new Car(){ Id = 6, BrandId= 3, ColorId = 3, DailyPrice = 900, Description = "Desc 5", ModelYear = 2021},
            };
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(Car entity)
        {
            _cars.Add(entity);
        }
        public void Update(Car entity)
        {
            Car carToUpdate = _cars.SingleOrDefault(x => x.Id == entity.Id);
            if (carToUpdate != null)
            {
                carToUpdate.BrandId = entity.BrandId;
                carToUpdate.ColorId = entity.ColorId;
                carToUpdate.DailyPrice = entity.DailyPrice;
                carToUpdate.Description = entity.Description;
                carToUpdate.ModelYear = entity.ModelYear;
            }
        }

        public void Delete(Car entity)
        {
            Car carToDelete = _cars.FirstOrDefault(p => p.Id == entity.Id);
            _cars.Remove(carToDelete);
        }
    }
}
