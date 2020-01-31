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
            get => Pendu.Masque;
        }

        private string lettre;

        public string Lettre
        {
            get => lettre;
            set  {
                if(Pendu.TesterLettre(value))
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

        public int Compteur { get => Pendu.Compteur; }
        public Pendu Pendu { get => pendu; set => pendu = value; }

        public PenduViewModel()
        {
            Pendu = new Pendu();
        }
        public void Start()
        {
            pendu = new Pendu();
            RaisePropertyChanged("Masque");
            RaisePropertyChanged("Compteur");
        }
    }
}
