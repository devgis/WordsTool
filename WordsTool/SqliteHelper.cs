using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WordsTool
{
    public class SqliteHelper
    {
        private static string sqliteConString = string.Empty;
        static SqliteHelper()
        {
            sqliteConString = "";
            string databaseFileName = Path.Combine(Application.StartupPath, "dict.db");
            sqliteConString = "data source = " + databaseFileName;
        }

        /// <summary>
        /// 查询返回DataTable
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">参数列表</param>
        /// <returns></returns>
        public static DataTable GetDataTable(string sql, SQLiteParameter[] parameters = null)
        {
            using (System.Data.SQLite.SQLiteConnection conn = new SQLiteConnection(sqliteConString))
            {
                try
                {
                    DataTable dt = new DataTable();
                    SQLiteCommand sqliteCmd = new SQLiteCommand();
                    sqliteCmd.CommandText = sql;
                    if (parameters != null && parameters.Length > 0)
                    {
                        sqliteCmd.Parameters.AddRange(parameters);
                    }
                    sqliteCmd.Connection = conn;
                    SQLiteDataAdapter da = new SQLiteDataAdapter(sqliteCmd);
                    da.Fill(dt);
                    return dt;

                }
                catch (Exception ex)
                {
                    return null;
                }
            }

        }
    }
}
