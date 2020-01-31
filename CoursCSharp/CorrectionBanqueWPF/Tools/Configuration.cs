using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrectionBanqueWPF.Tools
{
    public class Configuration
    {
        private static string stringConnection = @"";
        public static SqlConnection connection = new SqlConnection(stringConnection); 
    }
}
