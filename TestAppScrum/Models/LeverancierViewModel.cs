using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAppScrum.Models
{
    public class LeverancierViewModel
    {
        public int LeveranciersId { get; set; }
        public string Naam { get; set; }
        public string BtwNummer { get; set; }
        public string Straat { get; set; }
        public string HuisNummer { get; set; }
        public string Bus { get; set; }
        public int PlaatsId { get; set; } //PlaatsId
        public string FamilienaamContactpersoon { get; set; }
        public string VoornaamContactpersoon { get; set; }

        public IEnumerable<SelectListItem> Plaats { get; set; }
    }

}
