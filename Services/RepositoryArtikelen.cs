using Microsoft.EntityFrameworkCore;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RepositoryArtikelen : IArtikelenRepository
    {

        private prulariacomContext context;

        public RepositoryArtikelen(prulariacomContext context)
        {
            this.context = context;
        }
        //prulariacomContext
        public IEnumerable<Artikelen> GetArtikelen(int ArtikelenId)
        {

            return context.Artikelens.ToList();
        }
        public IEnumerable<Categorieen> GetCategorieen()
        {
            return context.Categorieens.ToList();
        }

        public Personeelslidaccount GetPersoneelslid(string Emailadres, string Paswoord)
        {
            return context.Personeelslidaccounts.Where(x => x.Emailadres == Emailadres && x.Paswoord == x.Paswoord).FirstOrDefault();
        }


        public void JuisteLogin(string Emailadres)
        {
            Personeelslidaccount p = context.Personeelslidaccounts.Where(g => g.Emailadres == Emailadres).FirstOrDefault();
            if (p != null)
            {

                context.SaveChanges();
            }
        }


        public void FouteLogin(string Emailadres)
        {
            Personeelslidaccount p = context.Personeelslidaccounts.Where(g => g.Emailadres == Emailadres).FirstOrDefault();
            if (p != null)
            {
                context.SaveChanges();
            }
        }

        public Personeelslidsecuritygroepen securitygroepenId(int id)
        {
            Personeelslidsecuritygroepen s = context.Personeelslidsecuritygroepens.Where(x => x.PersoneelslidId == id).Include(a => a.SecurityGroep).FirstOrDefault();
            return s;
        }

        public void UpdatePasswoord(string email, string Paswoord)
        {
            Personeelslidaccount b = context.Personeelslidaccounts.Where(x => x.Emailadres == email).FirstOrDefault();
            b.Paswoord = Paswoord;
            context.SaveChanges();
        }

        public IEnumerable<Leverancier> GetLeveranciers(int leveranciersId)
        {
            return context.Leveranciers.ToList();
        }

        public IEnumerable<Actiecode> GetActiecodes(int actiecodesId)
        {
            return context.Actiecodes.ToList();
        }

        public int VoegLeverancierToe(Leverancier nieuweLeverancier)
        {
            context.Leveranciers.Add(nieuweLeverancier);
            return context.SaveChanges();
        }

        public IEnumerable<Plaatsen> GetAllPlaatsen()
        {

            return context.Plaatsens.ToList();
        }

        public Artikelen  GetArtikelenbyId(int id)
        {
            return context.Artikelens.Find(id);
        }

        public void EditArtikel(Artikelen artikel)
        {
             context.Artikelens.Update(artikel);
            context.SaveChanges();

        }

        int IArtikelenRepository.EditArtikel(Artikelen artikel)
        {
            throw new NotImplementedException();
        }
    }
  }


