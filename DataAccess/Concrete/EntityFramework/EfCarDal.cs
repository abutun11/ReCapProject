using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (RenACarContext renACarContext = new RenACarContext())
            {
                var addedEntity = renACarContext.Entry(entity);
                addedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Added;
                renACarContext.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (RenACarContext renACarContext = new RenACarContext())
            {
                var deletedEntity = renACarContext.Entry(entity);
                deletedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                renACarContext.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (RenACarContext renACarContext = new RenACarContext())
            {
                return renACarContext.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (RenACarContext renACarContext = new RenACarContext())
            {
                return filter == null ? renACarContext.Set<Car>().ToList() : renACarContext.Set<Car>().Where(filter).ToList();
            }
        }

        public void Update(Car entity)
        {
            using (RenACarContext renACarContext = new RenACarContext())
            {
                var updatedEntity = renACarContext.Entry(entity);
                updatedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                renACarContext.SaveChanges();
            }
        }
    }
}
