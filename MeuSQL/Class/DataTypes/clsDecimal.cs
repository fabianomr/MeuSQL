using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace MeuSQL.Class.DataTypes
{
    [DefaultPropertyAttribute("General")]
    class clsDecimal
    {
        private bool _Unsigned = true;
        [CategoryAttribute("General"), DescriptionAttribute("")]
        public bool Unsigned
        {
            get { return _Unsigned; }
            set { _Unsigned = value; }
        }

        private bool _Autoincrement = false;
        [CategoryAttribute("General"), DescriptionAttribute("")]
        public bool Autoincrement
        {
            get { return _Autoincrement; }
            set { _Autoincrement = value; }
        }

        private bool _Zerofill = false;
        [CategoryAttribute("General"), DescriptionAttribute("")]
        public bool Zerofill
        {
            get { return _Zerofill; }
            set { _Zerofill = value; }
        }

        private string _Decimal = "(18,2)";
        [CategoryAttribute("General"), DescriptionAttribute("")]
        public string Decimal
        {
            get { return _Decimal; }
            set { _Decimal = value; }
        } 
    }
}
