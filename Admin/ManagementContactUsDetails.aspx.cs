using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.Data;
public partial class Admin_ManagementContactUsDetails : System.Web.UI.Page
{
    String id;
    private void checkLogin()
    {
        if (Session["user_id"] == null || Session["user_id"].ToString() == "")
        {
            Response.Redirect("~/");
        }
    }

    private void setPageTree()
    {
        ((HtmlGenericControl)Page.Master.FindControl("treepage")).InnerHtml = "<li><a href='ManagementHome'><i class='fa fa-dashboard'></i>خانه</a></li>   <li><a href='ManagementContactUs'><i class='fa fa-comment'></i>پیام ها</a></li>   <li class='active'>ارتباط با کاربر</li>";
    }

    private void setTitle()
    {
        ((HtmlGenericControl)Page.Master.FindControl("htitle")).InnerHtml = "ارتباط با کاربر" + "<small>پیام دریافت شده و ارسال پیام</small>";
    }

    private void setActivateItemMenu()
    {
        ((HtmlGenericControl)Page.Master.FindControl("messages")).Attributes["class"] = "active";
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        checkLogin();
        try
        {
            id = Request.QueryString["id"].ToString();
        }
        catch
        {
            id = "";
        }

        if (id == "")
        {
            Response.Redirect("ManagementContactUs");
        }
        setPageTree();
        setActivateItemMenu();
        setTitle();
        setContactUsInfo();
        setSeen();
    }

    private void setContactUsInfo()
    {
        DBAContact dba = new DBAContact();
        DataTable dt = dba.getContactUsInfo(id);
        if (dt.Rows.Count > 0)
        {
            txtname.Text = dt.Rows[0]["name"].ToString();
            txtemail.Text = dt.Rows[0]["email"].ToString();
            txtsubject.Text = dt.Rows[0]["subject"].ToString();
            txtmessage.Text = dt.Rows[0]["message"].ToString();
            txtdatetime.Text = miladiToShamsi(dt.Rows[0]["date"].ToString());
        }
        else
            Response.Redirect("ManagementContactUs");
    }

    private void setSeen()
    {
        DBAContact dba = new DBAContact();
        dba.setSeen(Convert.ToInt32(id));
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
    protected void btnsendmessage_Click(object sender, EventArgs e)
    {

    }
}