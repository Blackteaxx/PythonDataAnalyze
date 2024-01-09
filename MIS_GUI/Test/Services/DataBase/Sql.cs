using Microsoft.Data.SqlClient;

namespace IS.Services.DataBase;

internal class Sql
{
    private static readonly string connectionString =
        "Server = 101.43.94.40,5000; " +
        "Database = web; " +
        "uid = web; pwd = 202!@#QWEasd; " +
        "TrustServerCertificate=true;";

    /// <summary>
    ///     执行sql,返回reader
    /// </summary>
    /// <param name="sql"></param>
    /// <param name="paras"></param>
    /// <returns></returns>
    public static SqlDataReader ExecuteReader(string sql, Dictionary<string, object?> paras)
    {
        var connection = new SqlConnection(connectionString);
        connection.Open();
        var command = new SqlCommand(sql, connection);
        foreach (var key in paras.Keys) command.Parameters.AddWithValue(key, paras[key]);
        var reader = command.ExecuteReader();
        return reader;
    }

    public static int ExecuteNonQuery(string sql, Dictionary<string, object?> paras)
    {
        var connection = new SqlConnection(connectionString);
        connection.Open();
        var command = new SqlCommand(sql, connection);
        var tran = connection.BeginTransaction();
        command.Transaction = tran;
        foreach (var key in paras.Keys) command.Parameters.AddWithValue(key, paras[key]);
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

    public static object? ExecuteScalar(string sql, Dictionary<string, object?> paras)
    {
        var connection = new SqlConnection(connectionString);
        connection.Open();
        var command = new SqlCommand(sql, connection);
        foreach (var key in paras.Keys) command.Parameters.AddWithValue(key, paras[key]);
        return command.ExecuteScalar();
    }
}