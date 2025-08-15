using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Globalization;
public partial class Accounts_AccountHome : System.Web.UI.Page
{
    private void setPageTree()
    {
        ((HtmlGenericControl)Page.Master.FindControl("treepage")).InnerHtml = "";
    }
    private void setTitle()
    {
        ((HtmlGenericControl)Page.Master.FindControl("htitle")).InnerHtml = "داشبورد" + "<small>اطلاعاتی جامع در مورد عملکرد ها</small>";
    }
    private void setActivateItemMenu()
    {
        ((HtmlGenericControl)Page.Master.FindControl("home")).Attributes["class"] = "active";
    }
    private void checkLogin()
    {
        if (Session["garden_id"] == null || Session["garden_id"].ToString() == "")
        {
            Response.Redirect("~/");
        }
    }

    private void setServiceInfo()
    {
            String start_date_act = "";
            String end_date_act = "";
            String act_count = "";
            DBAGardens dba = new DBAGardens();
            DataTable dt = dba.getGardenInfo(Convert.ToInt32(Session["garden_id"]));
            if (dt.Rows.Count == 1)
            {
                start_date_act = dt.Rows[0]["start_date_act"].ToString();
                end_date_act = dt.Rows[0]["end_date_act"].ToString();
                act_count = dt.Rows[0]["act_count"].ToString();
            }
            DateTime now_date = new DateTime();
            now_date = DateTime.Today;
            DateTime end_date = new DateTime();
            end_date = Convert.ToDateTime(end_date_act);
            //DateTime different = new DateTime(end_date.Subtract(now_date).Days); 
            //TimeSpan diff1 = end_date - now_date;
            String diff2 = (end_date - now_date).TotalDays.ToString();
            H_day_end_act.InnerText = diff2 + " روز";
            H_start_date_act.InnerText = convertToShamsi(start_date_act);
            H_end_date_act.InnerText = convertToShamsi(end_date_act);
            H_act_count.InnerText = act_count;
    }

    public String convertToShamsi(String date)
    {
        DateTime miladidate = Convert.ToDateTime(date.ToString());
        PersianCalendar persian = new PersianCalendar();
        String day = "";
        String mounth = "";
        String year = "";
        String mounth_name = "";
        day = persian.GetDayOfMonth(miladidate).ToString();
        mounth = persian.GetMonth(miladidate).ToString();
        mounth_name = mounthName(mounth);
        year = persian.GetYear(miladidate).ToString();
        String persiandate = day + " " + mounth_name + " " + year;
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

    protected void Page_Load(object sender, EventArgs e)
    {
       
        checkLogin();
        setPageTree();
        setTitle();
        setActivateItemMenu();
        setServiceInfo();
    }
}