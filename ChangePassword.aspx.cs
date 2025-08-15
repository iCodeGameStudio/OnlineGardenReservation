using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class ChangePassword : System.Web.UI.Page
{
    private void setTitle()
    {
        ((HtmlGenericControl)Page.Master.FindControl("htitle")).InnerHtml = "تغییر گذرواژه";
    }

    private void changePassword()
    {
        Int32 id = Convert.ToInt32(Session["member_id"]);
        String old_password = txtoldpass.Text.Trim();
        String new_password = txtnewpass.Text.Trim();
        String conf_password = txtconfpass.Text.Trim();
        if (new_password == conf_password)
        {
            DBAMembers dba = new DBAMembers();
            String result = dba.changePassword(id, old_password, new_password);
            if (result == "NotExist")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('error', { title: 'اخطار', img: '/Images/icon-error.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'کاربر گرامی ، گذرواژه فعلی صحیح نیست.', delay: 10000 });", true);
            }
            else
            {
                Session["member_id"] = "";
                Session["member_id"] = null;
                Response.Redirect("~/Result?link=Password-is-Changed");
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('error', { title: 'اخطار', img: '/Images/icon-error.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'کاربر گرامی ، گذرواژه جدید و تأیید گذرواژه مطابقت ندارند.', delay: 10000 });", true);
        }
    }

    private void checkLogin()
    {
        if (Session["member_id"] == null || Session["member_id"].ToString() == "")
        {
            Response.Redirect("~/");
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        setTitle();
        if (!Page.IsPostBack)
        {
            checkLogin();
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('warning', { title: 'هشدار', img: '/Images/icon-warning.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'کاربر گرامی ، پس از تغییر گذرواژه باید مجددا به حساب کاربری خود وارد شوید.', delay: 20000 });", true);
        }
    }

    protected void btnchangepass_Click(object sender, EventArgs e)
    {
        changePassword();
    }
}