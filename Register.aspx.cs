using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        String name = "";
        String mobile = "";
        String password = "";
        if(txtpassword.Text.Trim() == txtconfpassword.Text.Trim())
        {
            name = txtname.Text.Trim();
            mobile = txtmobile.Text.Trim();
            password = txtpassword.Text.Trim();
            DBAMembers dba = new DBAMembers();
            String result = dba.addMember(name, mobile, password);
            if(result == "success")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('success', { title: 'عملیات موفقیت آمیز', img: '/Images/icon-success.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'کاربر گرامی ، عضویت شما با موفقیت انجام شد ، اکنون می توانید وارد شوید', delay: 20000 });", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('error', { title: 'خطا', img: '/Images/icon-error.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'کاربر گرامی ، قبلا با این تلفن همراه یک حساب کاربری ایجاد شده است', delay: 20000 });", true);
            }
        }else
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('error', { title: 'خطا', img: '/Images/icon-error.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'کاربر گرامی ، گذرواژه و تأیید گذرواژه یکسان نیستند', delay: 20000 });", true);
        }
    }
}