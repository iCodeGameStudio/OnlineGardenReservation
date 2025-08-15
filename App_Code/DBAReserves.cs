using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
public class DBAReserves
{
    public void addReserve(Int32 member_id,Int32 garden_id,String ser_type,String ser_eating,String other_ser,Int32 capacity,DateTime date)
    {
        SqlCommand cmd = new SqlCommand("Insert Into t_services_reservations (member_id,garden_id,ser_type,ser_eating,other_ser,capacity,date) Values (@member_id,@garden_id,@ser_type,@ser_eating,@other_ser,@capacity,@date)", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@member_id",member_id));
        cmd.Parameters.Add(new SqlParameter("@garden_id", garden_id));
        cmd.Parameters.Add(new SqlParameter("@ser_type", ser_type));
        cmd.Parameters.Add(new SqlParameter("@ser_eating", ser_eating));
        cmd.Parameters.Add(new SqlParameter("@other_ser", other_ser));
        cmd.Parameters.Add(new SqlParameter("@capacity", capacity));
        cmd.Parameters.Add(new SqlParameter("@date", date));
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
    }

    public DataTable getReserves(Int32 member_id)
    {
        SqlCommand cmd = new SqlCommand("SELECT t_services_reservations.id,t_gardens_detail.garden_name,t_gardens_detail.address,t_gardens_detail.type,t_services_reservations.ser_type,t_services_reservations.date,t_gardens_detail.tel FROM t_gardens_detail left outer Join t_services_reservations on t_services_reservations.garden_id = t_gardens_detail.garden_id where t_services_reservations.member_id = @member_id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@member_id", member_id));
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public void removeReserve(Int32 id)
    {
        SqlCommand cmd = new SqlCommand("Delete from t_services_reservations where id=@id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@id", id));
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
    }
}