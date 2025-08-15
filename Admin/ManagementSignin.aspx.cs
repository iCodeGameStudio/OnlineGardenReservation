using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Configuration;
using System.IO;
public partial class Admin_ManagementSignin : System.Web.UI.Page
{

    Guid guid = Guid.NewGuid();
    Int32 user_id;

    private void emailCheck()
    {
        DBAUsers dba = new DBAUsers();
        String email = txtemailrecovery.Text.Trim();
        String result = dba.emailCheckUser(email);
        if (result == "NotExist")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('error', { title: 'خطا', img: '/Images/icon-error.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'مدیر گرامی ، آدرس ایمیل وارد شده معتبر نمی باشد', delay: 10000 });", true);
        }
        else
        {
            user_id = Convert.ToInt32(result);
            setFarget(email, guid.ToString());
            sendEmail(email);
            Response.Redirect("~/Result?link=forget-password-manager-successful");

        }
    }


    private void setFarget(String email, String guid)
    {
        DBAUsers dba = new DBAUsers();
        dba.setForget(user_id, email, guid);
    }

    private void sendEmail(String email)
    {
        String body = this.PopulateBody(DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString(), user_id.ToString(), email, guid.ToString());
        this.SendHtmlFormattedEmail(email, "باغبون :: بازیابی گذرواژه", body);
    }

    private String PopulateBody(String date, String time, String id, String email, String guid)
    {
        String body = String.Empty;
        using (StreamReader reader = new StreamReader(Server.MapPath("~/App_Data/Templates/EmailTemplate.txt")))
        {
            body = reader.ReadToEnd();
        }
        body = body.Replace("{directory}", "Admin");
        body = body.Replace("{date_send}", date);
        body = body.Replace("{time_send}", time);
        body = body.Replace("{mail}", email);
        body = body.Replace("{id}", user_id.ToString());
        body = body.Replace("{guid}", guid);
        return body;
    }

    private void SendHtmlFormattedEmail(string recepientEmail, string subject, string body)
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

    private void checkLogin()
    {
        if (Session["user_id"] != null && Session["user_id"].ToString() != "")
        {
            Response.Redirect("ManagementRequestSignin");
        }
    }

    private void signIn()
    {
        DBAUsers dba = new DBAUsers();
        String username = txtemail.Text.Trim();
        String password = txtpass.Text.Trim();
        String result = dba.loginCheck(username, password);
        if (result == "NotExist")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('error', { title: 'خطا', img: '/Images/icon-error.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'کاربر گرامی ، نام کاربری یا گذرواژه صحیح نیست', delay: 10000 });", true);
        }
        else
        {
            String availability = dba.checkAvailability(Convert.ToInt32(result));
            if (availability == "unblock")
            {
                Session["user_id"] = result;
                Session.Timeout = 120;
                dba.changeLastAndCountLogin(Convert.ToInt32(Session["user_id"]));
                Response.Redirect("ManagementHome");
            }
            else if (availability == "block")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('error', { title: 'خطا', img: '/Images/icon-error.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'مدیریت محترم ، به دلیل مسائل امنیتی ، اجازه ورود به قسمت مدیریت را ندارید', delay: 10000 });", true);
                Session["user_id"] = "";
                Session["user_id"] = null;
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        checkLogin();
    }

    protected void btnlogin_Click(object sender, EventArgs e)
    {
        signIn();
    }
    protected void btnrecovery_Click(object sender, EventArgs e)
    {
        emailCheck();
    }
}