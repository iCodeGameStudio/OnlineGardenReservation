using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
public class DBAUsers
{
    public DBAUsers()
    {
    }

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

    public String loginCheck(String username, String password)
    {
        SqlCommand cmd = new SqlCommand("SELECT id FROM t_users WHERE username = @username AND password = @password", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@username", username));
        cmd.Parameters.Add(new SqlParameter("@password", GetHashStringMD5(GetHashStringSHA512(password))));
        cmd.Connection.Open();
        Object val = cmd.ExecuteScalar();
        cmd.Connection.Close();
        return val == null ? "NotExist" : val.ToString();
    }

    public DataTable getUserInfo(Int32 id)
    {
        SqlCommand cmd = new SqlCommand("Select id,name,family,melicode,mobile,email,access,file_name,login_count,last_login From t_users Where id=@id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@id", id));
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public String changePassword(Int32 id, String old_password, String new_password)
    {
        SqlCommand cmd = new SqlCommand("Select password From t_users Where id=@id and password=@password", DBConnection.connection);
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
            cmd = new SqlCommand("Update t_users set password=@password where id=@id", DBConnection.connection);
            cmd.Parameters.Add(new SqlParameter("@password", GetHashStringMD5(GetHashStringSHA512(new_password))));
            cmd.Parameters.Add(new SqlParameter("@id", id));
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return "Successfuly";
        }
    }

