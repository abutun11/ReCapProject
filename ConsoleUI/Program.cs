using Business.Concrete;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            carManager.Add(new Entities.Concrete.Car { Id = 6, BrandId = 6, ColorId = 6, ModelYear = "2023", DailyPrice = 2800, Description = "Alpha Romeo" });

            carManager.Update(new Entities.Concrete.Car { Id = 6, BrandId = 7, ColorId = 7, ModelYear = "2024", DailyPrice = 4000, Description = "Alpha Romeo Full Paket" });

            carManager.Delete(new Entities.Concrete.Car { Id = 6, BrandId = 6, ColorId = 6, ModelYear = "2023", DailyPrice = 2800, Description = "Alpha Romeo" });

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            foreach (var car in carManager.GetById(4))
            {
                Console.WriteLine(car.Description);
            }


        }
    }
}
