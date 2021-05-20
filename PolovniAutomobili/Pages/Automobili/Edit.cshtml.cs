using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PolovniAutomobili.Core;
using PolovniAutomobili.Data;

namespace PolovniAutomobili.Pages.Automobili
{
    public class EditModel : PageModel
    {
        private readonly IAutomobilData automobilData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Automobil Car { get; set; }
        public IEnumerable<SelectListItem> Goriva { get; set; }
        public EditModel(IAutomobilData automobilData, IHtmlHelper htmlHelper)
        {
            this.automobilData = automobilData;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? carId)
        {
            Car = new Automobil();
            if (carId.HasValue)
            {
                Car = automobilData.GetById(carId.Value);
            }

            Goriva = htmlHelper.GetEnumSelectList<GorivoVrsta>();
            if (Car == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Goriva = htmlHelper.GetEnumSelectList<GorivoVrsta>();
                return Page();
            }

            if(Car.Id > 0)
            {
                Car = automobilData.Update(Car);
            }
            else
            {
                Car = automobilData.Add(Car);
            }
            
            automobilData.Commit();
            TempData["Message"] = "Izmene su uspešno sačuvane";
            return RedirectToPage("./Detail", new { carId = Car.Id });

        }
    }
}
