using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CorrectionMediatheque.Classes
{
    public class Adherent
    {
        private string nom;
        private string prenom;
        private string telephone;
        private List<Oeuvre> oeuvres;

        public event Action<Adherent> maxEmprunt;

        public string Nom
        {
            get => nom; set
            {
                if (Regex.IsMatch(value, Configuration.PatternName))
                    nom = value;
                else
                    throw new Exception("Erreur nom");
            }
        }
        public string Prenom
        {
            get => prenom; set
            {
                if (Regex.IsMatch(value, Configuration.PatternName))
                    prenom = value;
                else
                    throw new Exception("Erreur prénom");
            }
        }
        public string Telephone
        {
            get => telephone; set
            {
                if (Regex.IsMatch(value, Configuration.PatternTelephone))
                    telephone = value;
                else
                    throw new Exception("Erreur téléphone");
            }
        }

        public List<Oeuvre> Oeuvres { get => oeuvres; set => oeuvres = value; }

        public Adherent()
        {
            Oeuvres = new List<Oeuvre>();
        }

        public bool Emprunter(Oeuvre oeuvre)
        {
            if(Oeuvres.Count < 3)
            {
                Oeuvres.Add(oeuvre);
                return true;
            }
            else
            {
                maxEmprunt?.Invoke(this);
                return false;
            }
        }
    }
}
