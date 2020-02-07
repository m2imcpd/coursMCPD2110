using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CorrectionAnnonce.Tools
{
    public class DataBase
    {
        private static string  stringConnection = @"Data Source=(LocalDb)\CoursSql;Integrated Security=True";
        public static SqlConnection connection = new SqlConnection(stringConnection);
    }
}
