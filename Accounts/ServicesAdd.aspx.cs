using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data;
using System.IO;
using System.Web.UI.HtmlControls;

public partial class Accounts_ServicesAdd : System.Web.UI.Page
{
    static Int32 years;
    static Int32 months;
    static String ser_type;
    static Int32 ser_capacity;
    static String ser_eating;
    static String ser_other;
    static String date_ser;
    static DateTime start_date_act;
    static DateTime end_date_act;
    static Int32 start_year_act;
    static Int32 end_year_act;
    static Int32 start_month_act;
    static Int32 end_month_act;
    static Int32 start_day_act;
    static Int32 end_day_act;

    private void setPageTree()
    {
        ((HtmlGenericControl)Page.Master.FindControl("treepage")).InnerHtml = "<li><a href='AccountHome'><i class='fa fa-dashboard'></i>خانه</a></li>   <li class='active'>ثبت سرویس</li>";
    }

    private void setTitle()
    {
        ((HtmlGenericControl)Page.Master.FindControl("htitle")).InnerHtml = "ثبت سرویس" + "<small>تعریف سرویس برای تاریخ های مشخص</small>";
    }
    private void setActivateItemMenu()
    {
        ((HtmlGenericControl)Page.Master.FindControl("servicesAdd")).Attributes["class"] = "active";
        ((HtmlGenericControl)Page.Master.FindControl("serviceAdd")).Attributes["class"] = "active";
    }

    private void checkLogin()
    {
        if (Session["garden_id"] == null || Session["garden_id"].ToString() == "")
        {
            Response.Redirect("~/");
        }
    }

    private void expireServiceDay()
    {
        try
        {
            UTLNumbers num = new UTLNumbers();
            PersianCalendar pr = new PersianCalendar();
            //  DateTime date = new DateTime();
            start_month_act = pr.GetMonth(start_date_act);
            end_month_act = pr.GetMonth(end_date_act);
            start_day_act = pr.GetDayOfMonth(start_date_act);
            end_day_act = pr.GetDayOfMonth(end_date_act);
            if (years == end_year_act)
            {
                if (months == end_month_act)
                {
                    for (int i = 1; i <= 37; i++)
                    {
                        CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                        Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                        if (Convert.ToInt32(num.ToEnglishNumber(chk.Text)) > end_day_act)
                        {
                            chk.Enabled = false;
                            btn.Enabled = false;
                            btn.BackColor = System.Drawing.Color.Gray;
                        }
                    }
                }
                else if (months > end_month_act)
                {
                    for (int i = 1; i <= 37; i++)
                    {
                        CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                        Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                        chk.Enabled = false;
                        btn.Enabled = false;
                        btn.BackColor = System.Drawing.Color.Gray;
                    }
                }
            }
        }
        catch
        {
        //    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('error', { title: 'خطا', img: '/Images/icon-error.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'کاربر گرامی ، سیستم دچار مشکل شده است ، لطفا مجددا تلاش کنید', delay: 20000 });", true);
        }
    }

    private void checkDateAct()
    {
        try
        {
            UTLNumbers num = new UTLNumbers();
            PersianCalendar pr = new PersianCalendar();
            DateTime date = new DateTime();
            date = DateTime.Parse(DateTime.Now.ToShortDateString());
            DBAGardens dba = new DBAGardens();
            DataTable dt = dba.getDateAct(Convert.ToInt32(Session["garden_id"]));
            if (dt.Rows.Count == 1)
            {
                start_date_act = Convert.ToDateTime(dt.Rows[0]["start_date_act"]);
                end_date_act = Convert.ToDateTime(dt.Rows[0]["end_date_act"]);
            }
            start_year_act = pr.GetYear(start_date_act);
            end_year_act = pr.GetYear(end_date_act);
            //   btnyear.Text = start_year_act.ToString();
            for (int i = start_year_act; i <= end_year_act; i++)
            {
                lstYear.Items.Add(i.ToString());
            }
            for (int i = 0; i < lstYear.Items.Count; i++)
            {
                if (lstYear.Items[i].Text == pr.GetYear(date).ToString())
                {
                    lstYear.SelectedIndex = i;
                    break;
                }
            }
            btnyear.Text = num.ToPersianNumber(lstYear.Text);
            years = Convert.ToInt32(lstYear.Text);
            //=================================================================
        }
        catch
        {
         //   ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('error', { title: 'خطا', img: '/Images/icon-error.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'کاربر گرامی ، سیستم دچار مشکل شده است ، لطفا مجددا تلاش کنید', delay: 20000 });", true);
        }
    }

