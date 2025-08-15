using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.IO;
public class DBAGardens
{
    public DBAGardens()
    {
    }
    //========================================hash function==============================================

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
    //=====================================================================================================
    public String addGarden(String name, String family, String melicode, String mobile, String email, String province, String city)
    {
        SqlCommand cmd = new SqlCommand("Select id From t_gardens Where melicode = @melicode OR email = @email", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@melicode", melicode));
        cmd.Parameters.Add(new SqlParameter("@email", email));
        cmd.Connection.Open();
        Object val = cmd.ExecuteScalar();
        cmd.Connection.Close();
        if (val == null)
        {
            cmd = new SqlCommand("Insert Into t_gardens (name, family, melicode, mobile, email, username, password, active, province, city, visit, act_count) Values (@name, @family, @melicode, @mobile, @email, @username, @password, @active, @province, @city, @visit, @act_count)", DBConnection.connection);
            cmd.Parameters.Add(new SqlParameter("@name", name));
            cmd.Parameters.Add(new SqlParameter("@family", family));
            cmd.Parameters.Add(new SqlParameter("@melicode", melicode));
            cmd.Parameters.Add(new SqlParameter("@mobile", mobile));
            cmd.Parameters.Add(new SqlParameter("@email", email));
            cmd.Parameters.Add(new SqlParameter("@province", province));
            cmd.Parameters.Add(new SqlParameter("@city", city));
            cmd.Parameters.Add(new SqlParameter("@visit", Convert.ToInt32("0")));
            cmd.Parameters.Add(new SqlParameter("@username", email));
            cmd.Parameters.Add(new SqlParameter("@password", GetHashStringMD5(GetHashStringSHA512(melicode))));
            cmd.Parameters.Add(new SqlParameter("@active", Convert.ToInt32("0")));
            cmd.Parameters.Add(new SqlParameter("@act_count", Convert.ToInt32("0")));
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

    public void setActCount(Int32 id)
    {
        SqlCommand cmd = new SqlCommand("update t_gardens set act_count = act_count + 1 where id = @id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@id", id));
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
    }

    public String loginCheck(String username, String password)
    {
        SqlCommand cmd = new SqlCommand("Select id From t_gardens Where username = @username AND password = @password", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@username", username));
        cmd.Parameters.Add(new SqlParameter("@password", GetHashStringMD5(GetHashStringSHA512(password))));
        cmd.Connection.Open();
        Object val = cmd.ExecuteScalar();
        cmd.Connection.Close();
        return val == null ? "NotExist" : val.ToString();
    }

    public String activeCheck(Int32 id)
    {
        SqlCommand cmd = new SqlCommand("Select active From t_gardens Where id=@id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@id", id));
        cmd.Connection.Open();
        Object val = cmd.ExecuteScalar();
        cmd.Connection.Close();
        if (val.ToString() == "0")
        {
            return "not accept";
        }
        else if (val.ToString() == "2")
        {
            return "failed";
        }
        else if (val.ToString() == "3")
        {
            return "taligh";
        }
        else
        {
            return val.ToString();
        }
    }

    //public DataTable getMembers()
    //{
    //    SqlCommand cmd = new SqlCommand("Select id,name,family,melicode,mobile,email,file_name,signup_date,email,username,active From t_members", DBConnection.connection);
    //    //cmd.Parameters.Add(new SqlParameter("@text", "%" + text + "%"));
    //    SqlDataAdapter da = new SqlDataAdapter(cmd);
    //    DataTable dt = new DataTable();
    //    da.Fill(dt);
    //    return dt;
    //}

    public DataTable getGardensRequest()
    {
        SqlCommand cmd = new SqlCommand("Select id, name, family, melicode , mobile , email , file_name, active, city, province from t_gardens where active IN(0, 2, 3)", DBConnection.connection);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable getGardenInfoForPayment(String id)
    {
        SqlCommand cmd = new SqlCommand("Select name,family,mobile,email From t_gardens Where id=@id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@id", Int32.Parse(id)));
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public void editGarden(Int32 id, String name, String family, String melicode, String mobile, String email, String province, String city)
    {
        SqlCommand cmd = new SqlCommand("Update t_gardens set name=@name , family=@family , melicode=@melicode , mobile=@mobile , email=@email , province=@province , city=@city , username=@username , password=@password where id = @id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@id", id));
        cmd.Parameters.Add(new SqlParameter("@name", name));
        cmd.Parameters.Add(new SqlParameter("@family", family));
        cmd.Parameters.Add(new SqlParameter("@melicode", melicode));
        cmd.Parameters.Add(new SqlParameter("@mobile", mobile));
        cmd.Parameters.Add(new SqlParameter("@email", email));
        cmd.Parameters.Add(new SqlParameter("@province", province));
        cmd.Parameters.Add(new SqlParameter("@city", city));
        cmd.Parameters.Add(new SqlParameter("@username", email));
        cmd.Parameters.Add(new SqlParameter("@password", GetHashStringMD5(GetHashStringSHA512(melicode))));
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
    }

    public void removeGarden(Int32 id)
    {
        SqlCommand cmd = new SqlCommand("Delete from t_gardens where id=@id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@id", id));
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
    }


    public DataTable getGardens(String text)
    {
        SqlCommand cmd = new SqlCommand("Select id, name, family, melicode , mobile , city, province, act_count, email, start_date_act, end_date_act from t_gardens where active = 1 AND (family like @text OR melicode like @text)", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@text", "%" + text + "%"));
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable getGardenInfo(String garden_id)
    {
        SqlCommand cmd = new SqlCommand("Select id,t_gardens_detail.garden_id,garden_name,tel,capacity,type,address,possibilities, file_name From t_gardens_detail left outer join (select t_gardens_image.garden_id, file_name from t_gardens_image )t_gardens_image on t_gardens_detail.garden_id = t_gardens_image.garden_id where t_gardens_detail.garden_id = @garden_id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@garden_id", garden_id));
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public void activeChange(Int32 id, Int32 active)
    {
        SqlCommand cmd = new SqlCommand("Update t_gardens set active = @active where id = @id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@active", active));
        cmd.Parameters.Add(new SqlParameter("@id", id));
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
    }

    public DataTable getGardenInfo(Int32 id)
    {
        SqlCommand cmd = new SqlCommand("Select id,name,family,melicode,mobile,email,active,province,city,file_name,start_date_act,end_date_act,act_count From t_gardens Where id=@id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@id", id));
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable getGardenDetailsInfo(Int32 garden_id)
    {
        SqlCommand cmd = new SqlCommand("Select id,garden_name,tel,capacity,type,address,possibilities From t_gardens_detail Where garden_id=@garden_id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@garden_id", garden_id));
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public String changePassword(Int32 id, String old_password, String new_password)
    {
        SqlCommand cmd = new SqlCommand("Select id From t_gardens Where id=@id and password=@password", DBConnection.connection);
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
            cmd = new SqlCommand("Update t_gardens set password=@password where id=@id", DBConnection.connection);
            cmd.Parameters.Add(new SqlParameter("@password", GetHashStringMD5(GetHashStringSHA512(new_password))));
            cmd.Parameters.Add(new SqlParameter("@id", id));
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return "Successfuly";
        }
    }

    public String entityInformation(Int32 garden_id)
    {
        SqlCommand cmd = new SqlCommand("Select id From t_gardens_detail Where garden_id=@garden_id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@garden_id", garden_id));
        cmd.Connection.Open();
        object val = cmd.ExecuteScalar();
        cmd.Connection.Close();
        if (val == null)
        {
            return "NotExist";
        }
        else
        {
            return "Exist";
        }
    }

