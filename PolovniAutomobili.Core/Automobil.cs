using System.ComponentModel.DataAnnotations;

namespace PolovniAutomobili.Core
{
    public class Automobil
    {
        public int Id { get; set; }

        [Required, StringLength(80)]
        public string Name { get; set; }

        [Required, StringLength(255)]
        public string Description { get; set; }
        public GorivoVrsta Gorivo { get; set; }
    }
}
