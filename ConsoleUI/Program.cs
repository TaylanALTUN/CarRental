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
            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            UserManager userManager = new UserManager(new EfUserDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            //AddUser(userManager);
            //ListUsers(userManager);
            //AddCustomer(customerManager);
            //ListCustomerDetails(customerManager);

            //Rental rental = new Rental { CarId = 1, CustomerId = 1, RentDate = DateTime.Now };
            ////Console.WriteLine(rentalManager.RentaCar(rental).Message);
            //rental.Id = 1;
            //rental.ReturnDate=DateTime.Now;
            //Console.WriteLine(rentalManager.ReturnaCar(rental).Message);
            
            //Rental rental2 = new Rental { CarId = 1, CustomerId = 1, RentDate = DateTime.Now };
            //Console.WriteLine(rentalManager.RentaCar(rental2).Message);
            //rental2.ReturnDate = DateTime.Now;
            //Console.WriteLine(rentalManager.ReturnaCar(rental2).Message);

            //Rental rental3 = new Rental { CarId = 4, CustomerId = 2, RentDate = DateTime.Now };
            //Console.WriteLine(rentalManager.RentaCar(rental3).Message);
            //Console.WriteLine(rentalManager.ReturnaCar(rental3).Message);

            //foreach (var rentalDetail in rentalManager.GetAll().Data)
            //{
            //    Console.WriteLine("{0} - {1} - {2} - {3}", rentalDetail.CarName, rentalDetail.CustomerName, rentalDetail.RentDate, rentalDetail.ReturnDate);
            //}


        }


        private static void ListCustomerDetails(CustomerManager customerManager)
        {
            foreach (var item in customerManager.GetAll().Data)
            {
                Console.WriteLine(string.Format(" Kullanıcı AdSoyad:{0} Müşteri Ad: {1}", item.UserName,
                    item.CompanyName));
            }
        }

        private static void AddCustomer(CustomerManager customerManager)
        {
            customerManager.Add(new Customer
            {
                UserId = 2,
                CompanyName = "Company2"
            });
        }

        private static void ListUsers(UserManager userManager)
        {
            foreach (var item in userManager.GetAll().Data)
            {
                Console.WriteLine(string.Format(" Kullanıcı AdSoyad:{0} {1} E-Mail: {2}  Şifre: {3}", item.FirstName,
                    item.LastName, item.Email, item.Password));
            }
        }

        private static void AddUser(UserManager userManager)
        {
            var result=userManager.Add(new User
            {
                FirstName = "Taylan",
                LastName = "ALTUN",
                Email = "taylan.altun@gmail.com",
                Password = "****"
            });

            Console.WriteLine(result.Message);
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

