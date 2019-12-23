using System;
using System.Collections.Generic;
using System.Text;

namespace coursCSharp.Classes
{
    public class Moderateur : Abonne
    {
        public Moderateur(Forum f) : base(f)
        {

        }

        public void SupprimerNouvelle(Nouvelle n)
        {
            forum.Nouvelles.Remove(n);
        }

        public void BannirAbonne(Abonne a)
        {
            forum.Abonnes.Remove(a);
        }
    }
}
