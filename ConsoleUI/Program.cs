using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            carManager.Add(new Entities.Concrete.Car { CarId = 1, BrandId = 6, ColorId = 6, CarName = "Alpha Romeo", ModelYear = "2023", DailyPrice = 2200, Description = "Alpha Romeo" });

            carManager.Update(new Entities.Concrete.Car { CarId = 6, BrandId = 7, ColorId = 7, ModelYear = "2024", DailyPrice = 4000, Description = "Alpha Romeo Full Paket" });

            carManager.Delete(new Entities.Concrete.Car { CarId = 6, BrandId = 6, ColorId = 6, ModelYear = "2023", DailyPrice = 2800, Description = "Alpha Romeo" });

            foreach (var car in carManager.GetCarsByBrandId(6).Data)
            {
                Console.WriteLine(car.CarName);
            }

            foreach (var car in carManager.GetCarsByColorId(6).Data)
            {
                Console.WriteLine(car.DailyPrice);
            }

            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(car.CarName + "/" + car.BrandName + "/" + car.ColorName + "/" + car.DailyPrice);
            }

            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { BrandId = 6, BrandName = "Alpha Romeo" });

            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorId + "/" + color.ColorName);
            }

        }
    }
}
