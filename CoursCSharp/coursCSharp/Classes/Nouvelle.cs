using System;
using System.Collections.Generic;
using System.Text;

namespace coursCSharp.Classes
{
    public class Nouvelle
    {
        private string sujet;
        private string texte;
        private DateTime dateAjout;

        public string Sujet { get => sujet; set => sujet = value; }
        public string Texte { get => texte; set => texte = value; }
        public DateTime DateAjout { get => dateAjout; set => dateAjout = value; }
    }
}
