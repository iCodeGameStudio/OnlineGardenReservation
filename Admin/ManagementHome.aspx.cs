using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
public partial class Admin_ManagementHome : System.Web.UI.Page
{
    private void setPageTree()
    {
        ((HtmlGenericControl)Page.Master.FindControl("treepage")).InnerHtml = "";
    }
    private void setTitle()
    {
        ((HtmlGenericControl)Page.Master.FindControl("htitle")).InnerHtml = "داشبورد" + "<small>اطلاعاتی جامع در مورد عملکرد ها</small>";
    }
    private void setActivateItemMenu()
    {
        ((HtmlGenericControl)Page.Master.FindControl("home")).Attributes["class"] = "active";
    }
    private void checkLogin()
    {
        if (Session["user_id"] == null || Session["user_id"].ToString() == "")
        {
            Response.Redirect("~/");
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        checkLogin();
        setActivateItemMenu();
        setTitle();
        setPageTree();
    }
}