using System;
using System.Collections.Generic;
using System.Text;

namespace coursCSharp.Classes
{
    public class EmployeCollection
    {
        private List<Employe> listeEmploye;

        public List<Employe> ListeEmploye { get => listeEmploye; set => listeEmploye = value; }

        public EmployeCollection()
        {
            ListeEmploye = new List<Employe>();
        }

        public List<Employe> this[DateTime date]
        {
           get
            {
                List<Employe> liste = new List<Employe>();
                foreach(Employe e in ListeEmploye)
                {
                    if(e.DateNaissance == date)
                    {
                        liste.Add(e);
                    }
                }
                return liste;
            }
            set
            {
                ListeEmploye.AddRange(value);
            }
        }
    }
}
