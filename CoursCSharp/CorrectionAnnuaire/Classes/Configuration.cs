using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CorrectionAnnuaire.Classes
{
    public class Configuration
    {
        public static SqlConnection Connection = new SqlConnection(@"Data Source=(LocalDb)\coursSql;Integrated Security=True");
    }
}
