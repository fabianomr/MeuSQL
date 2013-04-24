using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace MeuSQL.Class.DataTypes
{
    class clsAuxiliaryCollation : StringConverter
    {
        public static string strCharset = "Default";
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            //true means show a combobox
            return true;
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            //true will limit to list. false will show the list, but allow free-form  entry
            return true;
        }

        public override System.ComponentModel.TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {

            clsMySQL objDb = new clsMySQL();

            DataTable Dt = new DataTable();

            Dt = objDb.GetDataTable("show collation like '%" + strCharset + "%'", "");
            
            string[] names = new string[Dt.Rows.Count];
            
            for (int i = 0; i < Dt.Rows.Count - 1; i++)
            {
                names[i] = Dt.Rows[i]["Collation"].ToString();
            }

            return new StandardValuesCollection(names);
        }
    }
}
