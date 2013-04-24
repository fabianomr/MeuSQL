using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace MeuSQL.Class.DataTypes
{
    [DefaultPropertyAttribute("General")]
    class clsEnum
    {
        private string _Characterset = "Default";
        [Browsable(true)]
        [DefaultValue("Default")]
        [CategoryAttribute("General"), DescriptionAttribute("")]
        [TypeConverter(typeof(clsAuxiliaryCheracterSet))]
        public string Characterset
        {
            get { return _Characterset; }
            set { _Characterset = value; }
        }

        private string _Collation = "Default";
        [Browsable(true)]
        [DefaultValue("Default")]
        [CategoryAttribute("General"), DescriptionAttribute("")]
        [TypeConverter(typeof(clsAuxiliaryCollation))]
        public string Collation
        {
            get { return _Collation; }
            set { _Collation = value; }
        }

        private string _Values = "";
        [CategoryAttribute("General"), DescriptionAttribute("")]
        public string Values
        {
            get { return _Values; }
            set { _Values = value; }
        }
    }
}
