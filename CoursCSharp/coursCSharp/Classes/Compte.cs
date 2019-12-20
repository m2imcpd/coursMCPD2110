using System;
using System.Collections.Generic;
using System.Text;

namespace coursCSharp.Classes
{
    public class Compte
    {
        protected static int compteur = 0;
        private int numero;
        private Client client;
        private Operation[] operations;
        protected decimal solde;
        protected static int cle = 0;

        public int Numero { get => numero; set => numero = value; }
        public Client Client { get => client; set => client = value; }
        public Operation[] Operations { get => operations; set => operations = value; }

        public Compte()
        {
            compteur++;
            Numero = compteur;
            operations = new Operation[100];
            solde = 0;
        }

        public Compte(Client c) : this()
        {
            Client = c;
        }
        public Compte(Client c, decimal s) : this(c)
        {
            Deposer(s);

        }

        public virtual void Deposer(decimal montant)
        {
            Operation o = new Operation(montant, DateTime.Now);
            Operations[cle] = o;
            cle++;
            solde += montant;
        }

        public virtual bool Retirer(decimal montant)
        {
            bool result = false;
            if(solde >= montant)
            {
                Operation o = new Operation(montant*-1, DateTime.Now);
                Operations[cle] = o;
                cle++;
                solde -= montant;
                result = true;
            }
            return result;
        }

        public override string ToString()
        {
            return "Client : " + client + " Solde : " + solde;
        }
    }
}
