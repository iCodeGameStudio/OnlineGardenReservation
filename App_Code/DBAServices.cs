using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

public class DBAServices
{
    public DBAServices()
    {
    }

    public void setServices(Int32 id, String start_date_act, String end_date_act)
    {
        SqlCommand cmd = new SqlCommand("Update t_gardens set start_date_act = @start_date_act , end_date_act = @end_date_act where id = @id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@id", id));
        cmd.Parameters.Add(new SqlParameter("@start_date_act", start_date_act));
        cmd.Parameters.Add(new SqlParameter("@end_date_act", end_date_act));
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
    }


    public String addService(Int32 period, Int32 cost)
    {
        SqlCommand cmd = new SqlCommand("Select id From t_active_type_service where period = @period", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@period", period));
        cmd.Connection.Open();
        Object val = cmd.ExecuteScalar();
        cmd.Connection.Close();
        if (val == null)
        {
            cmd = new SqlCommand("Insert Into t_active_type_service (period,cost) Values (@period,@cost)", DBConnection.connection);
            cmd.Parameters.Add(new SqlParameter("@period", period));
            cmd.Parameters.Add(new SqlParameter("@cost", cost));
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return "success";
        }
        else
        {
            return "exist";
        }

    }

    public DataTable getServices()
    {
        SqlCommand cmd = new SqlCommand("Select * from t_active_type_service", DBConnection.connection);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable getServiceInfo(Int32 id)
    {
        SqlCommand cmd = new SqlCommand("Select * from t_active_type_service where id = @id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@id", id));
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public String getCost(Int32 id)
    {
        SqlCommand cmd = new SqlCommand("Select cost from t_active_type_service where id = @id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@id", id));
        cmd.Connection.Open();
        String val = cmd.ExecuteScalar().ToString();
        cmd.Connection.Close();
        return val;
    }

    public void removeService(Int32 id)
    {
        SqlCommand cmd = new SqlCommand("Delete from t_active_type_service where id = @id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@id", id));
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
    }

    //=============================================================================================================
    //**************************************************************************************************************
    public Int32 addServiceFactor(Int32 garden_id, Int32 service_id, Int32 cost, Int32 period)
    {
        SqlCommand cmd = new SqlCommand("Insert Into t_services_factors (garden_id,service_id,cost, period,date,status) Values (@garden_id,@service_id,@cost, @period,@date,@status); select scope_identity()", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@garden_id", garden_id));
        cmd.Parameters.Add(new SqlParameter("@service_id", service_id));
        cmd.Parameters.Add(new SqlParameter("@date", DateTime.Now));
        cmd.Parameters.Add(new SqlParameter("@cost", cost));
        cmd.Parameters.Add(new SqlParameter("@status", "فاکتور شما صادر شد"));
        cmd.Parameters.Add(new SqlParameter("@period", period));
        cmd.Connection.Open();
        Int32 factor_id = Convert.ToInt32(cmd.ExecuteScalar());
        cmd.Connection.Close();
        return factor_id;
    }

    //=========================================for gardens=========================================================

    public void addServiceDFDGardens(Int32 garden_id, String ser_type, Int32 capacity, String ser_eating, String other_ser, DateTime date)
    {
        SqlCommand cmd = new SqlCommand("Insert Into t_services_dfd (garden_id,ser_type,capacity, ser_eating,other_ser,date) Values (@garden_id,@ser_type,@capacity, @ser_eating,@other_ser,@date)", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@garden_id", garden_id));
        cmd.Parameters.Add(new SqlParameter("@ser_type", ser_type));
        cmd.Parameters.Add(new SqlParameter("@capacity", capacity));
        cmd.Parameters.Add(new SqlParameter("@ser_eating", ser_eating));
        cmd.Parameters.Add(new SqlParameter("@other_ser", other_ser));
        cmd.Parameters.Add(new SqlParameter("@date", date));
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
    }

    public String addServiceDFDFinal(Int32 garden_id, String ser_type, Int32 capacity, String ser_eating, String other_ser, DateTime date)
    {
        SqlCommand cmd = new SqlCommand("Select id From t_services_dfd_final where date = @date AND ser_type = @ser_type AND garden_id = @garden_id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@date", date));
        cmd.Parameters.Add(new SqlParameter("@ser_type", ser_type));
        cmd.Parameters.Add(new SqlParameter("@garden_id", garden_id));
        cmd.Connection.Open();
        Object val = cmd.ExecuteScalar();
        cmd.Connection.Close();
        if (val == null)
        {
            cmd = new SqlCommand("Insert Into t_services_dfd_final (garden_id,ser_type,capacity, ser_eating,other_ser,date) Values (@garden_id,@ser_type,@capacity, @ser_eating,@other_ser,@date)", DBConnection.connection);
            cmd.Parameters.Add(new SqlParameter("@garden_id", garden_id));
            cmd.Parameters.Add(new SqlParameter("@ser_type", ser_type));
            cmd.Parameters.Add(new SqlParameter("@capacity", capacity));
            cmd.Parameters.Add(new SqlParameter("@ser_eating", ser_eating));
            cmd.Parameters.Add(new SqlParameter("@other_ser", other_ser));
            cmd.Parameters.Add(new SqlParameter("@date", date));
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
    public DataTable getServicesDFD(Int32 garden_id)
    {
        SqlCommand cmd = new SqlCommand("Select * from t_services_dfd where garden_id = @garden_id order by date DESC", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@garden_id", garden_id));
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable getServiceDFDInfo(Int32 id)
    {
        SqlCommand cmd = new SqlCommand("Select ser_type,capacity,ser_eating,other_ser from t_services_dfd where id = @id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@id", id));
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public void removeServiceDFD(Int32 id)
    {
        SqlCommand cmd = new SqlCommand("Delete from t_services_dfd where id = @id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@id", id));
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
    }

    public DataTable getServiceTypeOfDays(DateTime date, Int32 garden_id)
    {
        SqlCommand cmd = new SqlCommand("Select ser_type,date From t_services_dfd_final where date = @date AND garden_id = @garden_id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@date", date));
        cmd.Parameters.Add(new SqlParameter("@garden_id", garden_id));
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable getServiceInfoDay(Int32 garden_id, DateTime date, String ser_type)
    {
        SqlCommand cmd = new SqlCommand("Select * From t_services_dfd_final where date = @date AND ser_type = @ser_type AND garden_id = @garden_id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@date", date));
        cmd.Parameters.Add(new SqlParameter("@ser_type", ser_type));
        cmd.Parameters.Add(new SqlParameter("@garden_id", garden_id));
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public String checkEntity(Int32 garden_id,DateTime date)
    {
        SqlCommand cmd = new SqlCommand("Select id From t_services_dfd_final where date = @date AND garden_id = @garden_id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@date", date));
        cmd.Parameters.Add(new SqlParameter("@garden_id", garden_id));
        cmd.Connection.Open();
        Object id = cmd.ExecuteScalar();
        cmd.Connection.Close();
        return id == null ? "notExist" : id.ToString();
    }

    private String checkEntity(Int32 garden_id, String ser_type, DateTime date)
    {
        SqlCommand cmd = new SqlCommand("Select id From t_services_dfd_final where date = @date AND ser_type = @ser_type AND garden_id = @garden_id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@date", date));
        cmd.Parameters.Add(new SqlParameter("@ser_type", ser_type));
        cmd.Parameters.Add(new SqlParameter("@garden_id", garden_id));
        cmd.Connection.Open();
        Object id = cmd.ExecuteScalar();
        cmd.Connection.Close();
        return id == null ? "notExist" : id.ToString();
    }
    public void editServiceDFDFinal(Int32 garden_id, String ser_type, Int32 capacity, String ser_eating, String other_ser, DateTime date)
    {
        String id = checkEntity(garden_id, ser_type, date);
        if (id == "notExist")
        {
            SqlCommand cmd = new SqlCommand("Insert Into t_services_dfd_final (garden_id,ser_type,capacity, ser_eating,other_ser,date) Values (@garden_id,@ser_type,@capacity, @ser_eating,@other_ser,@date)", DBConnection.connection);
            cmd.Parameters.Add(new SqlParameter("@garden_id", garden_id));
            cmd.Parameters.Add(new SqlParameter("@ser_type", ser_type));
            cmd.Parameters.Add(new SqlParameter("@capacity", capacity));
            cmd.Parameters.Add(new SqlParameter("@ser_eating", ser_eating));
            cmd.Parameters.Add(new SqlParameter("@other_ser", other_ser));
            cmd.Parameters.Add(new SqlParameter("@date", date));
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
        else
        {
            SqlCommand cmd = new SqlCommand("update t_services_dfd_final set garden_id=@garden_id , ser_type=@ser_type , capacity=@capacity , ser_eating=@ser_eating , other_ser=@other_ser , date=@date where id = @id", DBConnection.connection);
            cmd.Parameters.Add(new SqlParameter("@id", Convert.ToInt32(id)));
            cmd.Parameters.Add(new SqlParameter("@garden_id", garden_id));
            cmd.Parameters.Add(new SqlParameter("@ser_type", ser_type));
            cmd.Parameters.Add(new SqlParameter("@capacity", capacity));
            cmd.Parameters.Add(new SqlParameter("@ser_eating", ser_eating));
            cmd.Parameters.Add(new SqlParameter("@other_ser", other_ser));
            cmd.Parameters.Add(new SqlParameter("@date", date));
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
    }
    public void removeServiceDFDFinal(Int32 garden_id, String ser_type, DateTime date)
    {
        SqlCommand cmd = new SqlCommand("Delete from t_services_dfd_final where garden_id = @garden_id AND ser_type = @ser_type AND date = @date", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@garden_id", garden_id));
        cmd.Parameters.Add(new SqlParameter("@ser_type", ser_type));
        cmd.Parameters.Add(new SqlParameter("@date", date));
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
    }


    public DataTable servicesReport(Int32 garden_id)
    {
        SqlCommand cmd = new SqlCommand("Select * From t_services_dfd_final where garden_id = @garden_id order by date DESC", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@garden_id", garden_id));
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable getServiceDFDFinalInfo(Int32 id)
    {
        SqlCommand cmd = new SqlCommand("Select ser_type,capacity,ser_eating,other_ser,date from t_services_dfd_final where id = @id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@id", id));
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
}