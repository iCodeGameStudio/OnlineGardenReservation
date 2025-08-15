using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Globalization;


public partial class Accounts_ServicesAdd : System.Web.UI.Page
{
    private void setPageTree()
    {
        ((HtmlGenericControl)Page.Master.FindControl("treepage")).InnerHtml = "<li><a href='AccountHome'><i class='fa fa-dashboard'></i>خانه</a></li>   <li class='active'>تعریف سرویس پیشفرض</li>";
    }

    private void setTitle()
    {
        ((HtmlGenericControl)Page.Master.FindControl("htitle")).InnerHtml = "تعریف سرویس به صورت پیشفرض";
    }
    private void setActivateItemMenu()
    {
        ((HtmlGenericControl)Page.Master.FindControl("servicesAdd")).Attributes["class"] = "active";
        ((HtmlGenericControl)Page.Master.FindControl("serviceDefault")).Attributes["class"] = "active";       
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        checkLogin();
        setTitle();
        setActivateItemMenu();
        setPageTree();
        if (!Page.IsPostBack)
            setServices();
    }

    private void checkLogin()
    {
        if (Session["garden_id"] == null || Session["garden_id"].ToString() == "")
        {
            Response.Redirect("~/");
        }
    }

    protected void btnaddservice_Click(object sender, EventArgs e)
    {
        addService();
    }

    private void addService()
    {
        UTLNumbers num = new UTLNumbers();
        DBAServices dba = new DBAServices();
        Int32 garden_id = Convert.ToInt32(Session["garden_id"]);
        String ser_type = dropdown.SelectedValue;
        Int32 capacity = Convert.ToInt32(txtcapacity.Text);
        String ser_eating = txteating.Text;
        String other_service = txtotherservice.Text;
        DateTime date = new DateTime();
        date = DateTime.Today.Date;
        dba.addServiceDFDGardens(garden_id, ser_type, capacity, ser_eating, other_service, date);
        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('success', { title: 'عملیات موفقیت آمیز', img: '/Images/icon-success.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'کاربر گرامی ، تعریف سرویس با موفقیت انجام شد', delay: 20000 });", true);
        setServices();
        dropdown.SelectedIndex = 0;
        txtcapacity.Text = "";
        txteating.Text = "";
        txtotherservice.Text = "";
    }

    private void setServices()
    {
        Int32 garden_id = Convert.ToInt32(Session["garden_id"]);
        DBAServices dba = new DBAServices();
        GridView1.DataSource = dba.getServicesDFD(garden_id);
        GridView1.DataBind();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DBAServices dba = new DBAServices();
        Int32 id = Int32.Parse(e.CommandArgument.ToString());
        String command = e.CommandName.ToString();
        if (command == "remove")
        {
            dba.removeServiceDFD(id);
            setServices();
        }
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
}