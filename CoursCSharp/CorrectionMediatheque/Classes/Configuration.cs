using System;
using System.Collections.Generic;
using System.Text;

namespace CorrectionMediatheque.Classes
{
    public class Configuration
    {
        public static string PatternName = @"^[a-zA-Z\s-]{2,}$";
        public static string PatternTelephone = @"^0\d{1}((-\d{2}){4}|(\.\d{2}){4}|(\s\d{2}){4})$";
        public static int MaxEmprunt = 3;
        public static string PathAdherents = "adherents.json";
    }
}
