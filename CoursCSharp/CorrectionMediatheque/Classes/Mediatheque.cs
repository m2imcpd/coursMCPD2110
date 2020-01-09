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

        }
        public bool AddAdherent(Adherent adherent)
        {
            bool result = true;
            Adherents.Add(adherent);
            //Sauvegarde.SaveAdherents(Adherents);
            Sauvegarde.TaskSaveAdherents(Adherents);
            return result;
        }
    }
}
