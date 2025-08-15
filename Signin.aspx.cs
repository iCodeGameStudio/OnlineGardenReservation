using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Signin : System.Web.UI.Page
{
    private void loginCheck()
    {
        if(Session["member_id"] != null && Session["member_id"].ToString() != "")
        {
            Response.Redirect("~/MemberReservations");
        }
    }
    private void signinCheck()
    {
        String username = txtmobile.Text.Trim();
        String password = txtpass.Text.Trim();
        DBAMembers dba = new DBAMembers();
        String result = dba.loginCheck(username, password);
        if(result == "notExist")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('error', { title: 'خطا', img: '/Images/icon-error.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'کاربر گرامی ، نام کاربری یا گذرواژه معتبر نمی باشد', delay: 20000 });", true);
        }else
        {
            Session["member_id"] = result;
            Response.Redirect("~/");
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        loginCheck();
    }

    protected void btnsign_Click(object sender, EventArgs e)
    {
        signinCheck();
    }

    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    UTLSmsIr sms = new UTLSmsIr();
    //    sms.MessageSend();
    //}
}