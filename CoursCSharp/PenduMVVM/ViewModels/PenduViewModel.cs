using GalaSoft.MvvmLight;
using PenduMVVM.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenduMVVM.ViewModels
{
    public class PenduViewModel: ViewModelBase
    {
        private Pendu pendu;
        public string Masque
        {
            get => pendu.Masque;
        }

        private string lettre;

        public string Lettre
        {
            get => lettre;
            set  {
                if(pendu.TesterLettre(value))
                {
                    RaisePropertyChanged("Masque");
                }
                else
                {
                    RaisePropertyChanged("Compteur");
                }
                lettre = "";
            }
        }

        public int Compteur { get => pendu.Compteur; }

        public PenduViewModel()
        {
            pendu = new Pendu();
        }
    }
}
