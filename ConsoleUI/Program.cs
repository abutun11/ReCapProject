using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //ColorOrBrandTest();
            //RentalTest();
        }

        private static void RentalTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(new User { UserId = 1, FirstName = "İbrahim Alican", LastName = "BÜTÜN", Email = "butunalican01@gmail.com"});

            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer { CustomerId = 1, UserId = 1, CompanyName = "ABC" });

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add(new Rental { RentalId = 2, CarId = 2, CustomerId = 1, RentDate = DateTime.Now, ReturnDate = null });
            Console.WriteLine(result.Message);
        }

        private static void ColorOrBrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { BrandId = 1, BrandName = "BMW" });

            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { ColorId=2, ColorName = "Siyah" });
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            carManager.Add(new Entities.Concrete.Car { CarId = 2, BrandId = 1, ColorId = 2, CarName = "BMW", ModelYear = "2021", DailyPrice = 3500, Description = "BMW MSport" });

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
        }
    }
}
