using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ManagementSignout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user_id"] != "" || Session["user_id"] != null)
        {
            DBAUsers dba = new DBAUsers();
            dba.changeLastAndCountLogin(Convert.ToInt32(Session["user_id"]));
        }      
        Session["user_id"] = "";
        Session["user_id"] = null;
        Response.Redirect("~/");
    }
}