    public DataTable getUsers(Int32 id)
    {
        SqlCommand cmd = new SqlCommand("Select id,name,family,melicode,mobile,email,access,file_name,login_count,last_login,availability From t_users where id <> @id AND access <> @access", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@id", id));
        cmd.Parameters.Add(new SqlParameter("@access", 3));
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public void removeUsers(Int32 id)
    {
        SqlCommand cmd = new SqlCommand("Delete from t_users where id=@id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@id", id));
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
    }

    public void changeLastAndCountLogin(Int32 id)
    {
            DataTable dt = new DataTable();
            dt = getUserInfo(id);
            if(dt.Rows.Count == 1)
            {
                Int32 login_count = Convert.ToInt32(dt.Rows[0]["login_count"]);
                login_count += 1;
                SqlCommand cmd = new SqlCommand("Update t_users set login_count = @login_count , last_login = @last_login where id = @id", DBConnection.connection);
                cmd.Parameters.Add(new SqlParameter("@id", id));
                cmd.Parameters.Add(new SqlParameter("@login_count", login_count));
                cmd.Parameters.Add(new SqlParameter("@last_login", DateTime.Now));
                cmd.Connection.Open();
                Int32 order_id = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Connection.Close();
            }         
            
    }


    public String addUser(String name, String family, String melicode, String mobile, String email, Int32 access)
    {
        SqlCommand cmd = new SqlCommand("Select id From t_users Where melicode = @melicode OR email = @email", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@melicode", melicode));
        cmd.Parameters.Add(new SqlParameter("@email", email));
        cmd.Connection.Open();
        Object val = cmd.ExecuteScalar();
        cmd.Connection.Close();
        if (val == null)
        {
            cmd = new SqlCommand("Insert Into t_users (name, family, melicode, mobile, email, username, password, access, login_count, availability) Values (@name, @family, @melicode, @mobile, @email, @username, @password, @access, @login_count, @availability)", DBConnection.connection);
            cmd.Parameters.Add(new SqlParameter("@name", name));
            cmd.Parameters.Add(new SqlParameter("@family", family));
            cmd.Parameters.Add(new SqlParameter("@melicode", melicode));
            cmd.Parameters.Add(new SqlParameter("@mobile", mobile));
            cmd.Parameters.Add(new SqlParameter("@email", email));
            cmd.Parameters.Add(new SqlParameter("@login_count", Convert.ToInt32("0")));
            cmd.Parameters.Add(new SqlParameter("@username", email));
            cmd.Parameters.Add(new SqlParameter("@password", GetHashStringMD5(GetHashStringSHA512(melicode))));
            cmd.Parameters.Add(new SqlParameter("@access", access));
            cmd.Parameters.Add(new SqlParameter("@availability", true));
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return "successfuly";
        }
        else
        {
            return "account is exist";
        }
    }

    public void editUser(Int32 id, String name, String family, String melicode, String mobile, String email)
    {
        SqlCommand cmd = new SqlCommand("Update t_users set name=@name , family=@family , melicode=@melicode , mobile=@mobile , email=@email , username=@username , password=@password where id = @id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@id", id));
        cmd.Parameters.Add(new SqlParameter("@name", name));
        cmd.Parameters.Add(new SqlParameter("@family", family));
        cmd.Parameters.Add(new SqlParameter("@melicode", melicode));
        cmd.Parameters.Add(new SqlParameter("@mobile", mobile));
        cmd.Parameters.Add(new SqlParameter("@email", email));
        cmd.Parameters.Add(new SqlParameter("@username", email));
        cmd.Parameters.Add(new SqlParameter("@password", GetHashStringMD5(GetHashStringSHA512(melicode))));
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
    }

    public void blockAndUnblockUser(Int32 id, String command)
    {
        if(command == "Block")
        {
            SqlCommand cmd = new SqlCommand("Update t_users set availability = @availability where id = @id", DBConnection.connection);
            cmd.Parameters.Add(new SqlParameter("@id", id));
            cmd.Parameters.Add(new SqlParameter("@availability", false));
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
        else if(command == "UnBlock")
        {
            SqlCommand cmd = new SqlCommand("Update t_users set availability = @availability where id = @id", DBConnection.connection);
            cmd.Parameters.Add(new SqlParameter("@id", id));
            cmd.Parameters.Add(new SqlParameter("@availability", true));
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
        
    }

    public String checkAvailability(Int32 id)
    {
        SqlCommand cmd = new SqlCommand("select availability from t_users where id = @id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@id", id));
        cmd.Connection.Open();
        Boolean val = Convert.ToBoolean(cmd.ExecuteScalar());
        cmd.Connection.Close();
        return val == true ? "unblock" : "block";
    }

    //==================================================Forget and Reset Password============================================================================

    public String emailCheckUser(String email)
    {
        SqlCommand cmd = new SqlCommand("Select id From t_users Where email=@email", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@email", email));
        cmd.Connection.Open();
        Object val = cmd.ExecuteScalar();
        cmd.Connection.Close();
        return val == null ? "NotExist" : val.ToString();
    }

    public Int32 emailCheck(String email)
    {
        SqlCommand cmd = new SqlCommand("Select id From t_users_reset_password Where email=@email ; select scope_identity()", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@email", email));
        cmd.Connection.Open();
        Int32 id = Convert.ToInt32(cmd.ExecuteScalar());
        cmd.Connection.Close();
        return id;
    }

    public void setForget(Int32 user_id, String email, String guid)
    {
        Int32 id = emailCheck(email);
        if (id == 0)
        {
            SqlCommand cmd = new SqlCommand("Insert Into t_users_reset_password (user_id,email, guid) Values (@user_id,@email, @guid)", DBConnection.connection);
            cmd.Parameters.Add(new SqlParameter("@user_id", user_id));
            cmd.Parameters.Add(new SqlParameter("@email", email));
            cmd.Parameters.Add(new SqlParameter("@guid", guid));
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
        else
        {
            SqlCommand cmd = new SqlCommand("Update t_users_reset_password set user_id=@user_id,email=@email,guid=@guid where id=@id", DBConnection.connection);
            cmd.Parameters.Add(new SqlParameter("@user_id", user_id));
            cmd.Parameters.Add(new SqlParameter("@email", email));
            cmd.Parameters.Add(new SqlParameter("@id", id));
            cmd.Parameters.Add(new SqlParameter("@guid", guid));
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
    }

    public String resetCheck(Int32 user_id, String email, String guid)
    {
        SqlCommand cmd = new SqlCommand("Select * From t_users_reset_password Where user_id=@user_id AND email=@email AND guid=@guid", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@email", email));
        cmd.Parameters.Add(new SqlParameter("@guid", guid));
        cmd.Parameters.Add(new SqlParameter("@user_id", user_id));
        cmd.Connection.Open();
        Object val = cmd.ExecuteScalar();
        cmd.Connection.Close();
        return val == null ? "NotExist" : val.ToString();
    }

    public void resetPassword(Int32 id, String password)
    {
        SqlCommand cmd = new SqlCommand("Update t_users set password=@password where id=@id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@password", GetHashStringMD5(GetHashStringSHA512(password))));
        cmd.Parameters.Add(new SqlParameter("@id", id));
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
    }

    //=================================================================================================
}