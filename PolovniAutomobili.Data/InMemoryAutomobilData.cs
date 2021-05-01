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
                new Automobil() { Id = 1, Description = "Audi A3", Gorivo = GorivoVrsta.Benzin},
                new Automobil() { Id = 2, Description = "Audi A4", Gorivo = GorivoVrsta.Dizel},
                new Automobil() { Id = 3, Description = "Audi Q2", Gorivo = GorivoVrsta.Hibrid},
                new Automobil() { Id = 4, Description = "Audi Q3", Gorivo = GorivoVrsta.Benzin}
            };
        }

        public IEnumerable<Automobil> GetAll()
        {
            var cars = from c in _cars
                       orderby c.Description
                       select c;
            return cars;
        }
    }
}
