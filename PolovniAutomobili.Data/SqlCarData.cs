using Microsoft.EntityFrameworkCore;
using PolovniAutomobili.Core;
using System.Collections.Generic;
using System.Linq;

namespace PolovniAutomobili.Data
{
    public class SqlCarData : IAutomobilData
    {
        private readonly PolovniAutomobiliDbContext db;

        public SqlCarData(PolovniAutomobiliDbContext db)
        {
            this.db = db;
        }
        public Automobil Add(Automobil newCar)
        {
            db.Add(newCar);
            return newCar;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Automobil Delete(int id)
        {
            var car = GetById(id);
            if (car != null)
            {
                db.Car.Remove(car);
            }
            return car;
        }

        public Automobil GetById(int id)
        {
            return db.Car.Find(id);
        }

        public IEnumerable<Automobil> GetCarsByName(string name)
        {
            var query = from c in db.Car
                        where string.IsNullOrEmpty(name) || c.Name.Contains(name)
                        orderby c.Name
                        select c;
            return query;
        }

        public Automobil Update(Automobil updatedCar)
        {
            var entity = db.Car.Attach(updatedCar);
            entity.State = EntityState.Modified;
            return updatedCar;
        }
    }
}
