using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
public partial class MemberReservations : System.Web.UI.Page
{

    private void setTitle()
    {
        ((HtmlGenericControl)Page.Master.FindControl("htitle")).InnerHtml = "داشبرد" + "<small>اطلاعات کلی رزرواسیون</small>";
    }
    private void setActivateItemMenu()
    {
        ((HtmlGenericControl)Page.Master.FindControl("dashboard")).Attributes["class"] = "active";
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
        checkLogin();
        setTitle();
        setActivateItemMenu();
    }
}