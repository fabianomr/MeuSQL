using System;
using System.Windows.Forms;
using System.ComponentModel;
namespace MeuSQL.Class
{
    

    public partial class clsBase : WeifenLuo.WinFormsUI.Docking.DockContent
    {

        public clsMySQL objDb = new clsMySQL();    

        public static Int16 intQuery = 0;

        public void LoadPropertyGrid(PropertyGrid Pg, string DataType)
        {
            try
            {
                Object objDataType = new Object();

                switch (DataType.ToUpper())
                {
                    case "BIGINT":
                        objDataType = new Class.DataTypes.clsBigInt();
                        break;
                    case "BINARY":
                        objDataType = new Class.DataTypes.clsBinary();
                        break;
                    case "BIT":
                        objDataType = new Class.DataTypes.clsBit();
                        break;
                    case "BLOB":
                        objDataType = new Class.DataTypes.clsBlob();
                        break;
                    case "BOOL":
                        objDataType = new Class.DataTypes.clsBool();
                        break;
                    case "CHAR":
                        objDataType = new Class.DataTypes.clsChar();
                        break;
                    case "DATE":
                        objDataType = new Class.DataTypes.clsDate();
                        break;
                    case "DATETIME":
                        objDataType = new Class.DataTypes.clsDateTime();
                        break;
                    case "DECIMAL":
                        objDataType = new Class.DataTypes.clsDecimal();
                        break;
                    case "DOUBLE":
                        objDataType = new Class.DataTypes.clsDouble();
                        break;
                    case "ENUM":
                        objDataType = new Class.DataTypes.clsEnum();
                        break;
                    case "FLOAT":
                        objDataType = new Class.DataTypes.clsFloat();
                        break;
                    case "INT":
                        objDataType = new Class.DataTypes.clsInt();
                        break;
                    case "LONGBLOB":
                        objDataType = new Class.DataTypes.clsLongBlob();
                        break;
                    case "LONGTEXT":
                        objDataType = new Class.DataTypes.clsLongText();
                        break;
                    case "MEDIUMBLOB":
                        objDataType = new Class.DataTypes.clsMediumBlob();
                        break;
                    case "MEDIUMINT":
                        objDataType = new Class.DataTypes.clsMediumInt();
                        break;
                    case "MEDIUMTEXT":
                        objDataType = new Class.DataTypes.clsMediumText();
                        break;
                    case "SET":
                        objDataType = new Class.DataTypes.clsSet();
                        break;
                    case "SMALLINT":
                        objDataType = new Class.DataTypes.clsSmallInt();
                        break;
                    case "TEXT":
                        objDataType = new Class.DataTypes.clsText();
                        break;
                    case "TIME":
                        objDataType = new Class.DataTypes.clsTime();
                        break;
                    case "TIMESTAMP":
                        objDataType = new Class.DataTypes.clsTimeStamp();
                        break;
                    case "TINYBLOB":
                        objDataType = new Class.DataTypes.clsTinyBlob();
                        break;
                    case "TINYINT":
                        objDataType = new Class.DataTypes.clsTinyInt();
                        break;
                    case "TINYTEXT":
                        objDataType = new Class.DataTypes.clsTinyText();
                        break;
                    case "VARBINARY":
                        objDataType = new Class.DataTypes.clsVarBinary();
                        break;
                    case "VARCHAR":
                        objDataType = new Class.DataTypes.clsVarChar();
                        break;
                    case "YEAR":
                        objDataType = new Class.DataTypes.clsYear();
                        break;
                    default:
                        break;
                }

                Pg.SelectedObject = objDataType;

            }
            catch (Exception ex)
            {
                
            }
        }

        public void SetPropertyGridValue(PropertyGrid ptg, string strPropriedade, object Value)
        {
            try
            {
                ptg.SelectedObject = ptg.SelectedObject;
                PropertyDescriptorCollection props = TypeDescriptor.GetProperties(ptg.SelectedObject);
                foreach (PropertyDescriptor prop in props)
                {
                    if (!prop.IsBrowsable) continue;
                    if (prop.Name.ToString() == strPropriedade)
                    {
                        prop.SetValue(ptg.SelectedObject, Value);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SetPropertyGridValue: " + ex.Message.ToString());
            }
        }


        public object GetPropertyGridValue(PropertyGrid ptg, string strPropriedade)
        {
            try
            {
                ptg.SelectedObject = ptg.SelectedObject;
                PropertyDescriptorCollection props = TypeDescriptor.GetProperties(ptg.SelectedObject);
                foreach (PropertyDescriptor prop in props)
                {
                    if (!prop.IsBrowsable) continue;

                    if (prop.ShouldSerializeValue(ptg.SelectedObject))
                    {
                        if (prop.Name.ToString() == strPropriedade)
                        {
                            return prop.GetValue(ptg.SelectedObject);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("GetPropertyGridValue: " + ex.Message.ToString());
            }
            return "";
        }

    }
}
