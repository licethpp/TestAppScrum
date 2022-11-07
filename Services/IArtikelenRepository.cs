using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
   public interface IArtikelenRepository
    {
        IEnumerable<Artikelen> GetArtikelen(int ArtikelenId);
        public Artikelen GetArtikelenbyId(int id);
        IEnumerable<Categorieen> GetCategorieen();

        Personeelslidaccount GetPersoneelslid(string Emailadres, string Paswoord);
        Personeelslidsecuritygroepen securitygroepenId(int id);
        void JuisteLogin(string Emailadres);
        void FouteLogin(string Emailadres);
        void UpdatePasswoord(string email,string  Paswoord);

        public IEnumerable<Leverancier> GetLeveranciers(int leveranciersId);

        public IEnumerable<Actiecode> GetActiecodes(int actiecodesId);

        int VoegLeverancierToe(Leverancier nieuweLeverancier);

        public IEnumerable<Plaatsen> GetAllPlaatsen();

        void EditArtikel(Artikelen artikel);

    }
}
