using CoursWPFContext.Classes;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CoursWPFContext.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private Personne personne;
        private Adresse adresse;

        public string Nom{get => Personne.Nom;set => Personne.Nom = value;}
        public string Prenom { get => Personne.Prenom; set => Personne.Prenom = value; }
        public string Rue { get => Adresse.Rue; set => Adresse.Rue = value; }
        public string Ville { get => Adresse.Ville; set => Adresse.Ville = value; }
        public string CodePostal { get => Adresse.CodePostal; set => Adresse.CodePostal = value; }
        public Personne Personne { get => personne; set => personne = value; }
        public Adresse Adresse { get => adresse; set => adresse = value; }
        public ICommand SaveCommand { get; set; }
        public MainViewModel()
        {
            Personne = new Personne();
            Adresse = new Adresse();
            SaveCommand = new RelayCommand(Save);
        }

        public void Save()
        {
            //Save personne
        }
    }
}
