using System;
using System.Collections.Generic;
using System.Text;

namespace coursCSharp.Classes
{
    public class ComptePayant : Compte
    {
        public ComptePayant() : base()
        {

        }

        public ComptePayant(Client c) : base(c)
        {

        }

        public ComptePayant(Client c, decimal s) : base(c,s)
        {

        }

        public override void Deposer(decimal montant)
        {
            base.Deposer(montant);
            FraisBanque();
        }

        public override bool Retirer(decimal montant)
        {
            if(montant + 2 <= solde)
            {
                FraisBanque();
                return base.Retirer(montant);
            }
            else
            {
                return false;
            }
        }

        private void FraisBanque()
        {
            Operation o = new Operation(-2, DateTime.Now);
            Operations[cle] = o;
            cle++;
            solde -= 2;
        }
    }
}
