using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace MeuSQL.Class.DataTypes
{
    [DefaultPropertyAttribute("General")]
    class clsBit
    {
        private string _Lenght = "";
        [CategoryAttribute("General"), DescriptionAttribute("")]
        public string Lenght
        {
            get { return _Lenght; }
            set { _Lenght = value; }
        }
    }
}
