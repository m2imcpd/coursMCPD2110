﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursAspNetCore.Tools
{
    public class Configuration
    {
        private static string stringConnection = @"Data Source=(LocalDb)\CoursSql;Integrated Security=True";
        public static SqlConnection connection = new SqlConnection(stringConnection); 
    }
}
