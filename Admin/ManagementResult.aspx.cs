using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
public partial class Admin_ManagementResult : System.Web.UI.Page
{
    String link;
    private void setTitle(String title,String discription)
    {
        ((HtmlGenericControl)Page.Master.FindControl("htitle")).InnerHtml = title + "<small>"+ discription + "</small>";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            link = Request.QueryString["link"];
            if (link == "access-denied")
            {
                setTitle("خطای 403","ورود به صفحه ی غیرمجاز");
                divaccess.Attributes["style"] = "display:normal;";
            }
            else
            {
                Response.Redirect("ManagementRequestSignin");
            }
        }
        catch
        {

        }
    }
}