using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PolovniAutomobili.Core;
using PolovniAutomobili.Data;

namespace PolovniAutomobili.Pages.Automobili
{
    public class DetailModel : PageModel
    {
        private readonly IAutomobilData automobilData;

        [TempData]
        public string Message { get; set; }
        public Automobil Car { get; set; }

        public DetailModel(IAutomobilData automobilData)
        {
            this.automobilData = automobilData;
        }

        public IActionResult OnGet(int carId)
        {
            Car = automobilData.GetById(carId);
            if (Car == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}
