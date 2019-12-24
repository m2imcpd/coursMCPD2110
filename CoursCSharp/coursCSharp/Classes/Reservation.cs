using System;
using System.Collections.Generic;
using System.Text;

namespace coursCSharp.Classes
{
    public class Reservation
    {
        private int numero;
        private Chambre chambre;
        private Client client;
        private string status;

        public int Numero { get => numero; set => numero = value; }
        public Chambre Chambre { get => chambre; set => chambre = value; }
        public Client Client { get => client; set => client = value; }
        public string Status { get => status; set => status = value; }

        public override string ToString()
        {
            return "Client : " + Client + " Chambre : " + Chambre + " status : " + Status; 
        }
    }
}
