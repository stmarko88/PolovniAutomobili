using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using PolovniAutomobili.Core;
using PolovniAutomobili.Data;

namespace PolovniAutomobili.Pages.Automobili
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration configuration;
        private readonly IAutomobilData automobilData;

        public string Message { get; set; }
        public IEnumerable<Automobil> Cars { get; set; } 

        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration configuration, 
                         IAutomobilData automobilData)
        {
            this.configuration = configuration;
            this.automobilData = automobilData;
        }
        public void OnGet()
        {
            Message = configuration["Message"];
            Cars = automobilData.GetCarsByName(SearchTerm);
        }
    }
}