    private void setServices()
    {
        try
        {
            dropdown.Items.Clear();
            DBAServices dba = new DBAServices();
            DataTable dt = new DataTable();
            dt = dba.getServicesDFD(Convert.ToInt32(Session["garden_id"]));
            dropdown.Items.Insert(0, new ListItem("سرویس مورد نظر را انتخاب کنید", ""));
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dropdown.Items.Insert(i + 1, new ListItem("سرویس: " + dt.Rows[i][2].ToString() + " / " + dt.Rows[i][3].ToString() + "نفر / " + dt.Rows[i][4].ToString(), dt.Rows[i][0].ToString()));
                }
            }
        }
        catch
        {
          //  ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('error', { title: 'خطا', img: '/Images/icon-error.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'کاربر گرامی ، سیستم دچار مشکل شده است ، لطفا مجددا تلاش کنید', delay: 20000 });", true);
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
       
        try
        {
            checkLogin();
            setPageTree();
            setTitle();
            setActivateItemMenu();
            if (!Page.IsPostBack)
            {
                checkDateAct();
                UTLNumbers num = new UTLNumbers();
                PersianCalendar pc = new PersianCalendar();
                DateTime date = new DateTime();
                date = DateTime.Now;
                int year = Convert.ToInt32(pc.GetYear(date));
                int month = Convert.ToInt32(pc.GetMonth(date));
                int day = Convert.ToInt32(pc.GetDayOfMonth(date));
                months = month;
                years = year;
                //====================================چک میکند که اول ماه از کدام روز هفته آغاز می شود===============================
                DateTime dt = new DateTime(year, month, 1, pc);
                String dayofweek = pc.GetDayOfWeek(Convert.ToDateTime(dt.ToString(CultureInfo.InvariantCulture))).ToString();
                Boolean isleap = pc.IsLeapYear(year); //سال جاری را میگیرد و مشخص میکند که این سال کبیسه است یا خیر
                setDays(dayofweek, isleap, month); //متدی که وظیفه ی قرار دادن روز در تقویم را به عهده دارد را فراخوانی میکند                                          
                                                   //===========================================================================================================
                setMonth(month); //این متد ماه جاری را گرفته و بر اساس آن در تقویم ماه جاری و ماه آینده و دو ماه دیگر را قرار میدهد
                years.ToString();
                // lblYear.Text = num.ToPersianNumber(year.ToString());
                changeDesableEnableCheckbox();
                setServices();
                setServiceTypeForDays();
                expireServiceDay();
            }
        }
        catch
        {
          //  ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('error', { title: 'خطا', img: '/Images/icon-error.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'کاربر گرامی ، سیستم دچار مشکل شده است ، لطفا مجددا تلاش کنید', delay: 20000 });", true);
        }
    }

    private void changeDesableEnableCheckbox()
    {
        try
        {
            UTLNumbers num = new UTLNumbers();
            PersianCalendar pc = new PersianCalendar();
            DateTime date = new DateTime();
            date = DateTime.Now;
            Int32 year = Convert.ToInt32(pc.GetYear(date));
            Int32 month = Convert.ToInt32(pc.GetMonth(date));
            Int32 day = Convert.ToInt32(pc.GetDayOfMonth(date));
            for (int i = 1; i <= 37; i++)
            {
                CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                if (years == year)
                {
                    if (months == month)
                    {
                        if (chk.Text != "" && chk.Visible == true)
                        {

                            if (Convert.ToInt32(num.ToEnglishNumber(chk.Text)) < day)
                            {
                                chk.Enabled = false;
                                btn.Enabled = false;
                                btn.BackColor = System.Drawing.Color.Gray;
                            }
                            else
                            {
                                chk.Enabled = true;
                                btn.Enabled = true;
                                btn.BackColor = default(System.Drawing.Color);
                            }

                        }
                    }
                    else if (months < month)
                    {
                        if (chk.Text != "")
                        {
                            chk.Enabled = false;
                            btn.Enabled = false;
                            btn.BackColor = System.Drawing.Color.Gray;
                        }
                    }
                    else
                    {
                        if (chk.Text != "" && chk.Visible == true)
                        {
                            chk.Enabled = true;
                            btn.Enabled = true;
                            btn.BackColor = default(System.Drawing.Color);
                        }
                    }

                }
                else
                {
                    if (chk.Text != "" && chk.Visible == true)
                    {
                        btn.Enabled = true;
                        chk.Enabled = true;
                        btn.Visible = true;
                        btn.BackColor = default(System.Drawing.Color);
                    }
                }
            }
        }
        catch
        {
          //  ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('error', { title: 'خطا', img: '/Images/icon-error.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'کاربر گرامی ، سیستم دچار مشکل شده است ، لطفا مجددا تلاش کنید', delay: 20000 });", true);
        }

    }

    private void setMonth(Int32 month)
    {
        try
        {
            switch (month)
            {
                case 1:
                    month1.Text = "فروردین";
                    break;
                case 2:
                    month1.Text = "اردیبهشت";
                    break;
                case 3:
                    month1.Text = "خرداد";
                    break;
                case 4:
                    month1.Text = "تیر";
                    break;
                case 5:
                    month1.Text = "مرداد";
                    break;
                case 6:
                    month1.Text = "شهریور";
                    break;
                case 7:
                    month1.Text = "مهر";
                    break;
                case 8:
                    month1.Text = "آبان";
                    break;
                case 9:
                    month1.Text = "آذر";
                    break;
                case 10:
                    month1.Text = "دی";
                    break;
                case 11:
                    month1.Text = "بهمن";
                    break;
                case 12:
                    month1.Text = "اسفند";
                    break;
            }
        }
        catch
        {
         //   ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('error', { title: 'خطا', img: '/Images/icon-error.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'کاربر گرامی ، سیستم دچار مشکل شده است ، لطفا مجددا تلاش کنید', delay: 20000 });", true);
        }
    }


    private void setDays(String dayOfweek, Boolean isleap, Int32 month)
    {
        try
        {
            UTLNumbers num = new UTLNumbers();
            if (month == 1 || month == 2 || month == 3 || month == 4 || month == 5 || month == 6)
            {
                switch (dayOfweek)
                {
                    case "Saturday":

                        for (int i = 1; i <= 31; i++)
                        {
                            CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                            Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                            chk.Text = num.ToPersianNumber(i.ToString());
                            chk.Visible = true;
                            btn.Visible = true;
                        }
                        for (int i = 32; i <= 37; i++)
                        {
                            CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                            Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                            chk.Visible = false;
                            btn.Visible = false;
                        }

                        break;
                    case "Sunday":
                        CheckBox1.Visible = false;
                        Button1.Visible = false;
                        for (int i = 2; i <= 32; i++)
                        {
                            CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                            Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                            chk.Text = num.ToPersianNumber(i - 1 + "");
                            chk.Visible = true;
                            btn.Visible = true;
                        }
                        for (int i = 33; i <= 37; i++)
                        {
                            CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                            Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                            chk.Visible = false;
                            btn.Visible = false;
                        }

                        break;
                    case "Monday":
                        CheckBox1.Visible = false;
                        CheckBox2.Visible = false;
                        Button1.Visible = false;
                        Button2.Visible = false;
                        for (int i = 3; i <= 33; i++)
                        {
                            CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                            Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                            chk.Text = num.ToPersianNumber(i - 2 + "");
                            chk.Visible = true;
                            btn.Visible = true;

                        }
                        for (int i = 34; i <= 37; i++)
                        {
                            CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                            Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                            chk.Visible = false;
                            btn.Visible = false;
                        }

                        break;
                    case "Tuesday":
                        for (int i = 1; i <= 3; i++)
                        {
                            CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                            Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                            chk.Visible = false;
                            btn.Visible = false;
                        }
                        for (int i = 4; i <= 34; i++)
                        {
                            CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                            Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                            chk.Text = num.ToPersianNumber(i - 3 + "");
                            chk.Visible = true;
                            btn.Visible = true;
                        }
                        for (int i = 35; i <= 37; i++)
                        {
                            CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                            Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                            chk.Visible = false;
                            btn.Visible = false;
                        }

                        break;
                    case "Wednesday":
                        for (int i = 1; i <= 4; i++)
                        {
                            CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                            Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                            chk.Visible = false;
                            btn.Visible = false;
                        }
                        for (int i = 5; i <= 35; i++)
                        {
                            CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                            Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                            chk.Text = num.ToPersianNumber(i - 4 + "");
                            chk.Visible = true;
                            btn.Visible = true;
                        }

                        CheckBox36.Visible = false;
                        CheckBox37.Visible = false;
                        Button36.Visible = false;
                        Button37.Visible = false;
                        break;
                    case "Thursday":
                        for (int i = 1; i <= 5; i++)
                        {
                            CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                            Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                            chk.Visible = false;
                            btn.Visible = false;
                        }
                        for (int i = 6; i <= 36; i++)
                        {
                            CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                            Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                            chk.Text = num.ToPersianNumber(i - 5 + "");
                            chk.Visible = true;
                            btn.Visible = true;
                        }

                        CheckBox37.Visible = false;
                        Button37.Visible = false;
                        break;
                    case "Friday":
                        for (int i = 1; i <= 6; i++)
                        {
                            CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                            Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                            chk.Visible = false;
                            btn.Visible = false;
                        }
                        for (int i = 7; i <= 37; i++)
                        {
                            CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                            Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                            chk.Text = num.ToPersianNumber(i - 6 + "");
                            chk.Visible = true;
                            btn.Visible = true;
                        }

                        break;
                }
            }
            else if (month == 7 || month == 8 || month == 9 || month == 10 || month == 11)
            {
                switch (dayOfweek)
                {
                    case "Saturday":
                        for (int i = 1; i <= 30; i++)
                        {
                            CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                            Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                            chk.Text = num.ToPersianNumber(i.ToString());
                            chk.Visible = true;
                            btn.Visible = true;
                        }
                        for (int i = 31; i <= 37; i++)
                        {
                            CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                            Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                            chk.Visible = false;
                            btn.Visible = false;
                        }
                        break;
                    case "Sunday":
                        CheckBox1.Visible = false;
                        Button1.Visible = false;
                        for (int i = 2; i <= 31; i++)
                        {
                            CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                            Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                            chk.Text = num.ToPersianNumber(i - 1 + "");
                            chk.Visible = true;
                            btn.Visible = true;
                        }
                        for (int i = 32; i <= 37; i++)
                        {
                            CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                            Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                            chk.Visible = false;
                            btn.Visible = false;
                        }
                        break;
                    case "Monday":
                        CheckBox1.Visible = false;
                        CheckBox2.Visible = false;
                        Button1.Visible = false;
                        Button2.Visible = false;
                        for (int i = 3; i <= 32; i++)
                        {
                            CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                            Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                            chk.Text = num.ToPersianNumber(i - 2 + "");
                            chk.Visible = true;
                            btn.Visible = true;
                        }
                        for (int i = 33; i <= 37; i++)
                        {
                            CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                            Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                            chk.Visible = false;
                            btn.Visible = false;
                        }
                        break;
                    case "Tuesday":
                        for (int i = 1; i <= 3; i++)
                        {
                            CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                            Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                            chk.Visible = false;
                            btn.Visible = false;
                        }
                        for (int i = 4; i <= 33; i++)
                        {
                            CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                            Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                            chk.Text = num.ToPersianNumber(i - 3 + "");
                            chk.Visible = true;
                            btn.Visible = true;
                        }
                        for (int i = 34; i <= 37; i++)
                        {
                            CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                            Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                            chk.Visible = false;
                            btn.Visible = false;
                        }
                        break;
                    case "Wednesday":
                        for (int i = 1; i <= 4; i++)
                        {
                            CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                            Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                            chk.Visible = false;
                            btn.Visible = false;
                        }
                        for (int i = 5; i <= 34; i++)
                        {
                            CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                            Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                            chk.Text = num.ToPersianNumber(i - 4 + "");
                            chk.Visible = true;
                            btn.Visible = true;
                        }
                        CheckBox36.Visible = false;
                        CheckBox37.Visible = false;
                        Button36.Visible = false;
                        Button37.Visible = false;
                        break;
                    case "Thursday":
                        for (int i = 1; i <= 5; i++)
                        {
                            CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                            Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                            chk.Visible = false;
                            btn.Visible = false;
                        }
                        for (int i = 6; i <= 35; i++)
                        {
                            CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                            Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                            chk.Text = num.ToPersianNumber(i - 5 + "");
                            chk.Visible = true;
                            btn.Visible = true;
                        }
                        CheckBox37.Visible = false;
                        Button37.Visible = false;
                        break;
                    case "Friday":
                        for (int i = 1; i <= 6; i++)
                        {
                            CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                            Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                            chk.Visible = false;
                            btn.Visible = false;
                        }
                        for (int i = 7; i <= 36; i++)
                        {
                            CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                            Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                            chk.Text = num.ToPersianNumber(i - 6 + "");
                            chk.Visible = true;
                            btn.Visible = true;
                        }
                        break;
                }
            }
            else if (month == 12)
            {
                if (isleap == true)
                {
                    switch (dayOfweek)
                    {
                        case "Saturday":
                            for (int i = 1; i <= 30; i++)
                            {
                                CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                                Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                                chk.Text = num.ToPersianNumber(i.ToString());
                                chk.Visible = true;
                                btn.Visible = true;
                            }
                            for (int i = 31; i <= 37; i++)
                            {
                                CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                                Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                                chk.Visible = false;
                                btn.Visible = false;
                            }
                            break;
                        case "Sunday":
                            CheckBox1.Visible = false;
                            Button1.Visible = false;
                            for (int i = 2; i <= 31; i++)
                            {
                                CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                                Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                                chk.Text = num.ToPersianNumber(i - 1 + "");
                                chk.Visible = true;
                                btn.Visible = true;
                            }
                            for (int i = 32; i <= 37; i++)
                            {
                                CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                                Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                                chk.Visible = false;
                                btn.Visible = false;
                            }
                            break;
                        case "Monday":
                            Button1.Visible = false;
                            Button2.Visible = false;
                            CheckBox1.Visible = false;
                            CheckBox2.Visible = false;
                            for (int i = 3; i <= 32; i++)
                            {
                                CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                                Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                                chk.Text = num.ToPersianNumber(i - 2 + "");
                                chk.Visible = true;
                                btn.Visible = true;
                            }
                            for (int i = 33; i <= 37; i++)
                            {
                                CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                                Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                                chk.Visible = false;
                                btn.Visible = false;
                            }
                            break;
                        case "Tuesday":
                            for (int i = 1; i <= 3; i++)
                            {
                                CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                                Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                                chk.Visible = false;
                                btn.Visible = false;
                            }
                            for (int i = 4; i <= 33; i++)
                            {
                                CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                                Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                                chk.Text = num.ToPersianNumber(i - 3 + "");
                                chk.Visible = true;
                                btn.Visible = true;
                            }
                            for (int i = 34; i <= 37; i++)
                            {
                                CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                                Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                                chk.Visible = false;
                                btn.Visible = false;
                            }
                            break;
                        case "Wednesday":
                            for (int i = 1; i <= 4; i++)
                            {
                                CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                                Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                                chk.Visible = false;
                                btn.Visible = false;
                            }
                            for (int i = 5; i <= 34; i++)
                            {
                                CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                                Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                                chk.Text = num.ToPersianNumber(i - 4 + "");
                                chk.Visible = true;
                                btn.Visible = true;
                            }
                            for (int i = 35; i <= 37; i++)
                            {
                                CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                                Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                                chk.Visible = false;
                                btn.Visible = false;
                            }
                            break;
                        case "Thursday":
                            for (int i = 1; i <= 5; i++)
                            {
                                CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                                Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                                chk.Visible = false;
                                btn.Visible = false;
                            }
                            for (int i = 6; i <= 35; i++)
                            {
                                CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                                Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                                chk.Text = num.ToPersianNumber(i - 5 + "");
                                chk.Visible = true;
                                btn.Visible = true;

                            }
                            CheckBox36.Visible = false;
                            Button36.Visible = false;
                            CheckBox37.Visible = false;
                            Button37.Visible = false;
                            break;
                        case "Friday":
                            for (int i = 1; i <= 6; i++)
                            {
                                CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                                Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                                chk.Visible = false;
                                btn.Visible = false;
                            }
                            for (int i = 7; i <= 36; i++)
                            {
                                CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                                Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                                chk.Text = num.ToPersianNumber(i - 6 + "");
                                chk.Visible = true;
                                btn.Visible = true;
                            }
                            CheckBox37.Visible = false;
                            Button37.Visible = false;
                            break;
                    }
                }
                else
                {
                    switch (dayOfweek)
                    {
                        case "Saturday":
                            for (int i = 1; i <= 29; i++)
                            {
                                CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                                Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                                chk.Text = num.ToPersianNumber(i.ToString());
                                chk.Visible = true;
                                btn.Visible = true;
                            }
                            for (int i = 30; i <= 37; i++)
                            {
                                CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                                Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                                chk.Visible = false;
                                btn.Visible = false;
                            }
                            break;
                        case "Sunday":
                            CheckBox1.Visible = false;
                            Button1.Visible = false;
                            for (int i = 2; i <= 30; i++)
                            {
                                CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                                Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                                chk.Text = num.ToPersianNumber(i - 1 + "");
                                chk.Visible = true;
                                btn.Visible = true;
                            }
                            for (int i = 31; i <= 37; i++)
                            {
                                CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                                Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                                chk.Visible = false;
                                btn.Visible = false;
                            }
                            break;
                        case "Monday":
                            Button1.Visible = false;
                            Button2.Visible = false;
                            CheckBox1.Visible = false;
                            CheckBox2.Visible = false;
                            for (int i = 3; i <= 31; i++)
                            {
                                CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                                Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                                chk.Text = num.ToPersianNumber(i - 2 + "");
                                chk.Visible = true;
                                btn.Visible = true;
                            }
                            for (int i = 32; i <= 37; i++)
                            {
                                CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                                Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                                chk.Visible = false;
                                btn.Visible = false;
                            }
                            break;
                        case "Tuesday":
                            for (int i = 1; i <= 3; i++)
                            {
                                CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                                Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                                chk.Visible = false;
                                btn.Visible = false;
                            }
                            for (int i = 4; i <= 32; i++)
                            {
                                CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                                Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                                chk.Text = num.ToPersianNumber(i - 3 + "");
                                chk.Visible = true;
                                btn.Visible = true;
                            }
                            for (int i = 33; i <= 37; i++)
                            {
                                CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                                Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                                chk.Visible = false;
                                btn.Visible = false;
                            }
                            break;
                        case "Wednesday":
                            for (int i = 1; i <= 4; i++)
                            {
                                CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                                Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                                chk.Visible = false;
                                btn.Visible = false;
                            }
                            for (int i = 5; i <= 33; i++)
                            {
                                CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                                Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                                chk.Text = num.ToPersianNumber(i - 4 + "");
                                chk.Visible = true;
                                btn.Visible = true;
                            }
                            for (int i = 34; i <= 37; i++)
                            {
                                CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                                Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                                chk.Visible = false;
                                btn.Visible = false;
                            }
                            break;
                        case "Thursday":
                            for (int i = 1; i <= 5; i++)
                            {
                                CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                                Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                                chk.Visible = false;
                                btn.Visible = false;
                            }
                            for (int i = 6; i <= 34; i++)
                            {
                                CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                                Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                                chk.Text = num.ToPersianNumber(i - 5 + "");
                                chk.Visible = true;
                                btn.Visible = true;
                            }
                            for (int i = 35; i <= 37; i++)
                            {
                                CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                                Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                                chk.Visible = false;
                                btn.Visible = false;
                            }
                            break;
                        case "Friday":
                            for (int i = 1; i <= 6; i++)
                            {
                                CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                                Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                                chk.Visible = false;
                                btn.Visible = false;
                            }
                            for (int i = 7; i <= 35; i++)
                            {
                                CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                                Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                                chk.Text = num.ToPersianNumber(i - 6 + "");
                                chk.Visible = true;
                                btn.Visible = true;
                            }
                            CheckBox36.Visible = false;
                            CheckBox37.Visible = false;
                            Button36.Visible = false;
                            Button37.Visible = false;
                            break;
                    }
                }
            }

        }
        catch
        {
         //   ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('error', { title: 'خطا', img: '/Images/icon-error.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'کاربر گرامی ، سیستم دچار مشکل شده است ، لطفا مجددا تلاش کنید', delay: 20000 });", true);
        }
    }

    private void selectMonth(String monthName)
    {
        try
        {
            PersianCalendar pc = new PersianCalendar();
            DateTime dt = new DateTime();
            String dayofweek;
            Boolean isleap = pc.IsLeapYear(years); //سال جاری را میگیرد و مشخص میکند که این سال کبیسه است یا خیر
            switch (monthName)
            {
                case "فروردین":
                    dt = new DateTime(years, 1, 1, pc);
                    dayofweek = pc.GetDayOfWeek(Convert.ToDateTime(dt.ToString(CultureInfo.InvariantCulture))).ToString();
                    setDays(dayofweek, isleap, 1);
                    months = 1;
                    break;
                case "اردیبهشت":
                    dt = new DateTime(years, 2, 1, pc);
                    dayofweek = pc.GetDayOfWeek(Convert.ToDateTime(dt.ToString(CultureInfo.InvariantCulture))).ToString();
                    setDays(dayofweek, isleap, 2);
                    months = 2;
                    break;
                case "خرداد":
                    dt = new DateTime(years, 3, 1, pc);
                    dayofweek = pc.GetDayOfWeek(Convert.ToDateTime(dt.ToString(CultureInfo.InvariantCulture))).ToString();
                    setDays(dayofweek, isleap, 3);
                    months = 3;
                    break;
                case "تیر":
                    dt = new DateTime(years, 4, 1, pc);
                    dayofweek = pc.GetDayOfWeek(Convert.ToDateTime(dt.ToString(CultureInfo.InvariantCulture))).ToString();
                    setDays(dayofweek, isleap, 4);
                    months = 4;
                    break;
                case "مرداد":
                    dt = new DateTime(years, 5, 1, pc);
                    dayofweek = pc.GetDayOfWeek(Convert.ToDateTime(dt.ToString(CultureInfo.InvariantCulture))).ToString();
                    setDays(dayofweek, isleap, 5);
                    months = 5;
                    break;
                case "شهریور":
                    dt = new DateTime(years, 6, 1, pc);
                    dayofweek = pc.GetDayOfWeek(Convert.ToDateTime(dt.ToString(CultureInfo.InvariantCulture))).ToString();
                    setDays(dayofweek, isleap, 6);
                    months = 6;
                    break;
                case "مهر":
                    dt = new DateTime(years, 7, 1, pc);
                    dayofweek = pc.GetDayOfWeek(Convert.ToDateTime(dt.ToString(CultureInfo.InvariantCulture))).ToString();
                    setDays(dayofweek, isleap, 7);
                    months = 7;
                    break;
                case "آبان":
                    dt = new DateTime(years, 8, 1, pc);
                    dayofweek = pc.GetDayOfWeek(Convert.ToDateTime(dt.ToString(CultureInfo.InvariantCulture))).ToString();
                    setDays(dayofweek, isleap, 8);
                    months = 8;
                    break;
                case "آذر":
                    dt = new DateTime(years, 9, 1, pc);
                    dayofweek = pc.GetDayOfWeek(Convert.ToDateTime(dt.ToString(CultureInfo.InvariantCulture))).ToString();
                    setDays(dayofweek, isleap, 9);
                    months = 9;
                    break;
                case "دی":
                    dt = new DateTime(years, 10, 1, pc);
                    dayofweek = pc.GetDayOfWeek(Convert.ToDateTime(dt.ToString(CultureInfo.InvariantCulture))).ToString();
                    setDays(dayofweek, isleap, 10);
                    months = 10;
                    break;
                case "بهمن":
                    dt = new DateTime(years, 11, 1, pc);
                    dayofweek = pc.GetDayOfWeek(Convert.ToDateTime(dt.ToString(CultureInfo.InvariantCulture))).ToString();
                    setDays(dayofweek, isleap, 11);
                    months = 11;
                    break;
                case "اسفند":
                    dt = new DateTime(years, 12, 1, pc);
                    dayofweek = pc.GetDayOfWeek(Convert.ToDateTime(dt.ToString(CultureInfo.InvariantCulture))).ToString();
                    setDays(dayofweek, isleap, 12);
                    months = 12;
                    break;
            }
        }
        catch
        {
         //   ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('error', { title: 'خطا', img: '/Images/icon-error.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'کاربر گرامی ، سیستم دچار مشکل شده است ، لطفا مجددا تلاش کنید', delay: 20000 });", true);
        }

    }



    protected void btn_Click(object sender, EventArgs e)
    {
        try
        {
            for (int i = 1; i <= 37; i++)
            {
                CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                if (chk.Checked == true)
                {
                    chk.Checked = false;
                }
            }
            lst.Items.Clear();
        }
        catch
        {
          //  ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('error', { title: 'خطا', img: '/Images/icon-error.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'کاربر گرامی ، سیستم دچار مشکل شده است ، لطفا مجددا تلاش کنید', delay: 20000 });", true);
        }
    }



    private void checkClick()
    {
        try
        {
            UTLNumbers num = new UTLNumbers();
            DateTime dt = new DateTime();
            PersianCalendar pc = new PersianCalendar();
            lst.Items.Clear();
            for (int i = 1; i <= 37; i++)
            {
                CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                if (chk.Checked == true)
                {
                    dt = new DateTime(years, months, Convert.ToInt32(num.ToEnglishNumber(chk.Text)), pc);
                    lst.Items.Add(Convert.ToDateTime(dt.ToString(CultureInfo.InvariantCulture)).ToString());
                }
            }
        }
        catch
        {
      //      ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('error', { title: 'خطا', img: '/Images/icon-error.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'کاربر گرامی ، سیستم دچار مشکل شده است ، لطفا مجددا تلاش کنید', delay: 20000 });", true);
        }

    }

    //==============================

    //================================
    protected void CheckBox_CheckedChanged(object sender, EventArgs e)
    {
        checkClick();
    }


    public String miladiToShamsi(Object miladi)
    {
        UTLNumbers num = new UTLNumbers();
        DateTime miladi_date = Convert.ToDateTime(miladi.ToString());
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
        String persiandate = num.ToPersianNumber(day_name + " " + day + " " + mounth_name + " " + year);
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

    public String setPersianNumber(Object number)
    {
        UTLNumbers num = new UTLNumbers();
        return num.ToPersianNumber(number.ToString());
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

    protected void arrow1_Click(object sender, EventArgs e)
    {
        previosMonth(month1.Text);
        selectMonth(month1.Text);
        changeDesableEnableCheckbox();
        setServiceTypeForDays();
        expireServiceDay();
    }

    protected void arrow2_Click(object sender, EventArgs e)
    {
        NextMonth(month1.Text);
        selectMonth(month1.Text);
        changeDesableEnableCheckbox();
        setServiceTypeForDays();
        expireServiceDay();
    }

    private void previosMonth(String mounth)
    {
        try
        {
            switch (mounth)
            {
                case "فروردین":
                    arrow1.Enabled = false;
                    arrow2.Enabled = true;
                    break;
                case "اردیبهشت":
                    month1.Text = "فروردین";
                    arrow1.Enabled = true;
                    arrow2.Enabled = true;
                    break;
                case "خرداد":
                    month1.Text = "اردیبهشت";
                    arrow1.Enabled = true;
                    arrow2.Enabled = true;
                    break;
                case "تیر":
                    month1.Text = "خرداد";
                    arrow1.Enabled = true;
                    arrow2.Enabled = true;
                    break;
                case "مرداد":
                    month1.Text = "تیر";
                    arrow1.Enabled = true;
                    arrow2.Enabled = true;
                    break;
                case "شهریور":
                    month1.Text = "مرداد";
                    arrow1.Enabled = true;
                    arrow2.Enabled = true;
                    break;
                case "مهر":
                    month1.Text = "شهریور";
                    arrow1.Enabled = true;
                    arrow2.Enabled = true;
                    break;
                case "آبان":
                    month1.Text = "مهر";
                    arrow1.Enabled = true;
                    arrow2.Enabled = true;
                    break;
                case "آذر":
                    month1.Text = "آبان";
                    arrow1.Enabled = true;
                    arrow2.Enabled = true;
                    break;
                case "دی":
                    month1.Text = "آذر";
                    arrow1.Enabled = true;
                    arrow2.Enabled = true;
                    break;
                case "بهمن":
                    month1.Text = "دی";
                    arrow1.Enabled = true;
                    arrow2.Enabled = true;
                    break;
                case "اسفند":
                    month1.Text = "بهمن";
                    arrow1.Enabled = true;
                    arrow2.Enabled = true;
                    break;
            }
        }
        catch
        {
           // ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('error', { title: 'خطا', img: '/Images/icon-error.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'کاربر گرامی ، سیستم دچار مشکل شده است ، لطفا مجددا تلاش کنید', delay: 20000 });", true);
        }


    }

    private void NextMonth(String mounth)
    {
        try
        {
            switch (mounth)
            {
                case "فروردین":
                    month1.Text = "اردیبهشت";
                    arrow1.Enabled = true;
                    arrow2.Enabled = true;
                    break;
                case "اردیبهشت":
                    month1.Text = "خرداد";
                    arrow1.Enabled = true;
                    arrow2.Enabled = true;
                    break;
                case "خرداد":
                    month1.Text = "تیر";
                    arrow1.Enabled = true;
                    arrow2.Enabled = true;
                    break;
                case "تیر":
                    month1.Text = "مرداد";
                    arrow1.Enabled = true;
                    arrow2.Enabled = true;
                    break;
                case "مرداد":
                    month1.Text = "شهریور";
                    arrow1.Enabled = true;
                    arrow2.Enabled = true;
                    break;
                case "شهریور":
                    month1.Text = "مهر";
                    arrow1.Enabled = true;
                    arrow2.Enabled = true;
                    break;
                case "مهر":
                    month1.Text = "آبان";
                    arrow1.Enabled = true;
                    arrow2.Enabled = true;
                    break;
                case "آبان":
                    month1.Text = "آذر";
                    arrow1.Enabled = true;
                    arrow2.Enabled = true;
                    break;
                case "آذر":
                    month1.Text = "دی";
                    arrow1.Enabled = true;
                    arrow2.Enabled = true;
                    break;
                case "دی":
                    month1.Text = "بهمن";
                    arrow1.Enabled = true;
                    arrow2.Enabled = true;
                    break;
                case "بهمن":
                    month1.Text = "اسفند";
                    arrow1.Enabled = true;
                    arrow2.Enabled = true;
                    break;
                case "اسفند":
                    arrow2.Enabled = false;
                    arrow1.Enabled = true;
                    break;
            }
        }
        catch
        {
          //  ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('error', { title: 'خطا', img: '/Images/icon-error.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'کاربر گرامی ، سیستم دچار مشکل شده است ، لطفا مجددا تلاش کنید', delay: 20000 });", true);
        }

    }

    protected void dropdown_SelectedIndexChanged(object sender, EventArgs e)
    {
        //lbl1.Text = dropdown.SelectedValue;
        setServiceDFDInfo();
    }


    private void setServiceTypeForDays()
    {
        try
        {
            UTLNumbers num = new UTLNumbers();
            DBAServices dba = new DBAServices();
            DateTime date = new DateTime();
            PersianCalendar pc = new PersianCalendar();
            DataTable dt = new DataTable();
            for (int i = 1; i <= 37; i++)
            {
                lst2.Items.Clear();

                CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                btn.Text = "";
                if (chk.Text != "")
                {
                    date = new DateTime(years, months, Convert.ToInt32(num.ToEnglishNumber(chk.Text)), pc);
                    dt = dba.getServiceTypeOfDays(date, Convert.ToInt32(Session["garden_id"]));
                    if (dt.Rows.Count > 0)
                    {
                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            lst2.Items.Clear();
                            lst2.Items.Add(dt.Rows[j]["ser_type"].ToString());
                            if (date == Convert.ToDateTime(date))
                            {
                                btn.Text = btn.Text + " " + lst2.Items[0].Text.Substring(0, 1);
                            }

                        }

                    }
                }

            }
        }
        catch
        {
         //   ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('error', { title: 'خطا', img: '/Images/icon-error.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'کاربر گرامی ، سیستم دچار مشکل شده است ، لطفا مجددا تلاش کنید', delay: 20000 });", true);
        }

    }

    protected void Button_Click(object sender, EventArgs e)
    {
        try
        {
            UTLNumbers num = new UTLNumbers();
            DateTime date = new DateTime();
            PersianCalendar pc = new PersianCalendar();
            for (int i = 1; i <= 37; i++)
            {
                CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                Button btn = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("Button" + i);
                if (chk.Text != "")
                {
                    date = new DateTime(years, months, Convert.ToInt32(num.ToEnglishNumber(chk.Text)), pc);
                }
                if (sender == btn)
                {
                    if (btn.Text != "")
                    {
                        Response.Redirect("ServiceDayDetails?date=" + date.Year + "-" + date.Month + "-" + date.Day);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('error', { title: 'خطا', img: '/Images/icon-error.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'کاربر گرامی ، هیچ سرویسی برای این روز ثبت نشده است', delay: 20000 });", true);
                    }
                }
            }
        }
        catch
        {
       //     ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('error', { title: 'خطا', img: '/Images/icon-error.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'کاربر گرامی ، سیستم دچار مشکل شده است ، لطفا مجددا تلاش کنید', delay: 20000 });", true);

        }


    }

    private void setServiceDFDInfo()
    {
        try
        {
            if (dropdown.SelectedValue != "")
            {
                DBAServices dba = new DBAServices();
                DataTable dt = new DataTable();
                dt = dba.getServiceDFDInfo(Convert.ToInt32(dropdown.SelectedValue));
                if (dt.Rows.Count == 1)
                {
                    sertype.Style.Add("display", "block");
                    serother.Style.Add("display", "block");
                    sercapacity.Style.Add("display", "block");
                    sereating.Style.Add("display", "block");
                    if (dt.Rows[0]["ser_type"].ToString() == "صبح")
                    {
                        txtsertype.Text = "صبح / صبحانه / قبل از ظهر";
                    }
                    else if (dt.Rows[0]["ser_type"].ToString() == "ظهر")
                    {
                        txtsertype.Text = "ظهر / ناهار";
                    }
                    else if (dt.Rows[0]["ser_type"].ToString() == "عصر")
                    {
                        txtsertype.Text = "عصر / عصرانه / بعد از ظهر";
                    }
                    else if (dt.Rows[0]["ser_type"].ToString() == "شب")
                    {
                        txtsertype.Text = "شب / شام";
                    }

                    txtcapacity.Text = dt.Rows[0]["capacity"].ToString();
                    txtsereating.Text = dt.Rows[0]["ser_eating"].ToString();
                    if (dt.Rows[0]["other_ser"].ToString() == "")
                    {
                        txtotherser.Text = "ثبت نشده است";
                    }
                    else
                    {
                        txtotherser.Text = dt.Rows[0]["other_ser"].ToString();
                    }
                    ser_type = dt.Rows[0]["ser_type"].ToString();
                    ser_capacity = Convert.ToInt32(dt.Rows[0]["capacity"].ToString());
                    ser_eating = dt.Rows[0]["ser_eating"].ToString();
                    ser_other = dt.Rows[0]["other_ser"].ToString();
                }
            }
            else
            {
                sertype.Style.Add("display", "none");
                serother.Style.Add("display", "none");
                sercapacity.Style.Add("display", "none");
                sereating.Style.Add("display", "none");
            }
        }
        catch
        {
          //  ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('error', { title: 'خطا', img: '/Images/icon-error.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'کاربر گرامی ، سیستم دچار مشکل شده است ، لطفا مجددا تلاش کنید', delay: 20000 });", true);
        }


    }


    private void addServiceDFDFinal()
    {
        try
        {
            if (lst.Items.Count != 0)
            {
                String result = "";

                Int32 garden_id = Convert.ToInt32(Session["garden_id"]);
                DBAServices dba = new DBAServices();
                for (int i = 0; i < lst.Items.Count; i++)
                {
                    date_ser = lst.Items[i].Text;
                    result = dba.addServiceDFDFinal(garden_id, ser_type, ser_capacity, ser_eating, ser_other, Convert.ToDateTime(lst.Items[i].Text));
                }
                if (result != "isExist")
                {
                    for (int i = 1; i <= 37; i++)
                    {
                        CheckBox chk = (CheckBox)Master.FindControl("ContentPlaceHolder1").FindControl("CheckBox" + i);
                        chk.Checked = false;
                    }
                    lst.Items.Clear();

                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('success', { title: 'عملیات موفقیت آمیز', img: '/Images/icon-success.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'کاربر گرامی ، تعریف روز های سرویس با موفقیت انجام شد', delay: 20000 });", true);

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('error', { title: 'خطا', img: '/Images/icon-error.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'کاربر گرامی ، قبلا سرویس " + ser_type + " برای تاریخ " + miladiToShamsi(date_ser) + " تعریف شده است', delay: 20000 });", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('error', { title: 'خطا', img: '/Images/icon-error.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'کاربر گرامی ، هیچ تاریخی انتخاب نشده است', delay: 20000 });", true);
            }
        }
        catch
        {
        //    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('error', { title: 'خطا', img: '/Images/icon-error.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'کاربر گرامی ، سیستم دچار مشکل شده است ، لطفا مجددا تلاش کنید', delay: 20000 });", true);

        }

    }

    protected void btnAddService_Click(object sender, EventArgs e)
    {
        addServiceDFDFinal();
        setServiceTypeForDays();
    }

    protected void nextYear_Click(object sender, EventArgs e)
    {
        try
        {
            PersianCalendar pr = new PersianCalendar();
            DateTime date = new DateTime();
            UTLNumbers num = new UTLNumbers();
            date = DateTime.Parse(DateTime.Now.ToShortDateString());
            if (lstYear.SelectedIndex < lstYear.Items.Count - 1)
            {
                lstYear.SelectedIndex += 1;
            }
            btnyear.Text = lstYear.Text;
            years = Convert.ToInt32(lstYear.Text);
            if (years == Convert.ToInt32(pr.GetYear(date)))
            {
                months = Convert.ToInt32(pr.GetMonth(date));
                DateTime dt = new DateTime(years, months, 1, pr);
                String dayofweek = pr.GetDayOfWeek(Convert.ToDateTime(dt.ToString(CultureInfo.InvariantCulture))).ToString();
                Boolean isleap = pr.IsLeapYear(years);
                setDays(dayofweek, isleap, months);
                setMonth(months);
                btnyear.Text = num.ToPersianNumber(years.ToString());
                changeDesableEnableCheckbox();
                setServices();
                setServiceTypeForDays();
                expireServiceDay();
            }
            else
            {
                month1.Text = "فروردین";
                selectMonth(month1.Text);
                DateTime dt = new DateTime(years, months, 1, pr);
                String dayofweek = pr.GetDayOfWeek(Convert.ToDateTime(dt.ToString(CultureInfo.InvariantCulture))).ToString();
                Boolean isleap = pr.IsLeapYear(years);
                setDays(dayofweek, isleap, months);
                setMonth(months);
                btnyear.Text = num.ToPersianNumber(years.ToString());
                changeDesableEnableCheckbox();
                setServices();
                setServiceTypeForDays();
                expireServiceDay();
            }
        }
        catch
        {
        //    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('error', { title: 'خطا', img: '/Images/icon-error.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'کاربر گرامی ، سیستم دچار مشکل شده است ، لطفا مجددا تلاش کنید', delay: 20000 });", true);
        }
    }

    protected void previusYear_Click(object sender, EventArgs e)
    {
        try
        {
            PersianCalendar pr = new PersianCalendar();
            DateTime date = new DateTime();
            UTLNumbers num = new UTLNumbers();
            date = DateTime.Parse(DateTime.Now.ToShortDateString());
            if (lstYear.SelectedIndex > 0)
            {
                lstYear.SelectedIndex -= 1;
            }
            btnyear.Text = lstYear.Text;
            years = Convert.ToInt32(lstYear.Text);
            if (years == Convert.ToInt32(pr.GetYear(date)))
            {
                months = Convert.ToInt32(pr.GetMonth(date));
                DateTime dt = new DateTime(years, months, 1, pr);
                String dayofweek = pr.GetDayOfWeek(Convert.ToDateTime(dt.ToString(CultureInfo.InvariantCulture))).ToString();
                Boolean isleap = pr.IsLeapYear(years);
                setDays(dayofweek, isleap, months);
                setMonth(months);
                btnyear.Text = num.ToPersianNumber(years.ToString());
                changeDesableEnableCheckbox();
                setServices();
                setServiceTypeForDays();
                expireServiceDay();
            }
            else
            {
                month1.Text = "فروردین";
                selectMonth(month1.Text);
                DateTime dt = new DateTime(years, months, 1, pr);
                String dayofweek = pr.GetDayOfWeek(Convert.ToDateTime(dt.ToString(CultureInfo.InvariantCulture))).ToString();
                Boolean isleap = pr.IsLeapYear(years);
                setDays(dayofweek, isleap, months);
                setMonth(months);
                btnyear.Text = num.ToPersianNumber(years.ToString());
                changeDesableEnableCheckbox();
                setServices();
                setServiceTypeForDays();
                expireServiceDay();
            }
        }
        catch
        {
          //  ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('error', { title: 'خطا', img: '/Images/icon-error.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'کاربر گرامی ، سیستم دچار مشکل شده است ، لطفا مجددا تلاش کنید', delay: 20000 });", true);
        }
    }

    //private void enableBtn()
    //{
    //    PersianCalendar pr = new PersianCalendar();
    //    DateTime date = new DateTime();
    //    UTLNumbers num = new UTLNumbers();
    //    date = DateTime.Parse(DateTime.Now.ToShortDateString());
    //    for(int i = 1; i <= 37; i++)
    //    {

    //    }
    //}
}