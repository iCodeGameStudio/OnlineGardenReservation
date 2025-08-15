using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
public partial class Result : System.Web.UI.Page
{
    String link;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            link = Request.QueryString["link"];
            if (link == "Password-is-Changed-Management")
            {
                passwordchangedmanagement.Visible = true;
                passwordchangedaccount.Visible = false;
                forgetpasswordaccountsuccessful.Visible = false;
                forgetpasswordaccountinvalidrequest.Visible = false;
                forgetpasswordmanagerinvalidrequest.Visible = false;
                forgetpasswordmanagersuccessful.Visible = false;
                forgetpasswordaccountchangedsuccessful.Visible = false;
                forgetpasswordmanagerchangedsuccessful.Visible = false;
                passwordchanged.Visible = false;
            }
            else if (link == "Password-is-Changed-Account")
            {
                passwordchangedaccount.Visible = true;
                passwordchangedmanagement.Visible = false;
                forgetpasswordaccountsuccessful.Visible = false;
                forgetpasswordaccountinvalidrequest.Visible = false;
                forgetpasswordmanagerinvalidrequest.Visible = false;
                forgetpasswordmanagersuccessful.Visible = false;
                forgetpasswordaccountchangedsuccessful.Visible = false;
                forgetpasswordmanagerchangedsuccessful.Visible = false;
                passwordchanged.Visible = false;
            }
            else if (link == "Password-is-Changed")
            {
                passwordchanged.Visible = true;
                passwordchangedaccount.Visible = false;
                passwordchangedmanagement.Visible = false;
                forgetpasswordaccountsuccessful.Visible = false;
                forgetpasswordaccountinvalidrequest.Visible = false;
                forgetpasswordmanagerinvalidrequest.Visible = false;
                forgetpasswordmanagersuccessful.Visible = false;
                forgetpasswordaccountchangedsuccessful.Visible = false;
                forgetpasswordmanagerchangedsuccessful.Visible = false;
            }
            else if (link == "forget-password-account-successful")
            {
                forgetpasswordaccountsuccessful.Visible = true;
                passwordchangedaccount.Visible = false;
                passwordchangedmanagement.Visible = false;
                forgetpasswordaccountinvalidrequest.Visible = false;
                forgetpasswordmanagerinvalidrequest.Visible = false;
                forgetpasswordmanagersuccessful.Visible = false;
                forgetpasswordaccountchangedsuccessful.Visible = false;
                forgetpasswordmanagerchangedsuccessful.Visible = false;
                passwordchanged.Visible = false;
            }
            else if (link == "forget-password-manager-successful")
            {
                forgetpasswordmanagersuccessful.Visible = true;
                forgetpasswordaccountsuccessful.Visible = false;
                passwordchangedaccount.Visible = false;
                passwordchangedmanagement.Visible = false;
                forgetpasswordaccountinvalidrequest.Visible = false;
                forgetpasswordmanagerinvalidrequest.Visible = false;
                forgetpasswordaccountchangedsuccessful.Visible = false;
                forgetpasswordmanagerchangedsuccessful.Visible = false;
                passwordchanged.Visible = false;
            }
            else if (link == "forget-password-manager-invalid-request")
            {
                forgetpasswordmanagerinvalidrequest.Visible = true;
                forgetpasswordaccountinvalidrequest.Visible = false;
                forgetpasswordaccountsuccessful.Visible = false;
                passwordchangedaccount.Visible = false;
                passwordchangedmanagement.Visible = false;               
                forgetpasswordmanagersuccessful.Visible = false;
                forgetpasswordaccountchangedsuccessful.Visible = false;
                forgetpasswordmanagerchangedsuccessful.Visible = false;
                passwordchanged.Visible = false;
            }
            else if (link == "forget-password-account-invalid-request")
            {
                forgetpasswordaccountinvalidrequest.Visible = true;
                forgetpasswordaccountsuccessful.Visible = false;
                passwordchangedaccount.Visible = false;
                passwordchangedmanagement.Visible = false;
                forgetpasswordmanagerinvalidrequest.Visible = false;
                forgetpasswordmanagersuccessful.Visible = false;
                forgetpasswordaccountchangedsuccessful.Visible = false;
                forgetpasswordmanagerchangedsuccessful.Visible = false;
                passwordchanged.Visible = false;
            }
            else if (link == "forget-password-account-changed-successful")
            {
                forgetpasswordaccountchangedsuccessful.Visible = true;
                forgetpasswordaccountinvalidrequest.Visible = false;
                forgetpasswordaccountsuccessful.Visible = false;
                passwordchangedaccount.Visible = false;
                passwordchangedmanagement.Visible = false;
                forgetpasswordmanagerinvalidrequest.Visible = false;
                forgetpasswordmanagersuccessful.Visible = false;
                forgetpasswordmanagerchangedsuccessful.Visible = false;
                passwordchanged.Visible = false;
            }
            else if (link == "forget-password-manager-changed-successful")
            {
                forgetpasswordmanagerchangedsuccessful.Visible = true;
                forgetpasswordaccountchangedsuccessful.Visible = false ;
                forgetpasswordaccountinvalidrequest.Visible = false;
                forgetpasswordaccountsuccessful.Visible = false;
                passwordchangedaccount.Visible = false;
                passwordchangedmanagement.Visible = false;
                forgetpasswordmanagerinvalidrequest.Visible = false;
                forgetpasswordmanagersuccessful.Visible = false;
                passwordchanged.Visible = false;
            }
            else
            {
                Response.Redirect("~/");
            }
        }
        catch
        {

        }

    }
}