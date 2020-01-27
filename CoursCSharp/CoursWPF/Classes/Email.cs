using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursWPF.Classes
{
    public class Email
    {
        private int id;
        private string mail;
        private int contactId;
        private SqlCommand command;

        public int Id { get => id; set => id = value; }
        public string Mail { get => mail; set => mail = value; }
        public int ContactId { get => contactId; set => contactId = value; }

        public bool Save()
        {
            //bool result = false;
            command = new SqlCommand("INSERT INTO email (mail, contact_id) OUTPUT INSERTED.ID values (@mail,@contactId)", Configuration.connection);
            command.Parameters.Add(new SqlParameter("@mail", Mail));
            command.Parameters.Add(new SqlParameter("@contactId", ContactId));
            Configuration.connection.Open();
            Id = (int)command.ExecuteScalar();
            command.Dispose();
            Configuration.connection.Close();
            //if(Id > 0)
            //{
            //    result = true;
            //}
            //return result;
            return Id > 0;
        }

        public override string ToString()
        {
            return $"{Mail}";
        }
    }
}
