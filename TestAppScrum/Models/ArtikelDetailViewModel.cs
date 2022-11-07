using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestAppScrum.Models
{
    public class ArtikelDetailViewModel
    {
        [Display(Name = "ID")]
        public int ArtikelId { get; set; }
        [Display(Name = "EAN")]
        [Required(ErrorMessage = "{0} is verplicht")]
        public string Ean { get; set; }
        [Required(ErrorMessage = "{0} is verplicht")]
        [StringLength(45, ErrorMessage = "{0} moet kleiner zijn als {1}")]
        public string Naam { get; set; }
        [Required(ErrorMessage = "{0} is verplicht")]
        [StringLength(255, ErrorMessage = "{0} moet kleiner zijn als {1}")]
        public string Beschrijving { get; set; }
        [Required(ErrorMessage = "{0} is verplicht")]
        [DisplayFormat(DataFormatString = "{0:€ #,##0.00}")]
        [ModelBinder(BinderType = typeof(DecimalModelBinder))]
        public decimal Prijs { get; set; }
        [Display(Name = "Gewicht")]
        [DisplayFormat(DataFormatString = "{0:#,## g}")]
        [Required(ErrorMessage = "{0} is verplicht")]
        [Range(1, 100000, ErrorMessage = "{0} moet tussen {1} en {2} zijn")]
        public int GewichtInGram { get; set; }
        [Required(ErrorMessage = "{0} is verplicht")]
        [Range(0, 1000, ErrorMessage = "{0} moet tussen {1} en {2} zijn")]
        public int Bestelpeil { get; set; }
        [Required(ErrorMessage = "{0} is verplicht")]
        public int Voorraad { get; set; }
        [Display(Name = "Minimum voorraad")]
        [Required(ErrorMessage = "{0} is verplicht")]
        [Range(0, 1000, ErrorMessage = "{0} moet tussen {1} en {2} zijn")]
        public int MinimumVoorraad { get; set; }
        [Display(Name = "Maximum voorraad")]
        [Required(ErrorMessage = "{0} is verplicht")]
        [Range(0, 1000, ErrorMessage = "{0} moet tussen {1} en {2} zijn")]
        public int MaximumVoorraad { get; set; }
        [Required(ErrorMessage = "{0} is verplicht")]
        [Range(1, 1000, ErrorMessage = "{0} moet tussen {1} en {2} zijn")]
        public int Levertijd { get; set; }
        [Display(Name = "Aantal besteld leverancier")]
        [Required(ErrorMessage = "{0} is verplicht")]
        [Range(0, 1000, ErrorMessage = "{0} moet tussen {1} en {2} zijn")]
        public int AantalBesteldLeverancier { get; set; }
        [Display(Name = "Maximum aantal op een magazijnplaats")]
        [Required(ErrorMessage = "{0} is verplicht")]
        [Range(0, 1000, ErrorMessage = "{0} moet tussen {1} en {2} zijn")]
        public int MaxAantalInMagazijnPlaats { get; set; }
    }
}
