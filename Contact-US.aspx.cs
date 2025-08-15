using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Contact_US : System.Web.UI.Page
{
    private void contactUS()
    {
        String name = txtname.Text.Trim();
        String email = txtemail.Text.Trim();
        String message = txtmessage.Text.Trim();
        String subject = txtsubject.Text.Trim();
        DBAContact dba = new DBAContact();
        dba.contactUS(name, email, subject, message);
        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('success', { title: 'عملیات موفقیت آمیز', img: '/Images/icon-success.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'کاربر گرامی ، پیام شما با موفقیت برای مدیریت ارسال شد', delay: 20000 });", true);
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        contactUS();
    }
}