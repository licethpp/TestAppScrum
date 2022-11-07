using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
     public class ArtikelenService : IArtikelenRepository
    {
        private IArtikelenRepository ArtikelenRepository;

        public ArtikelenService(IArtikelenRepository ArtikelenRepository)
        {
            this.ArtikelenRepository = ArtikelenRepository;
        }

        public void FouteLogin(string Emailadres)
        {
            ArtikelenRepository.FouteLogin(Emailadres);
        }

        public IEnumerable<Artikelen> GetArtikelen(int ArtikelenId)
        {
            return ArtikelenRepository.GetArtikelen(ArtikelenId);
        }


        public IEnumerable<Leverancier> GetLeveranciers(int leveranciersId)
        {
            return ArtikelenRepository.GetLeveranciers(leveranciersId);
        }
        public IEnumerable<Actiecode> GetActiecodes(int actiecodesId)
        {
            return ArtikelenRepository.GetActiecodes(actiecodesId);
        }

        public IEnumerable<Categorieen> GetCategorieen()
        {
            return ArtikelenRepository.GetCategorieen().ToList();
        }

        public Personeelslidaccount GetPersoneelslid(string Emailadres, string Paswoord)
        {
            return ArtikelenRepository.GetPersoneelslid(Emailadres, Paswoord);
        }

        public void JuisteLogin(string Emailadres)
        {
            ArtikelenRepository.JuisteLogin(Emailadres);
        }

        public Personeelslidsecuritygroepen securitygroepenId(int id)
        {
           return ArtikelenRepository.securitygroepenId(id);
        }

        public void UpdatePasswoord(string email,string Paswoord)
        {
             ArtikelenRepository.UpdatePasswoord(email,Paswoord);
        }

        public int VoegLeverancierToe(Leverancier nieuweLeverancier)
        {

          return  ArtikelenRepository.VoegLeverancierToe(nieuweLeverancier);
           
        }

        public IEnumerable<Plaatsen> GetAllPlaatsen()
        {

            return ArtikelenRepository.GetAllPlaatsen().ToList();
        }

        public Artikelen GetArtikelenbyId(int id)
        {
            return ArtikelenRepository.GetArtikelenbyId(id);
        }

        public  EditArtikel (Artikelen artikel)
        {

             ArtikelenRepository.EditArtikel(artikel);


        }
    }
}
