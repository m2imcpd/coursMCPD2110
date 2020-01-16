using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CorrectionPanier.Classes
{
    public class Produit
    {
        private static SqlDataAdapter dataAdapter;
        private int id;
        private string label;
        private decimal prix;

        public int Id { get => id; set => id = value; }
        public string Label { get => label; set => label = value; }
        public decimal Prix { get => prix; set => prix = value; }

        public static void Load()
        {
            if(Configuration.DataSet.Tables["produit"] != null)
            {
                Configuration.DataSet.Tables["produit"].Rows.Clear();
            }
            dataAdapter = new SqlDataAdapter("SELECT * FROM produit", Configuration.Connection);
            dataAdapter.InsertCommand = new SqlCommand("INSERT INTO produit (label, prix) values(@label, @prix)", Configuration.Connection);
            dataAdapter.InsertCommand.Parameters.Add("@label", SqlDbType.VarChar, 50, "label");
            dataAdapter.InsertCommand.Parameters.Add("@prix", SqlDbType.Decimal, 10, "prix");
            dataAdapter.DeleteCommand = new SqlCommand("DELETE FROM produit where id=@id", Configuration.Connection);
            dataAdapter.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 11, "id");
            Configuration.Connection.Open();
            dataAdapter.Fill(Configuration.DataSet, "produit");
            Configuration.Connection.Close();
        }

        public static void Save()
        {
            if(dataAdapter != null)
            {
                Configuration.Connection.Open();
                dataAdapter.Update(Configuration.DataSet.Tables["produit"]);
                Configuration.Connection.Close();
            }
        }

        public override string ToString()
        {
            return $"Id : {Id}, Label : {Label}, Prix : {Prix}";
        }
    }
}
