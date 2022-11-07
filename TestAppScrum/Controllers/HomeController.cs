using FireSharp.Config;
using FireSharp.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Models.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TestAppScrum.Models;

namespace TestAppScrum.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "",
            BasePath = ""
        };

        IFirebaseClient firebaseClient;
        private ArtikelenService artikelenService;

        private readonly ILogger<HomeController> _logger;

        public prulariacomContext prulariacomContext;
        public HomeController(ILogger<HomeController> logger, ArtikelenService artikelenService)
        {
            _logger = logger;
            this.artikelenService = artikelenService;

        }

        public IActionResult categoriewijzigen()
        {
            prulariacomContext p = new prulariacomContext(); //moet normaal van service komen maar is voor de demo
            CategorieViewModel c = new CategorieViewModel();

            c.Categorieen = GetSelectListItemsCategorieen(p.Categorieens.ToList());
            return View(c);
        }

        private List<SelectListItem> GetSelectListItemsCategorieen(IEnumerable<Categorieen> elements)
        {
            var selectList = new List<SelectListItem>();
            foreach (var element in elements)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element.CategorieId.ToString(),
                    Text = element.Naam
                });
            }
            return selectList;
        }

        public ActionResult FillCategorie(int categorieid)
        {
            prulariacomContext p = new prulariacomContext(); // moet normaal van de service komen maar is voor de demo

            var cat = p.Categorieens.Where(x => x.CategorieId == categorieid).FirstOrDefault();
            return Json(cat);
        }

        //Aanpassen
        [HttpPost]
        public IActionResult Aanpassen(CategorieViewModel p)
        {
            var s = 0; //hier een update naar de database
            return null;
        }

        public IActionResult Artikelen(int artikelId)
        {
            //prulariacomContext p = new prulariacomContext(); // moet normaal van de service komen maar is voor de demo

            var artikelen = artikelenService.GetArtikelen(artikelId).ToList();

            return View(artikelen);

        }

        public IActionResult DetailArtikel(int id)
        {
            var ArtikelDetail = artikelenService.GetArtikelenbyId(id);

            ArtikelDetailViewModel artikelDetailViewModel = new ArtikelDetailViewModel();
            {
                artikelDetailViewModel.ArtikelId = ArtikelDetail.ArtikelId;
                artikelDetailViewModel.AantalBesteldLeverancier = ArtikelDetail.AantalBesteldLeverancier;
                artikelDetailViewModel.Beschrijving = ArtikelDetail.Beschrijving;
                artikelDetailViewModel.Bestelpeil = ArtikelDetail.Bestelpeil;
                artikelDetailViewModel.Ean = ArtikelDetail.Ean;
                artikelDetailViewModel.GewichtInGram = ArtikelDetail.GewichtInGram;
                artikelDetailViewModel.Levertijd = ArtikelDetail.Levertijd;
                artikelDetailViewModel.MaxAantalInMagazijnPlaats = ArtikelDetail.MaxAantalInMagazijnPlaats;
                artikelDetailViewModel.MaximumVoorraad = ArtikelDetail.MaximumVoorraad;
                artikelDetailViewModel.MinimumVoorraad = ArtikelDetail.MinimumVoorraad;
                artikelDetailViewModel.Naam = ArtikelDetail.Naam;
                artikelDetailViewModel.Prijs = ArtikelDetail.Prijs;
                artikelDetailViewModel.Voorraad = ArtikelDetail.Voorraad;

            }
            return View(artikelDetailViewModel);
        }
        [HttpGet]
        public IActionResult EditForm(int id)
        {
            var artikel = artikelenService.GetArtikelenbyId(id);
            return View(artikel);
        }


        [HttpPost]
        public IActionResult Edit(ArtikelDetailViewModel artikel)
        {
            if (this.ModelState.IsValid)
            {
                artikelenService.EditArtikel.Update(artikel);
                return RedirectToAction(nameof(Index));
            }
            else
                return View(nameof(EditForm), artikel);
        }
        public IActionResult CreateCategoriee()
        {
            return View();
        }

        public IActionResult Leveranciers(int leveranciersId)
        {
            var leveranciers = artikelenService.GetLeveranciers(leveranciersId).ToList();
            return View(leveranciers);
            //overzicht van alle leveranciersgegeven, nieuwe leverancier toevoegen, gegevens van een leverancier wijzigen


        }



        public IActionResult AddLeveranciers()
        {
            LeverancierViewModel leverancierViewModel = new LeverancierViewModel();
            // leverancierViewModel.Plaats = ;
            leverancierViewModel.Plaats = GetSelectListPlaatsen(artikelenService.GetAllPlaatsen()).ToList();
            return View(leverancierViewModel);
        }

        [HttpPost]
        public IActionResult AddLeveranciers(LeverancierViewModel leverancierViewModel)
        {
            // var leverancier = artikelenService.VoegLeverancierToe();
            if (ModelState.IsValid)
            {

                Leverancier leverancier = new Leverancier();
                leverancier.Naam = leverancierViewModel.Naam;
                leverancier.BtwNummer = leverancierViewModel.BtwNummer;
                leverancier.Straat = leverancierViewModel.Straat;
                leverancier.HuisNummer = leverancierViewModel.HuisNummer;
                leverancier.Bus = leverancierViewModel.Bus;
                leverancier.FamilienaamContactpersoon = leverancierViewModel.FamilienaamContactpersoon;
                leverancier.VoornaamContactpersoon = leverancierViewModel.VoornaamContactpersoon;
                leverancierViewModel.Plaats = leverancierViewModel.Plaats;
                leverancier.PlaatsId = leverancierViewModel.PlaatsId;
                var l = artikelenService.VoegLeverancierToe(leverancier);

                leverancierViewModel.Plaats = GetSelectListPlaatsen(artikelenService.GetAllPlaatsen()).ToList();

                return View(leverancierViewModel);

            }
            else
            {
                leverancierViewModel.Plaats = GetSelectListPlaatsen(artikelenService.GetAllPlaatsen()).ToList();
                return View(leverancierViewModel);
            }
        }

        //ListPlaat
        private IEnumerable<SelectListItem> GetSelectListPlaatsen(IEnumerable<Plaatsen> elements)
        {
            var selectList = new List<SelectListItem>();
            foreach (var element in elements)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element.PlaatsId.ToString(),
                    Text = element.Postcode + " " + element.Plaats
                });
            }
            return selectList;

        }


        public IActionResult Actiecodes(int actiecodesId)
        {
            var actiecodes = artikelenService.GetActiecodes(actiecodesId).ToList();
            return View(actiecodes);
            //Een overzicht van actiecodes.voegt een nieuwe actiecode toe, wijzigt de actiecode

        }

        public IActionResult Index()
        {


            return View();
        }



        public IActionResult Edit(int id = 0)
        {
            var artikelen = artikelenService.GetArtikelen(id).ToList();

            if (artikelen == null)
            {

                return View("Page Not Found");
            }
            prulariacomContext p = new prulariacomContext();
            ViewBag.ArtikelId = new SelectList(
                p.Artikelens, " ArtikelId", "Naam", artikelen.Count
                );
            return View(artikelen);




        }
        public IActionResult Categorieen()
        {
            var categorieen = artikelenService.GetCategorieen();
            return View(categorieen);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
