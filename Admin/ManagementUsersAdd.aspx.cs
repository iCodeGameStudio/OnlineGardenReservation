using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.IO;
public partial class Admin_ManagementChangePassword : System.Web.UI.Page
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
        ((HtmlGenericControl)Page.Master.FindControl("treepage")).InnerHtml = "<li><a href='ManagementHome'><i class='fa fa-dashboard'></i>خانه</a></li>   <li><a href='ManagementUsers'><i class='fa fa-users'></i>مدیران</a></li>   <li class='active'>تعریف مدیر جدید</li>";
    }
    private void setTitle()
    {
        ((HtmlGenericControl)Page.Master.FindControl("htitle")).InnerHtml = "تعریف مدیر جدید" + "<small>تعریف مدیر جدید به همراه تعیین سطح دسترسی</small>";
    }
    private void setActivateItemMenu()
    {
        ((HtmlGenericControl)Page.Master.FindControl("users")).Attributes["class"] = "active";
    }
    private void addUser()
    {
        String name = txtname.Text.Trim();
        String family = txtfamily.Text.Trim();
        String melicode = txtmelicode.Text.Trim();
        String mobile = txtmobile.Text.Trim();
        String email = txtmail.Text.Trim();
        Int32 access;
        if (rd1.Checked == true)
        {
            access = 1;
        }
        else
        {
            access = 2;
        }
        DBAUsers dba = new DBAUsers();
        String result = dba.addUser(name, family, melicode, mobile, email, access);
        if (result == "account is exist")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('error', { title: 'خطا', img: '/Images/icon-error.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'مدیریت محترم ، قبلا با این ایمیل یا کد ملی یک حساب کاربری ایجاد شده است', delay: 20000 });", true);
        }
        if (result == "successfuly")
        {
            txtname.Text = "";
            txtfamily.Text = "";
            txtmelicode.Text = "";
            txtmail.Text = "";
            txtmobile.Text = "";
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('success', { title: 'عملیات موفقیت آمیز', img: '/Images/icon-success.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'مدیریت محترم ، تعریف مدیر جدید با موفقیت انجام شد', delay: 20000 });", true);

        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        checkLogin();
        setPageTree();
        setTitle();
        setActivateItemMenu();
        //setInfo();
    }

    protected void btnchangepass_Click(object sender, EventArgs e)
    {
        addUser();
    }
}