using System;
using System.Collections.Generic;
using System.Text;

namespace coursCSharp.Classes
{
    public class CompteEpargne : Compte
    {
        private static decimal taux = 2;
        public CompteEpargne() : base()
        {

        }
        public CompteEpargne(Client c) : base(c)
        {

        }
        public CompteEpargne(Client c, decimal s) : base(c, s)
        {

        }
        public void MiseAjourSolde()
        {
            solde = solde * (1 + taux / 100);
        }
    }
}
