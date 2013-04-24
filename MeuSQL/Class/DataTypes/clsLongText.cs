using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace MeuSQL.Class.DataTypes
{
    [DefaultPropertyAttribute("General")]
    class clsLongText
    {
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

        private bool _Binary = false;
        [CategoryAttribute("General"), DescriptionAttribute("")]
        public bool Binary
        {
            get { return _Binary; }
            set { _Binary = value; }
        }
    }
}
