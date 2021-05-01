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
        IEnumerable<Automobil> GetAll();
    }
}
