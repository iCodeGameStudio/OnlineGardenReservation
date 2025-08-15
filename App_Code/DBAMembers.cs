using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.IO;
public class DBAMembers
{
    private static Byte[] GetHashMD5(String input)
    {
        HashAlgorithm algorithm = MD5.Create();
        return algorithm.ComputeHash(Encoding.UTF8.GetBytes(input));
    }
    private static Byte[] GetHashSHA512(String input)
    {
        HashAlgorithm algorithm = SHA512.Create();
        return algorithm.ComputeHash(Encoding.UTF8.GetBytes(input));
    }

    public static String GetHashStringMD5(String inputString)
    {
        StringBuilder sb = new StringBuilder();
        foreach (byte b in GetHashMD5(inputString))
            sb.Append(b.ToString("X2"));
        return sb.ToString();
    }

    public static String GetHashStringSHA512(String inputString)
    {
        StringBuilder sb = new StringBuilder();
        foreach (byte b in GetHashSHA512(inputString))
            sb.Append(b.ToString("X2"));
        return sb.ToString();
    }

    public String addMember(String name, String mobile, String password)
    {
        SqlCommand cmd = new SqlCommand("select id from t_members where mobile = @mobile", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@mobile", mobile));
        cmd.Connection.Open();
        Object val = cmd.ExecuteScalar();
        cmd.Connection.Close();
        if (val == null)
        {
            cmd = new SqlCommand("Insert into t_members (name,mobile,username,password) values (@name,@mobile,@username,@password)", DBConnection.connection);
            cmd.Parameters.Add(new SqlParameter("@name", name));
            cmd.Parameters.Add(new SqlParameter("@mobile", mobile));
            cmd.Parameters.Add(new SqlParameter("@username", mobile));
            cmd.Parameters.Add(new SqlParameter("@password", GetHashStringMD5(GetHashStringSHA512(password))));
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return "success";
        }
        else
        {
            return "isExist";
        }
    }

    public String loginCheck(String username, String password)
    {
        SqlCommand cmd = new SqlCommand("select id from t_members where username = @username AND password = @password", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@username", username));
        cmd.Parameters.Add(new SqlParameter("@password", GetHashStringMD5(GetHashStringSHA512(password))));
        cmd.Connection.Open();
        Object val = cmd.ExecuteScalar();
        cmd.Connection.Close();
        return val == null ? "notExist" : val.ToString();
    }

    public DataTable getMemberInfo(Int32 id)
    {
        SqlCommand cmd = new SqlCommand("Select name From t_members Where id=@id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@id", id));
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public String changePassword(Int32 id, String old_password, String new_password)
    {
        SqlCommand cmd = new SqlCommand("Select id From t_members Where id=@id and password=@password", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@id", id));
        cmd.Parameters.Add(new SqlParameter("@password", GetHashStringMD5(GetHashStringSHA512(old_password))));
        cmd.Connection.Open();
        object val = cmd.ExecuteScalar();
        cmd.Connection.Close();
        if (val == null)
        {
            return "NotExist";
        }
        else
        {
            cmd = new SqlCommand("Update t_members set password=@password where id=@id", DBConnection.connection);
            cmd.Parameters.Add(new SqlParameter("@password", GetHashStringMD5(GetHashStringSHA512(new_password))));
            cmd.Parameters.Add(new SqlParameter("@id", id));
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return "Successfuly";
        }
    }
}