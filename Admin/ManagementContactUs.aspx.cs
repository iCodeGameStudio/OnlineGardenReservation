using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Globalization;

public partial class Admin_ManagementContactUs : System.Web.UI.Page
{
    private void setPageTree()
    {
        ((HtmlGenericControl)Page.Master.FindControl("treepage")).InnerHtml = "<li><a href='ManagementHome'><i class='fa fa-dashboard'></i>خانه</a></li><li class='active'>پیام ها</li>";
    }
    private void setTitle()
    {
        ((HtmlGenericControl)Page.Master.FindControl("htitle")).InnerHtml = "پیام کاربران";
    }
    private void setActivateItemMenu()
    {
        ((HtmlGenericControl)Page.Master.FindControl("messages")).Attributes["class"] = "active";
    }

    private void checkLogin()
    {
        if (Session["user_id"] == null || Session["user_id"].ToString() == "")
        {
            Response.Redirect("~/");
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        checkLogin();
        setPageTree();
        setTitle();
        setActivateItemMenu();
        if (!Page.IsPostBack)
            setContactUs();
    }

    private void setContactUs()
    {
        DBAContact dba = new DBAContact();
        GridView1.DataSource = dba.getContactUs();
        GridView1.DataBind();
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

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DBAContact dba = new DBAContact();
        Int32 id = Int32.Parse(e.CommandArgument.ToString());
        String command = e.CommandName.ToString();
        if (command == "remove")
        {
            dba.removeMessage(id);
            setContactUs();
        }
    }

    public String ToFarsi(String number)
    {
        UTLNumbers num = new UTLNumbers();
        return num.ToPersianNumber(number);
    }
}