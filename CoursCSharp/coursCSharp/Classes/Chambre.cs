using System;
using System.Collections.Generic;
using System.Text;

namespace coursCSharp.Classes
{
    public class Chambre
    {
        private int numero;
        private decimal prix;
        private string status;

        public int Numero { get => numero; set => numero = value; }
        public decimal Prix { get => prix; set => prix = value; }
        public string Status { get => status; set => status = value; }

        public Chambre()
        {
            Status = "Libre";
        }

        public override string ToString()
        {
            return "N° Chambre " + Numero + " Prix : " + Prix + " Status : " + Status;
        }
    }
}
