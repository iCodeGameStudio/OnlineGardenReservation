using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;

public partial class Accounts_ServicesShoppingCard : System.Web.UI.Page
{
    String service_id;
    Int32 cost;
    Int32 period;

    private void setPageTree()
    {
        ((HtmlGenericControl)Page.Master.FindControl("treepage")).InnerHtml = "<li><a href='AccountHome'><i class='fa fa-dashboard'></i>خانه</a></li>   <li><a href='ServiceExtension'><i></i>تمدید سرویس</a></li>   <li class='active'>پرداخت نهایی</li>";
    }

    private void setTitle()
    {
        ((HtmlGenericControl)Page.Master.FindControl("htitle")).InnerHtml = "فرم نهایی خرید سرویس";
    }
    private void setActivateItemMenu()
    {
        ((HtmlGenericControl)Page.Master.FindControl("service")).Attributes["class"] = "active";
    }

    private void setCost()
    {
        Int32 garden_id = Convert.ToInt32(Session["garden_id"]);
        DBAServices dba = new DBAServices();
        txtcost.Text = ToFarsi(dba.getCost(garden_id).ToString()) + " تومان";
    }


    private void loginCheck()
    {
        if (Session["garden_id"] == null || Session["garden_id"].ToString() == "")
        {
            Response.Redirect("~/");
        }
    }


    //private void setShoppingCard()
    //{
    //    Int32 garden_id = Convert.ToInt32(Session["garden_id"]);
    //    DBAServices dba = new DBAServices();
    //    GridView1.DataSource = dba.getShoppingCard(garden_id);
    //    GridView1.DataBind();
    //}

    private void setServiceInfo()
    {
        DBAServices dba = new DBAServices();
        DataTable dt = dba.getServiceInfo(Convert.ToInt32(service_id));
        if (dt.Rows.Count == 1)
        {
            txtservice.Text = ToFarsi(dt.Rows[0]["period"].ToString()) + " ماهه";
            txtcost.Text = ToFarsi(dt.Rows[0]["cost"].ToString()) + " تومان";
            period = Convert.ToInt32(dt.Rows[0]["period"].ToString());
        }
        else
            Response.Redirect("ServiceExtention");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        loginCheck();
        setPageTree();
        setTitle();
        setActivateItemMenu();
        try
        {
            service_id = Request.QueryString["id"].ToString();
            Int32.Parse(service_id);
        }
        catch
        {
            service_id = "";
        }

        if (service_id == "")
        {
            Response.Redirect("ServiceExtention");
        }

        setServiceInfo();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        loginCheck();
        Int32 garden_id = Convert.ToInt32(Session["garden_id"]);
        DBAServices dba = new DBAServices();
        Int32 cost = Convert.ToInt32(dba.getCost(Convert.ToInt32(service_id)));       
        Int32 factor_id = dba.addServiceFactor(garden_id,Convert.ToInt32(service_id), cost, period);
        DBAPaymentsZarinPal dbapayment = new DBAPaymentsZarinPal();
        String result = dbapayment.payment(garden_id.ToString(), factor_id.ToString(), cost, "فاکتور شماره " + factor_id,period);
        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('error', { title: 'خطا', img: '/Images/icon-error.png',soundExt: '.ogg', soundPath: '/Media/', msg: " + result + ", delay: 10000 });", true);

    }
    public String ToFarsi(String number)
    {
        UTLNumbers num = new UTLNumbers();
        return num.ToPersianNumber(number);
    }
}