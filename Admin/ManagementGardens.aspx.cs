using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.Data;
using System.IO;
using System.Text;

public partial class Admin_ManagementMembers : System.Web.UI.Page
{
    private void checkLogin()
    {
        if (Session["user_id"] == null || Session["user_id"].ToString() == "")
        {
            Response.Redirect("~/");
        }
    }

    private void setPageTree()
    {
        ((HtmlGenericControl)Page.Master.FindControl("treepage")).InnerHtml = "<li><a href='ManagementHome'><i class='fa fa-dashboard'></i>خانه</a></li>   <li class='active'>باغ ها</li>";
    }
    private void setTitle()
    {
        ((HtmlGenericControl)Page.Master.FindControl("htitle")).InnerHtml = "باغ ها" + "<small>لیست صاحبان باغ ها و جستجو بر اساس کد ملی و نام خانوادگی</small>";
    }
    private void setActivateItemMenu()
    {
        ((HtmlGenericControl)Page.Master.FindControl("gardens")).Attributes["class"] = "active";
    }

    private void setGardens()
    {
        DBAGardens dba = new DBAGardens();
        GridView1.DataSource = dba.getGardens(txtsearch.Text);
        GridView1.DataBind();
    }

    public String setPeriod(Object garden_id)
    {
        String start_date_act = "";
        String end_date_act = "";
        DBAGardens dba = new DBAGardens();
        DataTable dt = dba.getGardenInfo(Convert.ToInt32(garden_id));
        if (dt.Rows.Count == 1)
        {
            start_date_act = dt.Rows[0]["start_date_act"].ToString();
            end_date_act = dt.Rows[0]["end_date_act"].ToString();
        }
        DateTime start_date = new DateTime();
        start_date = Convert.ToDateTime(start_date_act);
        DateTime end_date = new DateTime();
        end_date = Convert.ToDateTime(end_date_act);
        String diff2 = (end_date - start_date).TotalDays.ToString();
        diff2 = Convert.ToInt32(diff2) / 31 + "";
        return diff2;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        checkLogin();
        setPageTree();
        setTitle();
        setActivateItemMenu();
        if (!Page.IsPostBack)
        {
            setGardens();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        setGardens();
    }

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


    protected void Button2_Click(object sender, EventArgs e)
    {
        //GridView1.PagerSettings.Visible = false;
        //GridView1.DataBind();
        //StringWriter sw = new StringWriter();
        //HtmlTextWriter hw = new HtmlTextWriter(sw);
        //GridView1.RenderControl(hw);
        //string gridHTML = sw.ToString().Replace("\"", "'")
        //    .Replace(System.Environment.NewLine, "");
        //StringBuilder sb = new StringBuilder();
        //sb.Append("<script type = 'text/javascript'>");
        //sb.Append("window.onload = new function(){");
        //sb.Append("var printWin = window.open('', '', 'left=0");
        //sb.Append(",top=0,width=1000,height=600,status=0');");
        //sb.Append("printWin.document.write(\"");
        //sb.Append(gridHTML);
        //sb.Append("\");");
        //sb.Append("printWin.document.close();");
        //sb.Append("printWin.focus();");
        //sb.Append("printWin.print();");
        //sb.Append("printWin.close();};");
        //sb.Append("</script>");
        //ClientScript.RegisterStartupScript(this.GetType(), "GridPrint", sb.ToString());
        //GridView1.PagerSettings.Visible = true;
        //GridView1.DataBind();
    }
}