using PolovniAutomobili.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolovniAutomobili.Data
{
    public class InMemoryAutomobilData : IAutomobilData
    {
        List<Automobil> _cars;
        public InMemoryAutomobilData()
        {
            _cars = new List<Automobil>()
            {
                new Automobil() { Id = 1, Name="Malo presao", Description = "Audi A3", Gorivo = GorivoVrsta.Benzin},
                new Automobil() { Id = 2, Name="A4, garažiran", Description = "Audi A4", Gorivo = GorivoVrsta.Dizel},
                new Automobil() { Id = 3, Name="Q2", Description = "Audi Q2", Gorivo = GorivoVrsta.Hibrid},
                new Automobil() { Id = 4, Name="Q3", Description = "Audi Q3", Gorivo = GorivoVrsta.Benzin}
            };
        }

        public Automobil Add(Automobil newCar)
        {
            _cars.Add(newCar);
            newCar.Id = _cars.Max(c => c.Id) + 1;
            return newCar;
        }

        public int Commit()
        {
            return 0;
        }

        public Automobil Delete(int id)
        {
            Automobil car = _cars.FirstOrDefault(c =>c.Id == id);
            if (car != null)
            {
                _cars.Remove(car);
            }
            return car;
        }

        public Automobil GetById(int id)
        {
            Automobil car = _cars.FirstOrDefault(c => c.Id == id);
            return car;
        }

        public IEnumerable<Automobil> GetCarsByName(string name)
        {
            var cars = from c in _cars
                       where String.IsNullOrEmpty(name) || c.Name.ToLower().Contains(name.ToLower())
                       orderby c.Id
                       select c;
            return cars;
        }

        public Automobil Update(Automobil updatedCar)
        {
            var car = _cars.FirstOrDefault(c => c.Id == updatedCar.Id);
            if (car != null)
            {
                car.Name = updatedCar.Name;
                car.Description = updatedCar.Description;
                car.Gorivo = updatedCar.Gorivo;
            }
            return car;
        }
    }
}
