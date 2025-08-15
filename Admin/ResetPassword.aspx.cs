using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class Admin_ResetPassword : System.Web.UI.Page
{
    String email;
    String guid;
    Int32 user_id;


    private void resetCheck()
    {
        DBAUsers dba = new DBAUsers();
        String result = dba.resetCheck(user_id, email, guid);
        if (result == "NotExist")
        {
            Response.Redirect("~/result?link=forget-password-manager-invalid-request");
        }
    }

    private void setPassword()
    {
        DBAUsers dba = new DBAUsers();
        String new_password = txtnewpassword.Text.Trim();
        String confirm_password = txtconfirmpassword.Text.Trim();
        dba.resetPassword(user_id, new_password);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            email = Request.QueryString["email"];
            guid = Request.QueryString["guid"];
            user_id = Convert.ToInt32(Request.QueryString["id"]);
            resetCheck();
        }
        catch
        {
            email = "";
            guid = "";
            user_id = Convert.ToInt32(null);
        }
        if (email == "" && guid == "" && user_id == Convert.ToInt32(null))
        {
            Response.Redirect("~/");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
            if (txtnewpassword.Text.Trim() == txtconfirmpassword.Text.Trim())
            {
                setPassword();
                Response.Redirect("~/result?link=forget-password-manager-changed-successful");
            }
    }
}