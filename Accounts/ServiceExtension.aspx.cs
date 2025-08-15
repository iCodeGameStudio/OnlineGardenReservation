using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
public partial class Accounts_ServiceExtension : System.Web.UI.Page
{
    private void setPageTree()
    {
        ((HtmlGenericControl)Page.Master.FindControl("treepage")).InnerHtml = "<li><a href='AccountHome'><i class='fa fa-dashboard'></i>خانه</a></li>   <li class='active'>تمدید سرویس</li>";
    }
    private void setTitle()
    {
        ((HtmlGenericControl)Page.Master.FindControl("htitle")).InnerHtml = "تمدید سرویس" + "<small>شما می توانید از این قسمت یک سرویس را انتخاب و خریداری کنید</small>";
    }
    private void setActivateItemMenu()
    {
        ((HtmlGenericControl)Page.Master.FindControl("service")).Attributes["class"] = "active";
    }
    private void checkLogin()
    {
        if (Session["garden_id"] == null || Session["garden_id"].ToString() == "")
        {
            Response.Redirect("~/");
        }
    }

    private void setPeriods()
    {
        DBAServices dba = new DBAServices();
        GridView1.DataSource = dba.getServices();
        GridView1.DataBind();
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        checkLogin();
        setPageTree();
        setTitle();
        setActivateItemMenu();
        if (!Page.IsPostBack)
            setPeriods();
    }

    public String ToFarsi(String number)
    {
        UTLNumbers num = new UTLNumbers();
        return num.ToPersianNumber(number);
    }

}