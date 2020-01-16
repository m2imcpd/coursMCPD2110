using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CorrectionPanier.Classes
{
    public class Panier
    {
        private int id;
        private string nomClient;
        private string telClient;
        private decimal total;
        private List<Produit> produits;
        public static SqlCommand command;

        public int Id { get => id; set => id = value; }
        public string NomClient { get => nomClient; set => nomClient = value; }
        public string TelClient { get => telClient; set => telClient = value; }
        public decimal Total { get => total; }
        public List<Produit> Produits { get => produits; set => produits = value; }

        public Panier()
        {
            Produits = new List<Produit>();
        }

        public void Save()
        {
            total = 0;
            Produits.ForEach(p =>
            {
                total += p.Prix;
            });
            command = new SqlCommand("INSERT INTO panier (nom_client, tel_client, total) OUTPUT INSERTED.ID values(@nom, @tel, @total)", Configuration.Connection);
            command.Parameters.Add(new SqlParameter("@nom", NomClient));
            command.Parameters.Add(new SqlParameter("@tel", TelClient));
            command.Parameters.Add(new SqlParameter("@total", Total));
            Configuration.Connection.Open();
            Id = (int)command.ExecuteScalar();
            if(Id > 0)
            {
                command.Dispose();
                Produits.ForEach(p =>
                {
                    command = new SqlCommand("INSERT INTO panier_produit (produit_id, panier_id) values(@produitId, @panierId)", Configuration.Connection);
                    command.Parameters.Add(new SqlParameter("@produitId", p.Id));
                    command.Parameters.Add(new SqlParameter("@panierId",Id));
                    command.ExecuteNonQuery();
                    command.Dispose();
                });
            }
            Configuration.Connection.Close();
        }

        public static Panier GetPanierById(int id)
        {
            Panier panier = null;
            string request = "SELECT p.id as panier_id, p.nom_client, p.tel_client, p.total, pr.id as produit_id, pr.label, pr.prix " +
                            "FROM panier as p " +
                            "left join panier_produit as pp on p.id = pp.panier_id " +
                            "left join produit as pr on pr.id = pp.produit_id " +
                            "where p.id = @id";
            command = new SqlCommand(request, Configuration.Connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            Configuration.Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            panier = new Panier();
            panier.Id = id;
            while(reader.Read())
            {
                panier.NomClient = reader.GetString(1);
                panier.TelClient = reader.GetString(2);
                panier.total = reader.GetDecimal(3);
                panier.Produits.Add(new Produit { Id = reader.GetInt32(4), Label = reader.GetString(5), Prix = reader.GetDecimal(6) });
            }
            command.Dispose();
            Configuration.Connection.Close();
            return panier;
        }

        public override string ToString()
        {
            return $"Client : {NomClient}, Téléphone : {TelClient}, Total : {Total}";
        }
    }
}
