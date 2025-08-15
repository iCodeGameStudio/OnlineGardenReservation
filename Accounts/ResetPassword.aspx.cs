using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Accounts_ResetPassword : System.Web.UI.Page
{
    String email;
    String guid;
    Int32 garden_id;


    private void resetCheck()
    {
        DBAGardens dba = new DBAGardens();
        String result = dba.resetCheck(garden_id, email, guid);
        if (result == "NotExist")
        {
            Response.Redirect("~/result?link=forget-password-account-invalid-request");
        }
    }

    private void setPassword()
    {
        DBAGardens dba = new DBAGardens();
        String new_password = txtnewpassword.Text.Trim();
        String confirm_password = txtconfirmpassword.Text.Trim();
        dba.resetPassword(garden_id, new_password);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            email = Request.QueryString["email"];
            guid = Request.QueryString["guid"];
            garden_id = Convert.ToInt32(Request.QueryString["id"]);
            resetCheck();
        }
        catch
        {
            email = "";
            guid = "";
            garden_id = Convert.ToInt32(null);
        }
        if (email == "" && guid == "" && garden_id == Convert.ToInt32(null))
        {
            Response.Redirect("~/");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
            if (txtnewpassword.Text.Trim() == txtconfirmpassword.Text.Trim())
            {
                setPassword();
                Response.Redirect("~/result?link=forget-password-account-changed-successful");
            }
    }
}