using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using MySql.Data.MySqlClient;

namespace MeuSQL.Class
{
    public class clsMySQL
    {

        public MySqlConnection MyConnection = new MySqlConnection();
        public static string strConnection ="";
        public static bool blnConnected = false;
        public static string strServer = "";


        public void OpenConnection(string strDataBase = "")
        {
            try
            {
                MyConnection = new MySqlConnection(strConnection + (!string.IsNullOrEmpty(strDataBase) ? ";database=" + strDataBase : ""));
                MyConnection.Open();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public bool TestConnection(string strDataBase = "")
        {
            try
            {
                OpenConnection(strDataBase);
                if ((MyConnection.State == ConnectionState.Open))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public DataTable GetDataTable(string strQuery, string strDataBase = "")
        {
            try
            {
                OpenConnection(strDataBase);
                DataTable objdt = new DataTable();
                MySqlDataAdapter objDataAdapter = new MySqlDataAdapter(strQuery, MyConnection);
                objDataAdapter.Fill(objdt);
                objDataAdapter.Dispose();
                return objdt;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection();
            }
        }

        public DataSet GetDataSet(string strQuery, string strDataBase = "")
        {
            try
            {
                OpenConnection(strDataBase);
                DataSet objDataSet = new DataSet();
                MySqlDataAdapter objDataAdapter = new MySqlDataAdapter(strQuery, MyConnection);
                objDataAdapter.Fill(objDataSet);

                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection();
            }
        }

        public object GetValue(string strSQL, string strDataBase = "")
        {
            DataTable Dt = new DataTable();

            try
            {
                Dt = GetDataTable(strSQL, strDataBase);
                if ((Dt.Rows.Count > 0))
                {
                    return Dt.Rows[0][0];
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                Dt.Dispose();
            }
        }

        //public bool Execute(string strSQL, string strDataBase = "", ref int IntQrdRegistrosAfetados = 0)
        public bool Execute(string strSQL, string strDataBase = "")
        {
            try
            {
                OpenConnection(strDataBase);
                MySqlCommand comando = new MySqlCommand(strSQL, MyConnection);
                comando.ExecuteNonQuery();
                //IntQrdRegistrosAfetados = comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection();
            }
            return true;
        }

        public bool Execute(string strSQL, string strDataBase = "", int IntQrdRegistrosAfetado = 0)
        {
            try
            {
                OpenConnection(strDataBase);
                MySqlCommand comando = new MySqlCommand(strSQL, MyConnection);
                comando.ExecuteNonQuery();
                //IntQrdRegistrosAfetados = comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection();
            }
            return true;
        }

        public bool CloseConnection()
        {
            try
            {
                if ((MyConnection.State == ConnectionState.Open))
                {
                    MyConnection.Close();
                    MyConnection.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return true;
        }

        public string GetLadtColumnName(string DataBase, string TableName)
        {
            string CollumnName = "";
            try
            {
                DataTable Dt = new DataTable();
                Dt = GetDataTable("show columns from " + TableName, DataBase);

                if (Dt.Rows.Count > 0)
                {
                    CollumnName = Dt.Rows[Dt.Rows.Count - 1]["Field"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return CollumnName;
        }

        public string GetKeys(string DataBase, string TableName,string strIgnoredName)
        {
            string strKeys = "";
            try
            {
                DataTable Dt = new DataTable();
                Dt = GetDataTable("show columns from " + TableName, DataBase);

                if (Dt.Rows.Count > 0)
                {
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        if (Dt.Rows[i]["KEY"].ToString() != "")
                        {
                            if (Dt.Rows[i]["Field"].ToString() != strIgnoredName)
                            {
                                strKeys += "`" + Dt.Rows[i]["Field"].ToString() + "`";
                                strKeys += ",";
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return strKeys;
        }

        public string GetScriptTable(string DataBase, string Table){
            string strQuery = "";
            try
            {
                 DataTable Dt = new DataTable();                        

                Dt = GetDataTable(" SHOW CREATE TABLE " + Table + "", DataBase);

                if (Dt.Rows.Count > 0)
                {
                    strQuery += "DELIMITER $$ " + Environment.NewLine;
                    strQuery += "" + Environment.NewLine;
                    strQuery += "DROP TABLE IF EXISTS `" + Table + "` $$ " + Environment.NewLine;
                    strQuery += "" + Environment.NewLine;
                    strQuery += Dt.Rows[0]["Create Table"];

                    strQuery += " $$ " + Environment.NewLine;
                    strQuery += "" + Environment.NewLine;
                    strQuery += "DELIMITER ; ";
                }             
            }
            catch (Exception ex)
            {                
                throw (ex);
            }
            return strQuery;
        }

        public string GetScriptNewProcedure(string DataBase)
        {
            string strQuery = "";
            try
            {
                strQuery += "DELIMITER $$" + Environment.NewLine;
                strQuery += "" + Environment.NewLine;
                strQuery += "DROP PROCEDURE IF EXISTS `ProcedureName` $$" + Environment.NewLine;
                strQuery += "CREATE DEFINER=`" + DataBase + "`@`%.%.%.%` PROCEDURE `ProcedureName`(IN _Par1 INT, IN _Par2 INT)" + Environment.NewLine;
                strQuery += "BEGIN" + Environment.NewLine;
                strQuery += "" + Environment.NewLine;
                strQuery += "    SELECT * FROM TableName; " + Environment.NewLine;
                strQuery += "" + Environment.NewLine;
                strQuery += "   END $$" + Environment.NewLine;
                strQuery += "DELIMITER ;" + Environment.NewLine;
                strQuery += "" + Environment.NewLine;
            }
            catch (Exception ex)
            {                
                throw (ex);
            }
            return strQuery;
        }

        public string GetScriptNewFunction(string DataBase)
        {
            string strQuery = "";
            try
            {
                strQuery += "DELIMITER $$" + Environment.NewLine;
                strQuery += "" + Environment.NewLine;
                strQuery += "DROP FUNCTION IF EXISTS `FunctionName` $$" + Environment.NewLine;
                strQuery += "" + Environment.NewLine;
                strQuery += "CREATE DEFINER=`" + DataBase + "`@`%.%.%.%` FUNCTION `FunctionName`(n1 INT, n2 INT) RETURNS int(11)" + Environment.NewLine;
                strQuery += "    DETERMINISTIC" + Environment.NewLine;
                strQuery += "BEGIN" + Environment.NewLine;
                strQuery += "" + Environment.NewLine;
                strQuery += "     DECLARE avg INT;" + Environment.NewLine;
                strQuery += "" + Environment.NewLine;
                strQuery += "     SET avg = (n1+n2);" + Environment.NewLine;
                strQuery += "" + Environment.NewLine;
                strQuery += "     RETURN avg;" + Environment.NewLine;
                strQuery += "" + Environment.NewLine;
                strQuery += "    END $$" + Environment.NewLine;
                strQuery += "" + Environment.NewLine;
                strQuery += "DELIMITER ;" + Environment.NewLine;
            }
            catch (Exception ex)
            {                
                throw(ex);
            }
            return strQuery;
        }

        public string GetScriptNewTrigger(string DataBase)
        {
            string strQuery = "";
            try
            {
                strQuery += "DELIMITER $$" + Environment.NewLine;
                strQuery += "" + Environment.NewLine;
                strQuery += "DROP TRIGGER IF EXISTS `TriggernName` $$" + Environment.NewLine;
                strQuery += "" + Environment.NewLine;
                strQuery += "CREATE DEFINER=`" + DataBase + "`@`%.%.%.%` TRIGGER `TriggernName` AFTER/BEFORE INSERT/UPDATE/DELETE ON `TableName`" + Environment.NewLine;
                strQuery += "    FOR EACH ROW " + Environment.NewLine;
                strQuery += "        BEGIN" + Environment.NewLine;
                strQuery += "" + Environment.NewLine;
                strQuery += "             -- YOUR QUERY;" + Environment.NewLine;
                strQuery += "" + Environment.NewLine;
                strQuery += "    END $$" + Environment.NewLine;
                strQuery += "" + Environment.NewLine;
                strQuery += "DELIMITER ;" + Environment.NewLine;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return strQuery;
        }

        public string GetScriptNewView(string DataBase)
        {
            string strQuery = "";
            try
            {
                
                strQuery += "" + Environment.NewLine;
                strQuery += "" + Environment.NewLine;
                strQuery += "CREATE VIEW ViewName AS SELECT * FROM TableName;" + Environment.NewLine;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return strQuery;
        }

        public string GetScriptTrigger(string DataBase, string Trigger)
        {
            string strQuery = "";
            try
            {
                DataTable Dt = new DataTable();

                Dt = GetDataTable(" SHOW CREATE Trigger " + Trigger + "", DataBase);

                if (Dt.Rows.Count > 0)
                {
                    strQuery += "DELIMITER $$ " + Environment.NewLine;
                    strQuery += "" + Environment.NewLine;
                    strQuery += "DROP TRIGGER IF EXISTS `" + Trigger + "` $$ " + Environment.NewLine;
                    strQuery += "" + Environment.NewLine;
                    strQuery += Dt.Rows[0]["SQL Original Statement"];

                    strQuery += " $$ " + Environment.NewLine;
                    strQuery += "" + Environment.NewLine;
                    strQuery += "DELIMITER ; ";
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return strQuery;
        }

        public string GetScriptProcedure(string DataBase, string Procedure)
        {
            string strQuery = "";
            try
            {
                DataTable Dt = new DataTable();

                Dt = GetDataTable(" SHOW CREATE PROCEDURE " + Procedure + "", DataBase);

                if (Dt.Rows.Count > 0)
                {
                    strQuery += "DELIMITER $$ " + Environment.NewLine;
                    strQuery += "" + Environment.NewLine;
                    strQuery += "DROP PROCEDURE IF EXISTS `" + Procedure + "` $$ " + Environment.NewLine;
                    strQuery += "" + Environment.NewLine;
                    strQuery += Dt.Rows[0]["Create Procedure"];

                    strQuery += " $$ " + Environment.NewLine;
                    strQuery += "" + Environment.NewLine;
                    strQuery += "DELIMITER ; ";
                }

            }
            catch (Exception ex)
            {                
                throw(ex);
            }
            return strQuery;       
        }

        public string GetScriptFunction(string DataBase, string Function)
        {
            string strQuery = "";
            try
            {
                DataTable Dt = new DataTable();

                Dt = GetDataTable(" SHOW CREATE FUNCTION " + Function + "", DataBase);

                if (Dt.Rows.Count > 0)
                {
                    strQuery += "DELIMITER $$ " + Environment.NewLine;
                    strQuery += "" + Environment.NewLine;
                    strQuery += "DROP FUNCTION IF EXISTS `" + Function + "` $$ " + Environment.NewLine;
                    strQuery += "" + Environment.NewLine;
                    strQuery += Dt.Rows[0]["Create Function"];

                    strQuery += " $$ " + Environment.NewLine;
                    strQuery += "" + Environment.NewLine;
                    strQuery += "DELIMITER ; ";
                }
            }
            catch (Exception ex)
            {                
                throw(ex);
            }
            return strQuery;   
        }

        public string GetScriptView(string DataBase, string View)
        {
            string strQuery = "";
            try
            {
                DataTable Dt = new DataTable();

                Dt = GetDataTable(" SHOW CREATE VIEW " + View + "", DataBase);

                if (Dt.Rows.Count > 0)
                {
                    strQuery += "DELIMITER $$ " + Environment.NewLine;
                    strQuery += "" + Environment.NewLine;
                    strQuery += "DROP VIEW IF EXISTS `" + View + "` $$ " + Environment.NewLine;
                    strQuery += "" + Environment.NewLine;
                    strQuery += Dt.Rows[0]["Create View"];

                    strQuery += " $$ " + Environment.NewLine;
                    strQuery += "" + Environment.NewLine;
                    strQuery += "DELIMITER ; ";
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return strQuery;
        }
        public bool DropDataBase(string DataBase)
        {
            try
            {
                Execute(" DROP DATABASE IF EXISTS `" + DataBase + "` ", DataBase);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return true;
        }

        public bool DropTable(string DataBase, string Table)
        {
            try
            {
                Execute(" DROP TABLE IF EXISTS `" + Table + "` ", DataBase);
            }
            catch (Exception ex)
            {                
                throw(ex);
            }
            return true;
        }

        public bool DropTrigger(string DataBase, string Trigger)
        {
            try
            {
                Execute(" DROP TRIGGER IF EXISTS `" + Trigger + "` ", DataBase);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return true;
        }

        public bool DropProcedure(string DataBase, string Procedure)
        {
            try
            {
                Execute(" DROP PROCEDURE IF EXISTS `" + Procedure + "` ", DataBase);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return true;
        }

        public bool DropFunction(string DataBase, string Procedure)
        {
            try
            {
                Execute(" DROP FUNCTION IF EXISTS `" + Procedure + "` ", DataBase);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return true;
        }

        public bool DropView(string DataBase, string View)
        {
            try
            {
                Execute(" DROP VIEW IF EXISTS `" + View + "` ", DataBase);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return true;
        }

        public bool AddNewUser(string User, string Password, string DataBase)
        {
            try
            {
                string strQuery = "";
                strQuery += "CREATE USER '" + User + "'@'localhost' IDENTIFIED BY '" + Password + "';";
                strQuery += "GRANT ALL PRIVILEGES ON *.* TO '" + User + "'@'localhost' WITH GRANT OPTION;";
                if (Execute(strQuery, DataBase))
                {
                    return true;
                }
            }
            catch (Exception ex)
            {                
                throw(ex);
            }
            return false;
        }

        public bool ChangePassword(string User, string Password, string DataBase)
        {
            try
            {
                string strQuery = "";
                strQuery += "SET PASSWORD FOR "+ User + " = PASSWORD('"+ Password +"');";
                
                if (Execute(strQuery, DataBase))
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return false;
        }

        public bool RenameTable(string DataBase, string orig_name, string new_name)
        {
            try
            {
                string strQuery = "";
                strQuery += "ALTER TABLE "+ orig_name +" RENAME "+ new_name +";";
                
                if (Execute(strQuery, DataBase))
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return false;
        }

        public string GetVersion(string DataBase)
        {
            try
            {
                return GetValue("SELECT VERSION() AS Version", DataBase).ToString();
            }
            catch (Exception ex)
            {                
                throw (ex);
            }
        }
    }

}
