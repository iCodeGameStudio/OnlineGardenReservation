using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.IO;
using System.Configuration;
using System.Net.Mail;
public partial class Admin_ManagementChangePassword : System.Web.UI.Page
{
    private void setPageTree()
    {
        ((HtmlGenericControl)Page.Master.FindControl("treepage")).InnerHtml = "<li><a href='ManagementHome'><i class='fa fa-dashboard'></i>خانه</a></li><li class='active'>تغییر گذرواژه</li>";
    }

    private void setTitle()
    {
        ((HtmlGenericControl)Page.Master.FindControl("htitle")).InnerHtml = "تغییر گذرواژه";
    }
    private void checkLogin()
    {
        if (Session["user_id"] == null || Session["user_id"].ToString() == "")
        {
            Response.Redirect("~/");
        }
    }
    private void changePassword()
    {
        String email = "";
        DBAUsers dbaget = new DBAUsers();
        DataTable dt = dbaget.getUserInfo(Convert.ToInt32(Session["user_id"]));
        if (dt.Rows.Count == 1)
        {
            email = dt.Rows[0]["email"].ToString();
        }

        Int32 id = Convert.ToInt32(Session["user_id"]);
        String old_password = txtoldpass.Text.Trim();
        String new_password = txtnewpass.Text.Trim();
        String conf_password = txtconfpass.Text.Trim();
        if (new_password == conf_password)
        {
            DBAUsers dba = new DBAUsers();
            String result = dba.changePassword(id, old_password, new_password);
            if (result == "NotExist")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('error', { title: 'اخطار', img: '/Images/icon-error.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'کاربر گرامی ، گذرواژه فعلی صحیح نیست.', delay: 10000 });", true);
            }
            else
            {
                sendMail(email);
                Session["user_id"] = "";
                Session["user_id"] = null;
                Response.Redirect("~/Result?link=Password-is-Changed-Management");
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('error', { title: 'اخطار', img: '/Images/icon-error.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'کاربر گرامی ، گذرواژه جدید و تأیید گذرواژه مطابقت ندارند.', delay: 10000 });", true);
        }
    }

    private void sendMail(String email)
    {
        String body = this.PopulateBody(DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString(), txtnewpass.Text.Trim());
        this.SendHtmlFormattedEmail(email, "باغبون ، رزرواسیون آنلاین باغ :: گذرواژه جدید", body);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        checkLogin();
        setTitle();
        setPageTree();
        if (!Page.IsPostBack)
        {           
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('warning', { title: 'هشدار', img: '/Images/icon-warning.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'کاربر گرامی ، پس از تغییر گذرواژه باید مجددا به حساب کاربری خود وارد شوید.', delay: 20000 });", true);
        }
    }

    private String PopulateBody(String date, String time, String new_password)
    {
        String body = String.Empty;
        using (StreamReader reader = new StreamReader(Server.MapPath("~/App_Data/Templates/EmailTemplatePasswordChange.txt")))
        {
            body = reader.ReadToEnd();
        }
        body = body.Replace("{date_send}", date);
        body = body.Replace("{time_send}", time);
        body = body.Replace("{new_password}", new_password);
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

    protected void btnchangepass_Click(object sender, EventArgs e)
    {
        changePassword();
    }
}