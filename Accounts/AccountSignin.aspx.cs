using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Net.Mail;
using System.Configuration;
using System.IO;
using System.Net;

public partial class Accounts_AccountSignin : System.Web.UI.Page
{
    Guid guid = Guid.NewGuid();
    Int32 garden_id;

    private void emailCheck()
    {
        DBAGardens dba = new DBAGardens();
        String email = txtemailrecovery.Text.Trim();
        String result = dba.emailCheckGarden(email);
        if (result == "NotExist")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('error', { title: 'خطا', img: '/Images/icon-error.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'کاربر گرامی ، آدرس ایمیل وارد شده معتبر نمی باشد', delay: 10000 });", true);
        }
        else
        {
            garden_id = Convert.ToInt32(result);
            setFarget(email, guid.ToString());
            sendEmail(email);
            Response.Redirect("~/Result?link=forget-password-account-successful");
        }
    }


    private void setFarget(String email, String guid)
    {
        DBAGardens dba = new DBAGardens();
        dba.setForget(garden_id, email, guid);
    }

    private void sendEmail(String email)
    {
        String body = this.PopulateBody(DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString(), garden_id.ToString(), email, guid.ToString());
        this.SendHtmlFormattedEmail(email, "باغبون :: بازیابی گذرواژه", body);
    }

    private String PopulateBody(String date, String time, String id, String email, String guid)
    {
        String body = String.Empty;
        using (StreamReader reader = new StreamReader(Server.MapPath("~/App_Data/Templates/EmailTemplate.txt")))
        {
            body = reader.ReadToEnd();
        }
        body = body.Replace("{directory}", "Accounts");
        body = body.Replace("{date_send}", date);
        body = body.Replace("{time_send}", time);
        body = body.Replace("{mail}", email);
        body = body.Replace("{id}", garden_id.ToString());
        body = body.Replace("{guid}", guid);
        return body;
    }

    private void SendHtmlFormattedEmail(string recepientEmail, string subject, string body)
    {
        try
        {
            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["UserName"]);
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(new MailAddress(recepientEmail));
                SmtpClient smtp = new SmtpClient();
                smtp.Host = ConfigurationManager.AppSettings["Host"];
                smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = ConfigurationManager.AppSettings["UserName"];
                NetworkCred.Password = ConfigurationManager.AppSettings["Password"];
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = int.Parse(ConfigurationManager.AppSettings["Port"]);
                smtp.Send(mailMessage);
            }
        }
        catch
        {

        }

    }

    private void checkLogin()
    {
        if (Session["garden_id"] != null && Session["garden_id"].ToString() != "")
        {
            Response.Redirect("~/Accounts/AccountHome");
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        checkLogin();
    }

    private void signIn()
    {
        DBAGardens dba = new DBAGardens();
        String username = txtemail.Text.Trim();
        String password = txtpass.Text.Trim();
        String result = dba.loginCheck(username, password);
        if (result == "NotExist")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('error', { title: 'خطا', img: '/Images/icon-error.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'کاربر گرامی ، نام کاربری یا گذرواژه صحیح نیست', delay: 10000 });", true);
        }
        else
        {
            String active = dba.activeCheck(Convert.ToInt32(result));
            if (active == "not accept")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('warning', { title: 'هشدار', img: '/Images/icon-warning.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'کاربر گرامی  ، حساب کاربری شما هنوز توسط مدیریت فعال نشده است ، لطفا شکیبا باشید', delay: 20000 });", true);
            }
            else if (active == "failed")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('error', { title: 'خطا', img: '/Images/icon-error.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'کاربر گرامی ، درخواست شما برای ثبت نام در سایت پذیرفته نشده است', delay: 10000 });", true);
            }
            else if (active == "taligh")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('error', { title: 'خطا', img: '/Images/icon-error.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'کاربر گرامی ، درخواست ثبت نام شما به صورت تعلیق در آمده است', delay: 10000 });", true);
            }
            else
            {
                Guid guid_code = Guid.NewGuid();
                Session["garden_id"] = result;
                Session["guid_code"] = guid_code.ToString();
                setLogs();
                Session.Timeout = 120;
                Response.Redirect("~/Accounts/AccountHome");
            }
        }

   } 

    private void setLogs()
    {
        Int32 garden_id = Convert.ToInt32(Session["garden_id"]);
        String guid_code = Session["guid_code"].ToString();
        DateTime login_date = Convert.ToDateTime(DateTime.Today.ToLongDateString());
        String login_time = DateTime.Now.ToLocalTime().ToLongTimeString();
        DBAGardens dba = new DBAGardens();
        dba.setLog(garden_id, login_date, login_time, guid_code);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        signIn();
    }
    protected void btnrecovery_Click(object sender, EventArgs e)
    {
        emailCheck();
    }
}