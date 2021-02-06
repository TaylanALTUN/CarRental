using System;
using Business.Concrete;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDAL());
            string getCarsResult = "";
            foreach (var car in carManager.GetAll())
            {
                getCarsResult = string.Format(" Araba Modeli: {0}  Rengi: {1}, Modeli: {2}, Açıklaması: {3}, Günlük Kirası: {4} ", car.BrandId, car.ColorId, car.ModelYear, car.Description,car.DailyPrice);

                Console.WriteLine(getCarsResult);
            }
        }
    }
}
