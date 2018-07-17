using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace D3Download
{
    public class DataBaseHelper
    {
       static string connectStr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        public static DataTable ExecuterQuery(string commandSql)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlConnection oracleConnection =
                new SqlConnection(connectStr))
                {
                    oracleConnection.Open();

                    using (SqlDataAdapter oracleDataAdapter =
                    new SqlDataAdapter(commandSql, oracleConnection))
                    {
                        oracleDataAdapter.Fill(dataTable);
                    }

                    oracleConnection.Close();
                }
            }
            catch
            {
                return null;
            }

            return dataTable;
        }

        public static void Executer(string commandSql)
        {
            using (SqlConnection oracleConnection =
            new SqlConnection(connectStr))
            {
                oracleConnection.Open();

                using (SqlCommand oracleCommand =
                new SqlCommand(commandSql, oracleConnection))
                {
                    oracleCommand.ExecuteReader();
                }

                oracleConnection.Close();
            }
        }

        public static bool ExecuteNonQuery(string commandSql)
        {
            int count = 0;
            using (SqlConnection oracleConnection =
            new SqlConnection(connectStr))
            {
                oracleConnection.Open();

                using (SqlCommand oracleCommand =
                new SqlCommand(commandSql, oracleConnection))
                {
                    count = oracleCommand.ExecuteNonQuery();
                }

                oracleConnection.Close();
            }
            if (count > 0)
            {
                return true;
            }
            return false;
        }
    }  
}
