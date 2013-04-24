using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace MeuSQL.Class.DataTypes
{
    [DefaultPropertyAttribute("General")]
    class clsBlob
    {
        private string _Lenght = "";
        [CategoryAttribute("General"), DescriptionAttribute("")]
        public string Lenght
        {
            get { return _Lenght; }
            set { _Lenght = value; }
        }

        private string _CharacterSet = "Default";
        [Browsable(true)]
        [DefaultValue("Default")]
        [CategoryAttribute("General"), DescriptionAttribute("")]
        [TypeConverter(typeof(clsAuxiliaryCheracterSet))]
        public string CharacterSet
        {
            get { return _CharacterSet; }
            set { _CharacterSet = value; }
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
    }
}
