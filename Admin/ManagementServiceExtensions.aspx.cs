using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
public partial class Admin_ManagementServiceExtension : System.Web.UI.Page
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
        ((HtmlGenericControl)Page.Master.FindControl("treepage")).InnerHtml = "<li><a href='ManagementHome'><i class='fa fa-dashboard'></i>خانه</a></li>   <li class='active'>سرویس ها</li>";
    }
    private void setTitle()
    {
        ((HtmlGenericControl)Page.Master.FindControl("htitle")).InnerHtml = "سرویس ها" + "<small>تعریف سرویس جدید و لیست سرویس ها</small>";
    }
    private void setActivateItemMenu()
    {
        ((HtmlGenericControl)Page.Master.FindControl("service")).Attributes["class"] = "active";
    }
    private void validation()
    {
        //برای مدت زمان سرویس
        if (RequiredFieldValidator1.IsValid == false || RegularExpressionValidator1.IsValid == false)
        {
            txtmounth.BorderColor = System.Drawing.Color.Red;
        }
        else
        {
            txtmounth.BorderColor = System.Drawing.Color.LightGray;
        }

        //برای مبلغ
        if (RequiredFieldValidator2.IsValid == false || RegularExpressionValidator2.IsValid == false)
        {
            txtcost.BorderColor = System.Drawing.Color.Red;
        }
        else
        {
            txtcost.BorderColor = System.Drawing.Color.LightGray;
        }

    }

    protected void btnaddservice_Click(object sender, EventArgs e)
    {
        validation();
        if (RequiredFieldValidator1.IsValid == true &&
            RequiredFieldValidator2.IsValid == true &&
            RegularExpressionValidator1.IsValid == true &&
            RegularExpressionValidator2.IsValid == true)
        {
            addService();
            setServices();
        }
    }

    private void addService()
    {
        Int32 period = Convert.ToInt32(txtmounth.Text.Trim());
        Int32 cost = Convert.ToInt32(txtcost.Text.Trim());
        DBAServices dba = new DBAServices();
        String result = dba.addService(period, cost);
        if (result == "exist")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('error', { title: 'خطا', img: '/Images/icon-error.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'مدیریت محترم ، این سرویس قبلا تعریف شده است', delay: 20000 });", true);
        }
        else
        {
            txtcost.Text = "";
            txtmounth.Text = "";
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('success', { title: 'عملیات موفقیت آمیز', img: '/Images/icon-success.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'مدیریت محترم ، سرویس مورد نظر با موفقیت ثبت شد', delay: 20000 });", true);
        }
    }

    private void setServices()
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
        {
            setServices();
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DBAServices dba = new DBAServices();
        Int32 id = Int32.Parse(e.CommandArgument.ToString());
        String command = e.CommandName.ToString();
        if (command == "remove")
        {
            dba.removeService(id);
            setServices();
        }
    }

    public String ToFarsi(String number)
    {
        UTLNumbers num = new UTLNumbers();
        return num.ToPersianNumber(number);
    }

}