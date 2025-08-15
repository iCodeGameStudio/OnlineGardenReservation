using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Net;
using System.Globalization;
using System.Web.UI.HtmlControls;
public partial class Accounts_ServicesReport : System.Web.UI.Page
{
    private void setPageTree()
    {
        ((HtmlGenericControl)Page.Master.FindControl("treepage")).InnerHtml = "<li><a href='AccountHome'><i class='fa fa-dashboard'></i>خانه</a></li>   <li class='active'>گزارشگیری</li>";
    }

    private void setTitle()
    {
        ((HtmlGenericControl)Page.Master.FindControl("htitle")).InnerHtml = "گزارش گیری" + "<small>گزارش گیری از سرویس هایی که ثبت کرده اید</small>";
    }
    private void setActivateItemMenu()
    {
        ((HtmlGenericControl)Page.Master.FindControl("report")).Attributes["class"] = "active";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        setTitle();
        setActivateItemMenu();
        checkLogin();
        setServicesResport();

    }

    private void checkLogin()
    {
        if (Session["garden_id"] == null || Session["garden_id"].ToString() == "")
        {
            Response.Redirect("~/");
        }
    }

    private void setServicesResport()
    {
        DBAServices dba = new DBAServices();
        GridView1.DataSource = dba.servicesReport(Convert.ToInt32(Session["garden_id"]));
        GridView1.DataBind();
    }

    ////public override void VerifyRenderingInServerForm(Control control)
    ////{
    ////    /*Verifies that the control is rendered */
    ////}

    public String miladiToShamsi(Object miladi)
    {
        DateTime miladi_date = Convert.ToDateTime(miladi);
        DateTime time = Convert.ToDateTime(miladi.ToString());
        PersianCalendar shamsi = new PersianCalendar();
        String day = "";
        String mounth = "";
        String year = "";
        String mounth_name = "";
        String dayof_week = "";
        String day_name = "";
        day = shamsi.GetDayOfMonth(miladi_date).ToString();
        mounth = shamsi.GetMonth(miladi_date).ToString();
        dayof_week = shamsi.GetDayOfWeek(miladi_date).ToString();
        mounth_name = mounthName(mounth);
        day_name = dayName(dayof_week);
        year = shamsi.GetYear(miladi_date).ToString();
        String persiandate = day_name + " " + day + " " + mounth_name + " " + year;
        return persiandate;
    }
    private String dayName(String dayname)
    {
        String result = "";
        switch (dayname)
        {
            case "Saturday":
                result = "شنبه";
                break;
            case "Sunday":
                result = "یکشنبه";
                break;
            case "Monday":
                result = "دوشنبه";
                break;
            case "Tuesday":
                result = "سه شنبه";
                break;
            case "Wednesday":
                result = "چهارشنبه";
                break;
            case "Thursday":
                result = "پنجشنبه";
                break;
            case "Friday":
                result = "جمعه";
                break;
        }
        return result;
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