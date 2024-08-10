using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                new Car{CarId=1, BrandId=1, ColorId=1, ModelYear="2020", DailyPrice=1200, Description="Fiat Egea"},
                new Car{CarId=2, BrandId=2, ColorId=2, ModelYear="2022", DailyPrice=2500, Description="BMW 420i"},
                new Car{CarId=3, BrandId=3, ColorId=3, ModelYear="2021", DailyPrice=3000, Description="Mercedes E250"},
                new Car{CarId=4, BrandId=4, ColorId=4, ModelYear="2019", DailyPrice=1000, Description="Renault Clio"},
                new Car{CarId=5, BrandId=5, ColorId=5, ModelYear="2019", DailyPrice=800, Description="Hyundai I20"}
            };
        }
        public void Add(Car car)
        {
            cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = cars.SingleOrDefault(c=>c.CarId == car.CarId);

            cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int Id)
        {
            return cars.Where(c=>c.CarId == Id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = cars.SingleOrDefault(c=>c.CarId == car.CarId);

            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
