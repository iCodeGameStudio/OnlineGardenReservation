using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data;
public partial class MainMasterPage : System.Web.UI.MasterPage
{
    String city;
    String ser_type;
    String type;
    String dat;

    private void setInfo()
    {
        DBAMembers dba = new DBAMembers();
        DataTable dt = dba.getMemberInfo(Convert.ToInt32(Session["member_id"]));
        if(dt.Rows.Count == 1)
        {
            //membername.InnerHtml = dt.Rows[0]["name"].ToString() + " ، خوش آمدید";
        }
    }

    private void checkLoginMember()
    {
        if(Session["member_id"] != null && Session["member_id"].ToString() != "")
        {
            setInfo();
            //membersigned.Attributes.Add("style", "display:block;");
        }
    }

    private void setCity()
    {
        DBAGardens dba = new DBAGardens();
        Repeater1.DataSource = dba.getCity();
        Repeater1.DataBind();
    }

    private void searchCity()
    {
        DBAGardens dba = new DBAGardens();
        Repeater1.DataSource = dba.getCity(txtSearch.Text);
        Repeater1.DataBind();
    }
    private String getPersianDate()
    {
        PersianCalendar pr = new PersianCalendar();
        String day = pr.GetDayOfMonth(DateTime.Now).ToString();
        String month = pr.GetMonth(DateTime.Now).ToString();
        String year = pr.GetYear(DateTime.Now).ToString();
        String day_of_week = pr.GetDayOfWeek(DateTime.Now).ToString();
        switch (day_of_week)
        {
            case "Saturday":
                day_of_week = "شنبه";
                break;
            case "Sunday":
                day_of_week = "یکشنبه";
                break;
            case "Monday":
                day_of_week = "دوشنبه";
                break;
            case "Tuesday":
                day_of_week = "سه شنبه";
                break;
            case "Wednesday":
                day_of_week = "چهارشنبه";
                break;
            case "Thursday":
                day_of_week = "پنجشنبه";
                break;
            case "Friday":
                day_of_week = "جمعه";
                break;
        }
        switch (month)
        {
            case "1":
                month = "فروردین";
                break;
            case "2":
                month = "اردیبهشت";
                break;
            case "3":
                month = "خرداد";
                break;
            case "4":
                month = "تیر";
                break;
            case "5":
                month = "مرداد";
                break;
            case "6":
                month = "شهریور";
                break;
            case "7":
                month = "مهر";
                break;
            case "8":
                month = "آبان";
                break;
            case "9":
                month = "آذر";
                break;
            case "10":
                month = "دی";
                break;
            case "11":
                month = "بهمن";
                break;
            case "12":
                month = "اسفند";
                break;
        }
        // ctl00_spandate.InnerText = day_of_week + " " + day + " " + month + " " + year;
        return day_of_week + " " + day + " " + month + " " + year;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        checkLoginMember();
        UTLNumbers num = new UTLNumbers();
        divdate.InnerText = num.ToPersianNumber(getPersianDate());
        setCity();
        try
        {
            city = Request.QueryString["City"];
            ser_type  = Request.QueryString["ST"];
            type =  Request.QueryString["TY"];
            dat = Request.QueryString["Date"];
        }
        catch
        { 
        city = "";
        ser_type = "";
        type = "";
            dat = "";
        }

        if (city != "")
        {
            myBtn1.Text = city;
            myBtn2.Text = city;            
        }
        else
        {
            myBtn1.Text = "شهر خود را انتخاب کنید";
            myBtn2.Text = "شهر خود را انتخاب کنید";
        }
        if(myBtn1.Text == "" && myBtn2.Text == "")
        {
            myBtn1.Text = "شهر خود را انتخاب کنید";
            myBtn2.Text = "شهر خود را انتخاب کنید";
        }
    }

    public String queryString(Object link)
    {
        PersianCalendar pr = new PersianCalendar();
        Int32 year = pr.GetYear(DateTime.Today);
        Int32 month = pr.GetMonth(DateTime.Today);
        Int32 day = pr.GetDayOfMonth(DateTime.Today);
        //if (dat == "" || dat == null)
        //{
        //    dat = year + "/" + month + "/" + day;
        //}
        return "Default?City=" + link + "&ST=" + ser_type + "&TY=" + type + "&Date=" + dat;
    }

    protected void txtSearch_PreRender(object sender, EventArgs e)
    {
        searchCity();
    }


    protected void myBtn1_Click(object sender, EventArgs e)
    {
      
    }

    protected void myBtn2_Click(object sender, EventArgs e)
    {

    }
}
