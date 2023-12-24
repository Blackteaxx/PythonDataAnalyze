using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.Services.DataBase
{
    internal class Sql
    {
        private static string connectionString =
            "Server = localhost; " +
            "Database = web; " +
            "uid = IS; pwd = 5151; " +
            "TrustServerCertificate=true;";
        
        /// <summary>
        /// 执行sql,返回reader
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string sql,Dictionary<string,object?> paras)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(sql, connection);
            foreach (var key in paras.Keys)
            {
                command.Parameters.AddWithValue(key, paras[key]);
            }
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }
        
        public static int ExecuteNonQuery(string sql,Dictionary<string,object?> paras)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(sql, connection);
            SqlTransaction tran = connection.BeginTransaction();
            command.Transaction = tran;
            foreach (var key in paras.Keys)
            {
                command.Parameters.AddWithValue(key, paras[key]);
            }
            try
            {
                var r = command.ExecuteNonQuery();
                tran.Commit();
                return r;
            }
            catch (Exception e)
            {
                tran.Rollback();
                return -1;
            }
        }
        
        public static object? ExecuteScalar(string sql,Dictionary<string,object?> paras)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(sql, connection);
            foreach (var key in paras.Keys)
            {
                command.Parameters.AddWithValue(key, paras[key]);
            }
            return command.ExecuteScalar();
        }
    }
}
