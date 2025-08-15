using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Globalization;
public partial class _Default : System.Web.UI.Page
{
    static String ser_type = "";
    static String type = "";
    static String city = "";
    static String TY = "";
    static String ST = "";
    static String dat = "";
    //============================
    static String command_city = "";
    static String command_type = "";
    static String command_ser = "";
    static String command_date = "";
    static DateTime date;
    private void setGardens()
    {
        DBAGardens dba = new DBAGardens();
        Repeater1.DataSource = dba.getGardens();
        Repeater1.DataBind();
    }

    private void setGardensFilter()
    {
        if (city != "")
        {
            command_city = "city = N'" + city + "' AND ";
        }
        else
        {
            command_city = "city like '%%' AND ";
        }
        if (TY != "")
        {
            try
            {
                command_type = "type = N'" + TY.Replace('-', ' ') + "' AND ";
            }
            catch
            {

            }

        }
        else
        {
            command_type = "type like '%%' AND ";
        }
        if (ST != "")
        {
            command_ser = "ser_type = N'" + ST + "'";
        }
        else
        {
            command_ser = "ser_type like '%%'";
        }
        if(dat != "")
        {
            command_date = " AND t_services_dfd_final.date = CONVERT(varchar, '" + date.ToShortDateString() + "', 25)";
        }
        else
        {
            command_date = "";
        }
        
        if (city != "" || TY != "" || ST != "" || dat != "")
        {
            DBAGardens dba = new DBAGardens();
            Repeater2.DataSource = dba.getFilterGardens(command_city, command_type, command_ser , command_date);
            Repeater2.DataBind();
            garden_filter.Attributes.Add("style", "display:block;margin-top:-380px;");
            gardens.Attributes.Add("style", "display:none;");
            divme.Attributes.Add("style", "display:none;");
            myslideshow.Attributes.Add("style", "display:none");
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        UTLNumbers num = new UTLNumbers();
        try
        {
            city = Request.QueryString["City"];
            TY = Request.QueryString["TY"];
            ST = Request.QueryString["ST"];
            dat = Request.QueryString["Date"];

            PersianCalendar pc = new PersianCalendar();         
            DateTime dt = DateTime.Parse(dat, CultureInfo.InvariantCulture);
            dt = new DateTime(dt.Year, dt.Month, dt.Day, pc);
            date =  Convert.ToDateTime(dt.ToString(CultureInfo.InvariantCulture));
            if (!Page.IsPostBack)
            {
                DropDownList1.SelectedValue = type.Replace('-', ' ');
                DropDownList2.SelectedValue = ser_type;
                Textbox1.Text = dat;
            }

        }
        catch
        {

        }
        if (!Page.IsPostBack)
        {
            if (TY == null)
            {
                DropDownList1.SelectedIndex = 0;
            }
            if (ST == null)
            {
                DropDownList2.SelectedIndex = 0;
            }
        }
        if (city != null || TY != null || ST != null || dat != null)
        {
            setGardensFilter();
        }
        if (city == null && TY == null && ST == null && dat == null || city == "" && TY == "" && ST == "" && dat == "")
        {
            garden_filter.Attributes.Add("style", "display:none;");
            gardens.Attributes.Add("style", "display:block;");
            divme.Attributes.Add("style", "display:block;");
            myslideshow.Attributes.Add("style", "display:block");
            setGardens();
        }

    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        UTLNumbers num = new UTLNumbers();
        ser_type = DropDownList2.SelectedValue;
        type = DropDownList1.SelectedValue;
        String number_english = num.ToEnglishNumber(Textbox1.Text);
        try
        {
            city = Request.QueryString["City"];
            Response.Redirect("~/?City=" + city + "&ST=" + ser_type + "&TY=" + type.Replace(' ', '-') + "&Date=" + number_english);
            ser_type = "";
            type = "";
        }
        catch
        {

        }

    }

    public String persianNum(String number)
    {
        UTLNumbers num = new UTLNumbers();
        return num.ToPersianNumber(number);
    }

}