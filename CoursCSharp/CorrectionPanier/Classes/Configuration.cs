using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CorrectionPanier.Classes
{
    public class Configuration
    {
        public static SqlConnection Connection = new SqlConnection(@"Data Source=(LocalDb)\CoursSql;Integrated Security=True");
        public static DataSet DataSet = new DataSet();
    }
}