    public void changeInformation(Int32 garden_id, String garden_name, String tel, String capacity, String type, String address, String possibilities)
    {
        SqlCommand cmd = new SqlCommand("Select id From t_gardens_detail Where garden_id=@garden_id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@garden_id", garden_id));
        cmd.Connection.Open();
        object val = cmd.ExecuteScalar();
        cmd.Connection.Close();
        if (val == null)
        {
            cmd = new SqlCommand("Insert Into t_gardens_detail(garden_id,garden_name,tel,capacity,type,address,possibilities)Values(@garden_id,@garden_name,@tel,@capacity,@type,@address,@possibilities)", DBConnection.connection);
            cmd.Parameters.Add(new SqlParameter("@garden_id", garden_id));
            cmd.Parameters.Add(new SqlParameter("@garden_name", garden_name));
            cmd.Parameters.Add(new SqlParameter("@tel", tel));
            cmd.Parameters.Add(new SqlParameter("@capacity", capacity));
            cmd.Parameters.Add(new SqlParameter("@type", type));
            cmd.Parameters.Add(new SqlParameter("@address", address));
            cmd.Parameters.Add(new SqlParameter("@possibilities", possibilities));
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
        else
        {
            cmd = new SqlCommand("Update t_gardens_detail set garden_name=@garden_name , tel=@tel , capacity=@capacity , type=@type , address=@address , possibilities=@possibilities where garden_id=@garden_id", DBConnection.connection);
            cmd.Parameters.Add(new SqlParameter("@garden_id", garden_id));
            cmd.Parameters.Add(new SqlParameter("@garden_name", garden_name));
            cmd.Parameters.Add(new SqlParameter("@tel", tel));
            cmd.Parameters.Add(new SqlParameter("@capacity", capacity));
            cmd.Parameters.Add(new SqlParameter("@type", type));
            cmd.Parameters.Add(new SqlParameter("@address", address));
            cmd.Parameters.Add(new SqlParameter("@possibilities", possibilities));
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
    }

    //==================================================Forget and Reset Password============================================================================

    public String emailCheckGarden(String email)
    {
        SqlCommand cmd = new SqlCommand("Select id From t_gardens Where email=@email", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@email", email));
        cmd.Connection.Open();
        Object val = cmd.ExecuteScalar();
        cmd.Connection.Close();
        return val == null ? "NotExist" : val.ToString();
    }

    public Int32 emailCheck(String email)
    {
        SqlCommand cmd = new SqlCommand("Select id From t_gardens_reset_password Where email=@email ; select scope_identity()", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@email", email));
        cmd.Connection.Open();
        Int32 id = Convert.ToInt32(cmd.ExecuteScalar());
        cmd.Connection.Close();
        return id;
    }

    public void setForget(Int32 garden_id, String email, String guid)
    {
        Int32 id = emailCheck(email);
        if (id == 0)
        {
            SqlCommand cmd = new SqlCommand("Insert Into t_gardens_reset_password (garden_id,email, guid) Values (@garden_id,@email, @guid)", DBConnection.connection);
            cmd.Parameters.Add(new SqlParameter("@garden_id", garden_id));
            cmd.Parameters.Add(new SqlParameter("@email", email));
            cmd.Parameters.Add(new SqlParameter("@guid", guid));
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
        else
        {
            SqlCommand cmd = new SqlCommand("Update t_gardens_reset_password set garden_id=@garden_id,email=@email,guid=@guid where id=@id", DBConnection.connection);
            cmd.Parameters.Add(new SqlParameter("@garden_id", garden_id));
            cmd.Parameters.Add(new SqlParameter("@email", email));
            cmd.Parameters.Add(new SqlParameter("@id", id));
            cmd.Parameters.Add(new SqlParameter("@guid", guid));
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
    }

    public String resetCheck(Int32 garden_id, String email, String guid)
    {
        SqlCommand cmd = new SqlCommand("Select * From t_gardens_reset_password Where garden_id=@garden_id AND email=@email AND guid=@guid", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@email", email));
        cmd.Parameters.Add(new SqlParameter("@guid", guid));
        cmd.Parameters.Add(new SqlParameter("@garden_id", garden_id));
        cmd.Connection.Open();
        Object val = cmd.ExecuteScalar();
        cmd.Connection.Close();
        return val == null ? "NotExist" : val.ToString();
    }

    public void resetPassword(Int32 id, String password)
    {
        SqlCommand cmd = new SqlCommand("Update t_gardens set password=@password where id=@id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@password", GetHashStringMD5(GetHashStringSHA512(password))));
        cmd.Parameters.Add(new SqlParameter("@id", id));
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
    }

    //=================================================================================================
    public DataTable getProvince()
    {
        SqlCommand cmd = new SqlCommand("Select id,name from t_province", DBConnection.connection);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable getCity(Int32 province_id)
    {
        SqlCommand cmd = new SqlCommand("Select id,name,province_id from t_city where province_id = @province_id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@province_id", province_id));
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    //=================================================================================================================================
    public String checkStockImages(Int32 garden_id)
    {
        SqlCommand cmd = new SqlCommand("Select COUNT(id) From t_gardens_image Where garden_id=@garden_id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@garden_id", garden_id));
        cmd.Connection.Open();
        Object val = cmd.ExecuteScalar().ToString();
        cmd.Connection.Close();
        return Convert.ToInt32(val) >= 10 ? "Error" : val.ToString();
    }


    public void uploadImage(Int32 garden_id, String file_name)
    {
        SqlCommand cmd = new SqlCommand("update t_gardens_Image set cover=@cover where garden_id = @garden_id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@garden_id", garden_id));
        cmd.Parameters.Add(new SqlParameter("@cover", false));
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
        cmd = new SqlCommand("Insert Into t_gardens_Image (garden_id,file_name,cover) Values (@garden_id,@file_name,@cover)", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@garden_id", garden_id));
        cmd.Parameters.Add(new SqlParameter("@file_name", file_name));
        cmd.Parameters.Add(new SqlParameter("@cover", true));
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
    }

    public DataTable getImagesGardens(Int32 garden_id)
    {
        SqlCommand cmd = new SqlCommand("Select id , file_name , cover From t_gardens_Image where garden_id = @garden_id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@garden_id", garden_id));
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public void deleteGardensImages(Int32 id)
    {
        SqlCommand cmd = new SqlCommand("Select file_name from t_gardens_Image where id=@id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@id", id));
        cmd.Connection.Open();
        String filepath = cmd.ExecuteScalar().ToString();
        cmd.Connection.Close();
        if ((File.Exists(HttpContext.Current.Server.MapPath("~/Images/Uploads/Gardens/" + filepath))))
        {
            File.Delete(HttpContext.Current.Server.MapPath("~/Images/Uploads/Gardens/" + filepath));
        }

        cmd = new SqlCommand("Delete from t_gardens_Image where id=@id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@id", id));
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
    }

    public void setCover(Int32 garden_id, Int32 id, Boolean cover)
    {
        SqlCommand cmd = new SqlCommand("update t_gardens_Image set cover=@cover where garden_id = @garden_id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@garden_id", garden_id));
        cmd.Parameters.Add(new SqlParameter("@id", id));
        cmd.Parameters.Add(new SqlParameter("@cover", false));
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
        cmd = new SqlCommand("update t_gardens_Image set cover=@cover where id = @id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@id", id));
        cmd.Parameters.Add(new SqlParameter("@cover", cover));
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
    }
    //======================================================================================================================

    public DataTable getGardens()
    {
        SqlCommand cmd = new SqlCommand("Select t_gardens_detail.garden_id,garden_name,tel,capacity,type,address, file_name From t_gardens_detail left outer join (select t_gardens_image.garden_id, file_name from t_gardens_image where cover = @cover)garden_images on t_gardens_detail.garden_id = garden_images.garden_id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@cover", true));
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable getGardensForType(String type)
    {
        SqlCommand cmd = new SqlCommand("Select t_gardens_detail.garden_id,garden_name,tel,capacity,type,address, file_name From t_gardens_detail left outer join (select t_gardens_image.garden_id, file_name from t_gardens_image where cover = @cover)garden_images on t_gardens_detail.garden_id = garden_images.garden_id where t_gardens_detail.type = @type", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@cover", true));
        cmd.Parameters.Add(new SqlParameter("@type", type));
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    //===========================================================log=============================================================

    public void setLog(Int32 garden_id, DateTime login_date, String login_time, String guid_code)
    {
        SqlCommand cmd = new SqlCommand("Insert Into t_gardens_logs (garden_id,login_date,login_time,ip,guid_code) Values (@garden_id,@login_date,@login_time,@ip,@guid_code)", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@garden_id", garden_id));
        cmd.Parameters.Add(new SqlParameter("@login_date", login_date));
        cmd.Parameters.Add(new SqlParameter("@login_time", login_time));
        String ip = HttpContext.Current.Request.Params["HTTP_CLIENT_IP"] ?? HttpContext.Current.Request.UserHostAddress;
        cmd.Parameters.Add(new SqlParameter("@ip", ip));
        cmd.Parameters.Add(new SqlParameter("@guid_code", guid_code));
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
    }

    public void setLogoutLog(String guid_code, String logout_time)
    {
        SqlCommand cmd = new SqlCommand("UPDATE t_gardens_logs set logout_time=@logout_time where guid_code = @guid_code", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@guid_code", guid_code));
        cmd.Parameters.Add(new SqlParameter("@logout_time", logout_time));
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
    }

    public DataTable getGardenLogs(Int32 garden_id)
    {
        SqlCommand cmd = new SqlCommand("Select id,login_date,login_time,logout_time,ip from t_gardens_logs where garden_id = @garden_id ORDER BY login_date DESC", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@garden_id", garden_id));
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    //========================================================================================================================

    public DataTable getDateAct(Int32 id)
    {
        SqlCommand cmd = new SqlCommand("Select start_date_act,end_date_act from t_gardens where id = @id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@id", id));
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable getCity()
    {
        SqlCommand cmd = new SqlCommand("Select DISTINCT city from t_gardens where active = 1", DBConnection.connection);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable getCity(String city_name)
    {
        SqlCommand cmd = new SqlCommand("Select DISTINCT city from t_gardens where active = 1 AND city like @city_name", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@city_name", "%" + city_name + "%"));
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable getFilterGardens(String command_city, String command_type, String command_ser, String command_date)
    {
        SqlCommand cmd = new SqlCommand("SELECT distinct t_gardens.id,t_services_dfd_final.id as sid,t_gardens_detail.type,t_gardens_detail.garden_name,ser_type,t_gardens_image.file_name,t_services_dfd_final.capacity FROM t_gardens left outer Join (select t_gardens_image.garden_id, t_gardens_image.file_name from t_gardens_image where cover = @cover)t_gardens_image on t_gardens.id = t_gardens_image.garden_id left outer Join t_gardens_detail on t_gardens.id = t_gardens_detail.garden_id left outer Join (select id, ser_type, garden_id,capacity,date from t_services_dfd_final)t_services_dfd_final on t_services_dfd_final.garden_id = t_gardens_detail.garden_id where " + command_city + command_type + command_ser + command_date, DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@cover", true));
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
}