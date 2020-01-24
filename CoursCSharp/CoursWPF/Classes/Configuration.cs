using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursWPF.Classes
{
    public class Configuration
    {
        public static SqlConnection connection = new SqlConnection(@"Data Source=(LocalDb)\CoursSql;Integrated Security=True");
    }
}
