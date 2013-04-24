using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace MeuSQL.Class.DataTypes
{
    [DefaultPropertyAttribute("General")]
    class clsDouble
    {
        private string _Lenght = "";
        [CategoryAttribute("General"), DescriptionAttribute("")]
        public string Lenght
        {
            get { return _Lenght; }
            set { _Lenght = value; }
        }

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

        private int _Decimals = 0;
        [CategoryAttribute("General"), DescriptionAttribute("")]
        public int Decimals
        {
            get { return _Decimals; }
            set { _Decimals = value; }
        } 
    }
}
