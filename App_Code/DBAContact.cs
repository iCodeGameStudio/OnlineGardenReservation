using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

public class DBAContact
{
	public DBAContact()
	{
	}

    public void contactUS(String name, String email,String subject, String message)
    {
        SqlCommand cmd = new SqlCommand("Insert Into t_contactus (name, email,subject, message, date, seen) Values (@name, @email,@subject, @message, @date, 0)", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@name", name));
        cmd.Parameters.Add(new SqlParameter("@email", email));
        cmd.Parameters.Add(new SqlParameter("@subject", subject));
        cmd.Parameters.Add(new SqlParameter("@message", message));
        cmd.Parameters.Add(new SqlParameter("@date", DateTime.Now));
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
    }

    public void removeMessage(Int32 id)
    {
        SqlCommand cmd = new SqlCommand("Delete from t_contactus where id = @id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@id", id));
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
    }

    public String getCountNewMessage()
    {
        SqlCommand cmd = new SqlCommand("select count(id) from t_contactus where seen = 0", DBConnection.connection);
        cmd.Connection.Open();
        Object count = cmd.ExecuteScalar();
        cmd.Connection.Close();
        return count == null ? "NotExist" : count.ToString();
    }

    public DataTable getNewMessage()
    {
        SqlCommand cmd = new SqlCommand("Select * from t_contactus where seen = 0", DBConnection.connection);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable getContactUsInfo(String id)
    {
        SqlCommand cmd = new SqlCommand("Select * from t_contactus where id = @id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@id", id));
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable getContactUs()
    {
        SqlCommand cmd = new SqlCommand("Select * from t_contactus", DBConnection.connection);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public void setSeen(Int32 id)
    {
        SqlCommand cmd = new SqlCommand("UPDATE t_contactus set seen = 1 where id = @id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@id", id));
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
    }
}