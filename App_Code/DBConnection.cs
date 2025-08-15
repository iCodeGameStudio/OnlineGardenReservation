using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;

public class DBConnection
{
    public DBConnection()
    {
    }
    private static String getConnectionString
    {
        get { return UTLStatic.connectionString; }
    }
    public static SqlConnection connection
    {
        get { return new SqlConnection(getConnectionString); }
    }
}