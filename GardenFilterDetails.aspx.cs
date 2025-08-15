using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
public partial class GardenFilterDetails : System.Web.UI.Page
{
    String garden_id;
    String service_final_id;
    Int32 member_id;
    //=====================================
    String rez_ser_type;
    String rez_ser_eating;
    String rez_other_ser;
    String rez_date;
    String rez_capacity;
    //==================================

    private void loginCheckMember()
    {
        if (Session["member_id"] != null && Session["member_id"].ToString() != "")
        {
            member_id = Convert.ToInt32(Session["member_id"].ToString());
        }
        else
        {
            Response.Redirect("~/Signin");
        }
    }

    private void setImages()
    {
        DBAGardens dba = new DBAGardens();
        Repeater1.DataSource = dba.getGardenInfo(garden_id);
        Repeater1.DataBind();
        Repeater2.DataSource = dba.getGardenInfo(garden_id);
        Repeater2.DataBind();
    }

    private void setGardenInfo()
    {
        DBAGardens dba = new DBAGardens();
        DataTable dt = dba.getGardenInfo(garden_id);
        if (dt.Rows.Count > 0)
        {
            spanname.InnerText = dt.Rows[0]["garden_name"].ToString();
            spancapacity.InnerText = dt.Rows[0]["capacity"].ToString() + " نفر";
            spantype.InnerText = dt.Rows[0]["type"].ToString();
            spantel.InnerText = dt.Rows[0]["tel"].ToString();
            txtpossibilities.Text = dt.Rows[0]["possibilities"].ToString();
            txtaddress.Text = dt.Rows[0]["address"].ToString();  
        }
        else
            Response.Redirect("~/");
    }

    private void setServiceInfo()
    {
        DBAServices dba = new DBAServices();
        DataTable dt = dba.getServiceDFDFinalInfo(Convert.ToInt32(service_final_id));
        if (dt.Rows.Count > 0)
        {
            if (dt.Rows[0]["ser_type"].ToString() == "صبح")
                txtser_type.InnerText = "صبح / صبحانه";
            else if(dt.Rows[0]["ser_type"].ToString() == "ظهر")
                txtser_type.InnerText = "ظهر / ناهار";
            else if (dt.Rows[0]["ser_type"].ToString() == "عصر")
                txtser_type.InnerText = "عصر / عصرانه";
            else
                txtser_type.InnerText = "شب / شام";

            txtcapacity.InnerText = dt.Rows[0]["capacity"].ToString() + " نفر";
            txtser_eating.InnerText = dt.Rows[0]["ser_eating"].ToString();
            if (dt.Rows[0]["other_ser"].ToString() == "")
            {
                txtotherser.InnerText = "(چیزی ثبت نشده)";
                txtotherser.Attributes.Add("style", "color:red");
            }
            else
            {
                txtotherser.InnerText = dt.Rows[0]["other_ser"].ToString();
            }
            txtdate.InnerText = miladiToShamsi(dt.Rows[0]["date"].ToString());
            rez_ser_type = dt.Rows[0]["ser_type"].ToString();
            rez_capacity = dt.Rows[0]["capacity"].ToString();
            rez_ser_eating = dt.Rows[0]["ser_eating"].ToString();
            rez_other_ser = dt.Rows[0]["other_ser"].ToString();
            rez_date = dt.Rows[0]["date"].ToString();           
        }
        else
            Response.Redirect("~/");
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            garden_id = Request.QueryString["gid"].ToString();
            service_final_id = Request.QueryString["sid"].ToString();
            setGardenInfo();
            setServiceInfo();
            setImages();
        }
        catch
        {
            garden_id = "";
            service_final_id = "";
        }

        if (garden_id == "" && service_final_id == "" || garden_id == null && service_final_id == null)
        {
            Response.Redirect("~/");
        }
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

    private void addReserve()
    {
        DBAReserves dba = new DBAReserves();
        dba.addReserve(member_id, Convert.ToInt32(garden_id), rez_ser_type, rez_ser_eating, rez_other_ser, Convert.ToInt32(rez_capacity), Convert.ToDateTime(rez_date));
        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('success', { title: 'عملیات موفقیت آمیز', img: '/Images/icon-success.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'کاربر گرامی ، سرویس مورد نظر به لیست رزرو های شما اضافه گردید', delay: 20000 });", true);
    }

    protected void btnReserve_Click(object sender, EventArgs e)
    {

        loginCheckMember();
        String diff_date = (Convert.ToDateTime(rez_date) - Convert.ToDateTime(DateTime.Today.ToShortDateString())).TotalDays.ToString();
        if (Convert.ToInt32(diff_date) < 0)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('error', { title: 'خطا', img: '/Images/icon-error.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'کاربر گرامی ، تاریخ ارائه این سرویس منقضی شده است ، لطفا سرویس بروز را انتخاب کنید', delay: 20000 });", true);
        }
        else
        {
            addReserve();
        }
        
    }
}