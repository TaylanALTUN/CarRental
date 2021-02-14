using System;
using System.Collections.Generic;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;

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


            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());


            //AddCar(carManager, new Car
            //{
            //    Name = "İl",
            //    BrandId = 1,
            //    ColorId = 1,
            //    DailyPrice = 0,
            //    Description = "Kontrol amaçlı girilmiştir.",
            //    ModelYear = 2021,
            //});



            //AddBrand(brandManager,new Brand
            //{
            //    Name = "Porsche"
            //});

            //AddColor(colorManager,new Color
            //{
            //    Name = "Mat Siyag"
            //});


            //AddCar(carManager, new Car
            //{
            //    Name = "Araba 3",
            //    BrandId = 3,
            //    ColorId = 2,
            //    DailyPrice = 200,
            //    Description = "Açıklama 3",
            //    ModelYear = 2021,
            //});

            //AddCar(carManager, new Car
            //{
            //    Name = "Araba 4",
            //    BrandId = 2,
            //    ColorId = 3,
            //    DailyPrice = 200,
            //    Description = "Açıklama 3",
            //    ModelYear = 2021,
            //});

            GetCarDetails(carManager);
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

        private static void AddColor(ColorManager colorManager, Color color)
        {
            colorManager.Add(new Color
            {
                Name = color.Name,
            });
        }

        private static void AddBrand(BrandManager brandManager, Brand brand)
        {
            brandManager.Add(new Brand
            {
                Name = brand.Name,
            });
        }

        private static void GetCarDetails(CarManager carManager)
        {
            List<CarDetailsDto> carDetailsDtos = carManager.GetCarDetails().Data;
            foreach (var item in carDetailsDtos)
            {
                Console.WriteLine(string.Format(" Araba Adı:{0} Modeli: {1}  Rengi: {2},  Günlük Kirası: {3} ", item.CarName,item.BrandName,item.ColorName,item.DailyPrice));
            }

        }
    }
}

