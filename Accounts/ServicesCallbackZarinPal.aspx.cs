using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Globalization;

public partial class Accounts_ServicesCallbackZarinPal : System.Web.UI.Page
{
    private void setPageTree()
    {
        ((HtmlGenericControl)Page.Master.FindControl("treepage")).InnerHtml = "<li><a href='AccountHome'><i class='fa fa-dashboard'></i>خانه</a></li>   <li class='active'>نتیجه عملیات پرداخت</li>";
    }

    private void checkLogin()
    {
        if (Session["garden_id"] == null || Session["garden_id"].ToString() == "")
        {
            Response.Redirect("~/");
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        checkLogin();
        setPageTree();
        String title = "نتیجه عملیات پرداخت";
        Page.Title = title + " | " + UTLStatic.title;
        ((HtmlGenericControl)Page.Master.FindControl("htitle")).InnerText = title;

        String paymentId = "";
        String status = "";
        String authority = "";
        try
        {
            paymentId = Request.QueryString["PaymentId"].ToString();
            status = Request.QueryString["Status"].ToString();
            authority = Request.QueryString["Authority"].ToString();
        }
        catch
        {
            paymentId = "";
            status = "";
            authority = "";
        }
        if ((paymentId != "") && (status != "") && (authority != ""))
        {
            if (status == "OK")
            {
                DBAPaymentsZarinPal dba = new DBAPaymentsZarinPal();
                DataTable dt = dba.callback(paymentId, authority);
                //DataTable dt = dba.getResult(paymentId, authority); // for test
                if (dt.Rows.Count == 1)
                {
                    String id = dt.Rows[0]["id"].ToString();
                    String garden_id = dt.Rows[0]["garden_id"].ToString();
                    String reference_id = dt.Rows[0]["reference_id"].ToString();
                    String cost = dt.Rows[0]["cost"].ToString();
                    String comment = dt.Rows[0]["comment"].ToString();
                    String date = dt.Rows[0]["date"].ToString();
                    String ref_id = dt.Rows[0]["ref_id"].ToString();
                    String status2 = dt.Rows[0]["status"].ToString();
                    String ip = dt.Rows[0]["ip"].ToString();
                    String period = dba.getPeriod(id);
                    if ((status2 == "تراکنش با موفقیت انجام شد") && (ref_id != ""))
                    {
                        txtfactnumber.Text = ToFarsi(reference_id);
                        cost = cost + " تومان";
                        txtcost.Text = ToFarsi(cost);
                        txtservice.Text = "سرویس " + ToFarsi(period) + " ماهه";
                        txtdatetime.Text = ToFarsi(miladiToShamsi(date));
                        txtref.Text = ToFarsi(ref_id);
                        txtstatus.Text = status2;
                        txtipaddress.Text = ToFarsi(ip);
                        PlaceHolder1.Visible = true;
                        Int32 day = Convert.ToInt32(period) * 31;
                        DBAServices dbaservice = new DBAServices();
                        dbaservice.setServices(Convert.ToInt32(garden_id), DateTime.Today.ToLongDateString(), DateTime.Today.AddDays(day).ToLongDateString());
                        DBAGardens dbagarden = new DBAGardens();
                        dbagarden.setActCount(Convert.ToInt32(garden_id));
                    }
                    else
                    {
                        divmessage.InnerHtml = "تراکنش مورد نظر نا معتبر است.";
                    }
                }
                else
                {
                    divmessage.InnerHtml = "تراکنش مورد نظر نا معتبر است.";
                }
            }
            else
            {
                divmessage.InnerHtml = "تراکنش مورد نظر نا معتبر است.";
            }
        }
        else
        {
            divmessage.InnerHtml = "تراکنش مورد نظر نا معتبر است.";
        }
    }

    public String miladiToShamsi(Object miladi)
    {
        DateTime miladi_date = Convert.ToDateTime(miladi.ToString());
        DateTime time = Convert.ToDateTime(miladi.ToString());
        PersianCalendar shamsi = new PersianCalendar();
        String day = "";
        String mounth = "";
        String year = "";
        String mounth_name = "";
        day = shamsi.GetDayOfMonth(miladi_date).ToString();
        mounth = shamsi.GetMonth(miladi_date).ToString();
        mounth_name = mounthName(mounth);
        year = shamsi.GetYear(miladi_date).ToString();
        String persiandate = day + " " + mounth_name + " " + year + " | " + "ساعت: " + time.TimeOfDay.ToString();
        return persiandate;
    }

    private String mounthName(String mounth)
    {
        String result = "";
        switch (mounth)
        {
            case "1":
                result = "فروردین";
                break;
            case "2":
                result = "اردیبهشت";
                break;
            case "3":
                result = "خرداد";
                break;
            case "4":
                result = "تیر";
                break;
            case "5":
                result = "مرداد";
                break;
            case "6":
                result = "شهریور";
                break;
            case "7":
                result = "مهر";
                break;
            case "8":
                result = "آبان";
                break;
            case "9":
                result = "آذر";
                break;
            case "10":
                result = "دی";
                break;
            case "11":
                result = "بهمن";
                break;
            case "12":
                result = "اسفند";
                break;
        }
        return result;
    }

    public String ToFarsi(String number)
    {
        UTLNumbers num = new UTLNumbers();
        return num.ToPersianNumber(number);
    }

}