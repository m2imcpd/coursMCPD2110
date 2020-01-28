using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CorrectionBanque.Classes
{
    public class Operation
    {
        private int numero;
        private decimal montant;
        private DateTime date;
        private static int compteur = 0;
        private static SqlCommand command;
        private int numeroCompte;

        public int Numero { get => numero; set => numero = value; }
        public decimal Montant { get => montant; set => montant = value; }
        public DateTime Date { get => date; set => date = value; }
        public int NumeroCompte { get => numeroCompte; set => numeroCompte = value; }

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

        public void Save()
        {
            string request = "INSERT INTO operation (compteId, montant, dateOperation) values(@compteId, @montant, @dateOperation)";
            command = new SqlCommand(request, Configuration.connection);
            command.Parameters.Add(new SqlParameter("@compteId", NumeroCompte));
            command.Parameters.Add(new SqlParameter("@montant", Montant));
            command.Parameters.Add(new SqlParameter("@dateOperation", Date));
            Configuration.connection.Open();
            command.ExecuteNonQuery();
            command.Dispose();
            Configuration.connection.Close();
        }

        public override string ToString()
        {
            return "Date operation : " + Date + " Montant : " + Montant;
        }
    }
}
