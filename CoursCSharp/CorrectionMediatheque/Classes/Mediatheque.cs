using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CorrectionMediatheque.Classes
{
    public class Mediatheque
    {
        private List<Adherent> adherents;
        private List<Oeuvre> oeuvres;

        public List<Adherent> Adherents { get => adherents; set => adherents = value; }
        public List<Oeuvre> Oeuvres { get => oeuvres; set => oeuvres = value; }

        public Mediatheque()
        {
            //Adherents = Sauvegarde.ReadAdherents();
            Adherents = Sauvegarde.TaskReadAdherents().Result;
            Oeuvres = Sauvegarde.ReadOeuvres();
            foreach(Adherent a in Adherents)
            {
                a.maxEmprunt += MaxEmprunt;
            }
        }
        public bool AddAdherent(Adherent adherent)
        {
            bool result = true;
            Adherents.Add(adherent);
            //Sauvegarde.SaveAdherents(Adherents);
            Sauvegarde.TaskSaveAdherents(Adherents);
            return result;
        }

        public bool AddOeuvre(Oeuvre oeuvre)
        {
            bool result = true;
            Oeuvres.Add(oeuvre);
            Sauvegarde.SaveOeuvres<Oeuvre>(Oeuvres, "oeuvres.json");
            return result;
        }

        private void MaxEmprunt(Adherent adherent)
        {
            Console.WriteLine("Max emrrunt pour adherent " + adherent.Nom);
        }
    }
}
