using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> cars;
        public InMemoryCarDal()
        {
            cars = new List<Car> {
                new Car{Id=1, BrandId=1, ColorId=1, ModelYear="2020", DailyPrice=1200, Description="Fiat Egea"},
                new Car{Id=2, BrandId=2, ColorId=2, ModelYear="2022", DailyPrice=2500, Description="BMW 420i"},
                new Car{Id=3, BrandId=3, ColorId=3, ModelYear="2021", DailyPrice=3000, Description="Mercedes E250"},
                new Car{Id=4, BrandId=4, ColorId=4, ModelYear="2019", DailyPrice=1000, Description="Renault Clio"},
                new Car{Id=5, BrandId=5, ColorId=5, ModelYear="2019", DailyPrice=800, Description="Hyundai I20"}
            };
        }
        public void Add(Car car)
        {
            cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = cars.SingleOrDefault(c=>c.Id == car.Id);

            cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return cars;
        }

        public List<Car> GetById(int Id)
        {
            return cars.Where(c=>c.Id == Id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = cars.SingleOrDefault(c=>c.Id == car.Id);

            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
