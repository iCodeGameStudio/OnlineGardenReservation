using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Accounts_AccountSignout : System.Web.UI.Page
{
    private void checkLogin()
    {
        if (Session["garden_id"] == null || Session["garden_id"].ToString() == "")
        {
            Response.Redirect("~/");
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        checkLogin();
        if (Session["garden_id"].ToString() != "" || Session["garden_id"] != null)
        {
            String logout_time = DateTime.Now.ToLocalTime().ToLongTimeString();
            DBAGardens dba = new DBAGardens();
            dba.setLogoutLog(Session["guid_code"].ToString(), logout_time);
        }
        Session["guid_code"] = "";
        Session["guid_code"] = null;
        Session["garden_id"] = "";
        Session["garden_id"] = null;
        Response.Redirect("~/");
    }
}