using System;
using System.Collections.Generic;
using System.Text;

namespace CorrectionMediatheque.Classes
{
    public abstract class Oeuvre
    {
        private string titre;
        private string autheur;
        private DateTime dateSortie;
        private Statut status;

        public string Titre { get => titre; set => titre = value; }
        public string Autheur { get => autheur; set => autheur = value; }
        public DateTime DateSortie { get => dateSortie; set => dateSortie = value; }
        public Statut Status { get => status; set => status = value; }

        public Oeuvre()
        {

        }
    }

    public enum Statut
    {
        Disponible,
        NonDisponible,
    }
}
