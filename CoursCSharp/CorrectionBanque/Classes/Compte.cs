using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CorrectionBanque.Classes
{
    public class Compte
    {
        protected static int compteur = 0;
        private int numero;
        private Client client;
        private List<Operation> operations;
        protected decimal solde;
        protected static int cle = 0;
        public event Action<Compte> SoldeInsuffisant;
        public decimal Solde { get => solde; }
        public int Numero { get => numero; set => numero = value; }
        public Client Client { get => client; set => client = value; }
        public List<Operation> Operations { get => operations; set => operations = value; }
        public static SqlCommand command;
        public static SqlDataReader reader;
        public Compte()
        {
            Operations = new List<Operation>();
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
            Operation o = new Operation(montant, DateTime.Now) { NumeroCompte = Numero };
            Operations.Add(o);
            o.Save();
            solde += montant;
            Update();
        }

        public virtual bool Retirer(decimal montant)
        {
            bool result = false;
            if(solde >= montant)
            {
                Operation o = new Operation(montant * -1, DateTime.Now) { NumeroCompte = Numero};
                Operations.Add(o);
                o.Save();
                solde -= montant;
                Update();
                result = true;
            }else
            {
                SoldeInsuffisant?.Invoke(this);
            }
            return result;
        }

        public override string ToString()
        {
            return "Client : " + client + " Solde : " + solde;
        }

        public static Compte SearchByClientId(int id)
        {
            Compte compte = null;
            string request = "SELECT c.id as clientId, c.nom, c.prenom, c.telephone," +
                " cc.id as compteId, cc.solde," +
                "o.id, o.montant, o.dateOperation " +
                "FROM client as c " +
                "inner join compte as cc " +
                "on cc.clientId = c.Id " +
                "left join operation as o " +
                "on cc.Id = o.compteId " +
                "where c.Id = @id";
            command = new SqlCommand(request, Configuration.connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            Configuration.connection.Open();
            reader = command.ExecuteReader();
            if(reader.Read())
            {
                compte = new Compte()
                {
                    Numero = reader.GetInt32(4),
                    solde = reader.GetDecimal(5),
                    Client = new Client
                    {
                        Id = reader.GetInt32(0),
                        Nom = reader.GetString(1),
                        Prenom = reader.GetString(2),
                        Telephone = reader.GetString(3),
                    }
                };
                if((reader.GetValue(6) as int?) > 0)
                {
                    Operation o = new Operation
                    {
                        Numero = reader.GetInt32(6),
                        Montant = reader.GetDecimal(7),
                        Date = reader.GetDateTime(8)
                    };
                    compte.Operations.Add(o);
                }
                
                
            }
            while(reader.Read())
            {
                Operation o = new Operation
                {
                    Numero = reader.GetInt32(6),
                    Montant = reader.GetDecimal(7),
                    Date = reader.GetDateTime(8)
                };
                compte.Operations.Add(o);
            }
            reader.Close();
            command.Dispose();
            Configuration.connection.Close();
            return compte;
        }

        public static Compte SearchByClientPhone(string phone)
        {
            Compte compte = null;
            string request = "SELECT c.id as clientId, c.nom, c.prenom, c.telephone," +
                " cc.id as compteId, cc.solde," +
                "o.id, o.montant, o.dateOperation " +
                "FROM client as c " +
                "inner join compte as cc " +
                "on cc.clientId = c.id " +
                "left join operation as o " +
                "on cc.Id = o.compteId " +
                " where c.telephone = @phone";
            command = new SqlCommand(request, Configuration.connection);
            command.Parameters.Add(new SqlParameter("@phone", phone));
            Configuration.connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                compte = new Compte()
                {
                    Numero = reader.GetInt32(4),
                    solde = reader.GetDecimal(5),
                    Client = new Client
                    {
                        Id = reader.GetInt32(0),
                        Nom = reader.GetString(1),
                        Prenom = reader.GetString(2),
                        Telephone = reader.GetString(3),
                    }
                };
                if ((reader.GetValue(6) as int?) > 0)
                {
                    Operation o = new Operation
                    {
                        Numero = reader.GetInt32(6),
                        Montant = reader.GetDecimal(7),
                        Date = reader.GetDateTime(8)
                    };
                    compte.Operations.Add(o);
                }


            }
            while (reader.Read())
            {
                Operation o = new Operation
                {
                    Numero = reader.GetInt32(6),
                    Montant = reader.GetDecimal(7),
                    Date = reader.GetDateTime(8)
                };
                compte.Operations.Add(o);
            }

            reader.Close();
            command.Dispose();
            Configuration.connection.Close();
            return compte;
        }

        public bool Save()
        {
            decimal s = 0;
            string request = "INSERT INTO compte (clientId, solde)" +
                " OUTPUT INSERTED.ID " +
                "values (@clientId, @solde)";
            command = new SqlCommand(request, Configuration.connection);
            command.Parameters.Add(new SqlParameter("@clientId", Client.Id));
            command.Parameters.Add(new SqlParameter("@solde", s));
            Configuration.connection.Open();
            Numero = (int)command.ExecuteScalar();
            command.Dispose();
            Configuration.connection.Close();
            return Numero > 0;
        }

        public void Update()
        {
            string request = "UPDATE compte set solde = @solde where id=@id";
            command = new SqlCommand(request, Configuration.connection);
            command.Parameters.Add(new SqlParameter("@solde", Solde));
            command.Parameters.Add(new SqlParameter("@id", Numero));
            Configuration.connection.Open();
            command.ExecuteNonQuery();
            command.Dispose();
            Configuration.connection.Close();
        }
    }
}
