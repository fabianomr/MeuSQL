using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeuSQL.Class
{
    class clsFunctions
    {
        
        public static bool IsNumeric(object value)
        {
            try
            {
                int i = Convert.ToInt32(value.ToString());
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
