using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
public partial class ManagementsMasterPage : System.Web.UI.MasterPage
{
    public String filename;
    private void loginCheck()
    {
        if (Session["user_id"] == null || Session["user_id"].ToString() == "")
        {
            Response.Redirect("~/");
        }
    }

    public static string ToFarsi(string str)
    {
        string vInt = "1234567890";
        char[] mystring = str.ToCharArray(0, str.Length);
        var newStr = string.Empty;
        for (var i = 0; i <= (mystring.Length - 1); i++)
            if (vInt.IndexOf(mystring[i]) == -1)
                newStr += mystring[i];
            else
                newStr += ((char)((int)mystring[i] + 1728));
        return newStr;
    }


    private void setCountNewMessage()
    {
        DBAContact dba = new DBAContact();
        String count = dba.getCountNewMessage();
        if(count == "NotExist")
        {
            message_count.InnerText = "0";
            headertext.InnerText = "0 پیام خوانده نشده";
            ToFarsi(message_count.InnerText);
        }
        else
        {
            message_count.InnerText = count.ToString();
            headertext.InnerText = count.ToString() + " پیام خوانده نشده";
            ToFarsi(message_count.InnerText);
        }
        
    }

    private void setMessage()
    {
        DBAContact dba = new DBAContact();
        Repeater1.DataSource = dba.getNewMessage();
        Repeater1.DataBind();
    }

    private void setUserInfo()
    {
        String name;
        String family;
        String access;
        String file_name;
        DBAUsers dba = new DBAUsers();
        DataTable dt = dba.getUserInfo(Convert.ToInt32(Session["user_id"]));
        if (dt.Rows.Count == 1)
        {
            name = dt.Rows[0]["name"].ToString();
            family = dt.Rows[0]["family"].ToString();
            access = dt.Rows[0]["access"].ToString();
            file_name = dt.Rows[0]["file_name"].ToString();
            filename = file_name;
            if (File.Exists(Server.MapPath("~/Images/Uploads/UserProfile/" + file_name)))
            {
                imgprofile.Src = "~/Images/Uploads/UserProfile/" + file_name;
                imgprofile2.Src = "~/Images/Uploads/UserProfile/" + file_name;
                imgprofile3.Src = "~/Images/Uploads/UserProfile/" + file_name;
            }
            else
            {
                imgprofile.Src = "~/Images/Uploads/UserProfile/noimage.png";
                imgprofile2.Src = "~/Images/Uploads/UserProfile/noimage.png";
                imgprofile3.Src = "~/Images/Uploads/UserProfile/noimage.png";
            
            }
            if (access == "1")
            {
                namefamily1.InnerText = name + " " + family;
                namefamily2.InnerHtml = name + " " + family + "<br><small>مدیر عالی سایت</small>";
                namefamily3.InnerText = name + " " + family;
                users.Attributes["style"] = "display:block;";
                secret.Attributes["style"] = "display:none;";
                admins.Attributes["style"] = "display:none;";
                port.Attributes["style"] = "display:none;";
            }
            else if (access == "2")
            {
                namefamily1.InnerText = name + " " + family;
                namefamily2.InnerHtml = name + " " + family + "<br><small>مدیر میانی سایت</small>";
                namefamily3.InnerText = name + " " + family;
                users.Attributes["style"] = "display:none;";
                secret.Attributes["style"] = "display:none;";
                admins.Attributes["style"] = "display:none;";
                port.Attributes["style"] = "display:none;";
            }
            else if (access == "3")
            {
                namefamily1.InnerText = name + " " + family;
                namefamily2.InnerHtml = name + " " + family + "<br><small>مدیر مخفی</small>";
                namefamily3.InnerText = name + " " + family;
                users.Attributes["style"] = "display:block;";
                secret.Attributes["style"] = "display:block;";
                admins.Attributes["style"] = "display:block;";
                port.Attributes["style"] = "display:block;";
            }
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        loginCheck();
        setUserInfo();
        setCountNewMessage();
        setMessage();
    }


    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }
}
