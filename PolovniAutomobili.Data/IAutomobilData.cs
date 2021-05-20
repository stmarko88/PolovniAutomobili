using PolovniAutomobili.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolovniAutomobili.Data
{
    public interface IAutomobilData
    {
        IEnumerable<Automobil> GetCarsByName(string name);
        Automobil GetById(int id);
        Automobil Update(Automobil updatedCar);
        Automobil Add(Automobil newCar);
        Automobil Delete(int id);
        int Commit(); // simulacija Entity Framework-a i SaveChanges
        // Dok koristimo memorijske podatke, ova metoda nema smisla 
    }
}
