using System;
using System.Collections.Generic;
using System.Text;

namespace CorrectionBanque.Classes
{
    public class Operation
    {
        private int numero;
        private decimal montant;
        private DateTime date;
        private static int compteur = 0;

        public int Numero { get => numero; set => numero = value; }
        public decimal Montant { get => montant; set => montant = value; }
        public DateTime Date { get => date; set => date = value; }

        public Operation()
        {
            compteur++;
            Numero = compteur;
        }

        public Operation(decimal m, DateTime d) : this()
        {
            Montant = m;
            Date = d;
        }

        public override string ToString()
        {
            return "Date operation : " + Date + " Montant : " + Montant;
        }
    }
}
