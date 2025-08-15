using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;

public class DBAPaymentsZarinPal
{
    private static readonly String callbackUrl = UTLStatic.paymentZarinPalCallbackUrl;
    private static readonly String getwayUrl = UTLStatic.paymentZarinPalGetwayUrl;
    public DBAPaymentsZarinPal()
    {
    }
    public String getMerchentCode()
    {
        SqlCommand cmd = new SqlCommand("select merchant_code from t_payment_port", DBConnection.connection);
        cmd.Connection.Open();
        String merchant_code = cmd.ExecuteScalar().ToString();
        cmd.Connection.Close();
        return merchant_code;
    }
    private String getIP()
    {
        return System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
    }

    //---------------------------------------------------------------------------------------------------------------------------------------------------------------------

    public String payment(String garden_id, String reference_id, Int32 cost, String comment, Int32 period)
    {
        DBAGardens dba = new DBAGardens();
        DataTable dt = new DataTable();
        dt = dba.getGardenInfoForPayment(garden_id);
        String name = dt.Rows[0]["name"].ToString();
        String family = dt.Rows[0]["family"].ToString();
        String mobile = dt.Rows[0]["mobile"].ToString();
        String email = dt.Rows[0]["email"].ToString();
        SqlCommand cmd = new SqlCommand("insert into t_payments_zarin_pal (garden_id, reference_id, cost, date, authority, ref_id, status, ip, comment,period) values (@garden_id, @reference_id, @cost, @date, @authority, @ref_id, @status, @ip, @comment, @period); select scope_identity();", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@garden_id", Convert.ToInt32(garden_id)));
        cmd.Parameters.Add(new SqlParameter("@reference_id", Convert.ToInt32(reference_id)));
        cmd.Parameters.Add(new SqlParameter("@cost", cost));
        cmd.Parameters.Add(new SqlParameter("@date", DateTime.Now));
        cmd.Parameters.Add(new SqlParameter("@authority", ""));
        cmd.Parameters.Add(new SqlParameter("@ref_id", ""));
        cmd.Parameters.Add(new SqlParameter("@status", "فاکتور صادر شد"));
        cmd.Parameters.Add(new SqlParameter("@ip", getIP()));
        cmd.Parameters.Add(new SqlParameter("@comment", comment));
        cmd.Parameters.Add(new SqlParameter("@period", period));
        cmd.Connection.Open();
        String id = (cmd.ExecuteScalar()).ToString();
        cmd.Connection.Close();
        System.Net.ServicePointManager.Expect100Continue = false;
        String authority;
        com.zarinpal.www.PaymentGatewayImplementationService zp = new com.zarinpal.www.PaymentGatewayImplementationService();
        String merchantCode = getMerchentCode();
        Int32 status = zp.PaymentRequest(merchantCode, (Convert.ToInt32(cost)), comment, email, mobile, callbackUrl + id, out authority);
        if ((status == 100) && (authority.Length == 36))
        {
            updateAuthority(id, authority);
            updateCondition(id, "کاربر به درگاه بانک متصل شد");
            HttpContext.Current.Response.Redirect(getwayUrl + authority);
        }
        String error = getError(status);
        updateCondition(id, error);
        return error;
    }

    //---------------------------------------------------------------------------------------------------------------------------------------------------------------------

    public DataTable callback(String id, String authority)
    {
        if (id == getId(authority))
        {
            Int32 cost = Convert.ToInt32(getCost(id));
            Int64 refId;
            String merchantCode = getMerchentCode();
            System.Net.ServicePointManager.Expect100Continue = false;
            com.zarinpal.www.PaymentGatewayImplementationService zp = new com.zarinpal.www.PaymentGatewayImplementationService();
            Int32 status = zp.PaymentVerification(merchantCode, authority, cost, out refId);
            if (status == 100)
            {
                updateRefId(id, refId.ToString());
                updateCondition(id, getError(status));
            }
            else
            {
                updateRefId(id, "");
                updateCondition(id, getError(status));
            }
        }
        return getResult(id, authority);
    }

    //---------------------------------------------------------------------------------------------------------------------------------------------------------------------

    private void updateCondition(String id, String status)
    {
        SqlCommand cmd = new SqlCommand("update t_payments_zarin_pal set status = @status where id = @id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@status", status));
        cmd.Parameters.Add(new SqlParameter("@id", Convert.ToInt32(id)));
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
    }
    private void updateAuthority(String id, String authority)
    {
        SqlCommand cmd = new SqlCommand("update t_payments_zarin_pal set authority = @authority where id = @id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@authority", authority));
        cmd.Parameters.Add(new SqlParameter("@id", Convert.ToInt32(id)));
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
    }
    private void updateRefId(String id, String refId)
    {
        SqlCommand cmd = new SqlCommand("update t_payments_zarin_pal set ref_id = @ref_id where id = @id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@ref_id", refId));
        cmd.Parameters.Add(new SqlParameter("@id", Convert.ToInt32(id)));
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
    }
    private String getId(String authority)
    {
        SqlCommand cmd = new SqlCommand("select id from t_payments_zarin_pal where authority = @authority", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@authority", authority));
        cmd.Connection.Open();
        Object rv = cmd.ExecuteScalar();
        cmd.Connection.Close();
        return (rv == null ? "" : rv.ToString());
    }
    private String getCost(String id)
    {
        SqlCommand cmd = new SqlCommand("select cost from t_payments_zarin_pal where id = @id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@id", Convert.ToInt32(id)));
        cmd.Connection.Open();
        Object rv = cmd.ExecuteScalar();
        cmd.Connection.Close();
        return rv.ToString();
    }
    public String getPeriod(String id)
    {
        SqlCommand cmd = new SqlCommand("select period from t_payments_zarin_pal where id = @id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@id", Convert.ToInt32(id)));
        cmd.Connection.Open();
        Object rv = cmd.ExecuteScalar();
        cmd.Connection.Close();
        return rv.ToString();
    }


    public DataTable getResult(String id, String authority)
    {
        SqlCommand cmd = new SqlCommand("select * from t_payments_zarin_pal where id = @id and authority = @authority", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@id", Convert.ToInt32(id)));
        cmd.Parameters.Add(new SqlParameter("@authority", authority));
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable getPaymentInfo(String id)
    {
        SqlCommand cmd = new SqlCommand("select * from t_payments_zarin_pal where id = @id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@id", Convert.ToInt32(id)));
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable getPayments()
    {
        SqlCommand cmd = new SqlCommand("Select t_payments_zarin_pal.id,garden_id,cost,period,reference_id,ref_id,date,status,name,family,melicode From t_payments_zarin_pal left outer join (select t_gardens.id,t_gardens.name,t_gardens.family,t_gardens.melicode from t_gardens)t_gardens on t_payments_zarin_pal.garden_id = t_gardens.id where ref_id <> ''", DBConnection.connection);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable getPayments(Int32 garden_id)
    {
        SqlCommand cmd = new SqlCommand("Select t_payments_zarin_pal.id,garden_id,cost,period,reference_id,ref_id,date,status,name,family,melicode From t_payments_zarin_pal left outer join (select t_gardens.id,t_gardens.name,t_gardens.family,t_gardens.melicode from t_gardens)t_gardens on t_payments_zarin_pal.garden_id = t_gardens.id where ref_id <> '' And garden_id = @garden_id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@garden_id", garden_id));
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    //---------------------------------------------------------------------------------------------------------------------------------------------------------------------

    private static String getError(Int32 errorCode)
    {
        if (errorCode == -1)
            return "اطلاعات ارسال شده ناقص است";
        else if (errorCode == -2)
            return "آی پی و يا مرچنت كد پذيرنده صحيح نيست";
        else if (errorCode == -3)
            return "با توجه به محدوديت های شاپرک امكان پرداخت با رقم درخواست شده ميسر نمی باشد";
        else if (errorCode == -4)
            return "سطح تاييد پذيرنده پايين تر از سطح نقره ای است";
        else if (errorCode == -11)
            return "درخواست مورد نظر يافت نشد";
        else if (errorCode == -12)
            return "امكان ويرايش درخواست ميسر نمی باشد";
        else if (errorCode == -21)
            return "هيچ نوع عمليات مالی برای اين تراكنش يافت نشد";
        else if (errorCode == -22)
            return "تراكنش نا موفق می باشد";
        else if (errorCode == -33)
            return "رقم تراكنش با رقم پرداخت شده مطابقت ندارد";
        else if (errorCode == -34)
            return "سقف تقسيم تراكنش از لحاظ تعداد يا رقم عبور نموده است";
        else if (errorCode == -40)
            return "اجازه دسترسی به متد مربوطه وجود ندارد";
        else if (errorCode == -41)
            return "اطلاعات ارسال شده غير معتبر می باشد";
        else if (errorCode == -42)
            return "مدت زمان اعتبار طول عمر شناسه پرداخت بين 30 دقيه تا 45 روز می باشد";
        else if (errorCode == -54)
            return "درخواست مورد نظر آرشيو شده است";
        else if (errorCode == 100)
            return "تراکنش با موفقیت انجام شد";
        else if (errorCode == 101)
            return "عمليات پرداخت موفق بوده و قبلا تایید تراكنش انجام شده است";
        return "Error #" + errorCode;
    }

    public DataTable getSomeInfo(String invoice_id)
    {
        SqlCommand cmd = new SqlCommand("select ip, ref_id, t_agents.name as agent from t_payments_zarin_pal left outer join t_agents on t_payments_zarin_pal.agent_id = t_agents.id where reference_id = @invoice_id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@invoice_id", invoice_id));
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public void editPaymentPort(Int32 id, String name,String merchant_code)
    {
        SqlCommand cmd = new SqlCommand("update t_payment_port set name = @name , merchant_code = @merchant_code where id = @id", DBConnection.connection);
        cmd.Parameters.Add(new SqlParameter("@id", id));
        cmd.Parameters.Add(new SqlParameter("@name", name));       
        cmd.Parameters.Add(new SqlParameter("@merchant_code", merchant_code));
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
    }
    public DataTable getPaymentPort()
    {
        SqlCommand cmd = new SqlCommand("select id,name,merchant_code from t_payment_port", DBConnection.connection);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
}