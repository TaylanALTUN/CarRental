using System;
using System.Collections.Generic;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarManager carManager = new CarManager(new InMemoryCarDal());
            //string getCarsResult = "";
            //foreach (var car in carManager.GetAll())
            //{
            //    getCarsResult = string.Format(" Araba Modeli: {0}  Rengi: {1}, Modeli: {2}, Açıklaması: {3}, Günlük Kirası: {4} ", car.BrandId, car.ColorId, car.ModelYear, car.Description,car.DailyPrice);

            //    Console.WriteLine(getCarsResult);
            //}

            //AddAndListColor();

            //AddAndListBrand();

            CarManager carManager = new CarManager(new EfCarDal());

            AddCar(carManager, new Car
            {
                Name = "İl",
                BrandId = 1,
                ColorId = 1,
                DailyPrice = 0,
                Description = "Kontrol amaçlı girilmiştir.",
                ModelYear = 2021,
            });

            AddCar(carManager, new Car
            {
                Name = "İlk araba",
                BrandId = 1,
                ColorId = 1,
                DailyPrice = 200,
                Description = "Kontrol amaçlı girilmiştir.",
                ModelYear = 2021,
            });



        }

        private static void AddCar(CarManager carManager, Car car)
        {
            carManager.Add(new Car
            {
                Name = car.Name,
                BrandId = car.BrandId,
                ColorId = car.ColorId,
                DailyPrice = car.DailyPrice,
                Description = car.Description,
                ModelYear = car.ModelYear,
            });
        }

        private static void AddAndListBrand()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            string[] brands = new[] {"Audi", "BMW", "Chevrolet", "Hyundai", "Lamborghini", "Mercedes-Benz", "Nissan", "Opel"};

            foreach (var brand in brands)
            {
                brandManager.Add(new Brand
                {
                    Name = brand
                });
            }

            Console.WriteLine("Markalar --------------------------------------------------------------");
            List<Brand> branList = brandManager.GetAll();

            foreach (var brand in branList)
            {
                Console.WriteLine(brand.Name);
            }
        }

        private static void AddAndListColor()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            string[] colors = new[] {"Kırmızı", "Mavi", "Siyah"};

            foreach (var color in colors)
            {
                colorManager.Add(new Color
                {
                    Name = color
                });
            }

            Console.WriteLine("Renkler --------------------------------------------------------------");
            List<Color> colorList = colorManager.GetAll();

            foreach (var color in colorList)
            {
                Console.WriteLine(color.Name);
            }
        }
    }
}

