using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class MemberMasterPage : System.Web.UI.MasterPage
{
    private void setMemberInfo()
    {
        DBAMembers dba = new DBAMembers();
        DataTable dt = dba.getMemberInfo(Convert.ToInt32(Session["member_id"]));
        if(dt.Rows.Count == 1)
        {
            namefamily1.InnerText = dt.Rows[0]["name"].ToString();
            namefamily2.InnerHtml = dt.Rows[0]["name"].ToString() + "<small>کاربر سایت</small>";
            namefamily3.InnerText = dt.Rows[0]["name"].ToString();
        }
    }
    private void loginCheck()
    {
        if(Session["member_id"] == null || Session["member_id"].ToString() == "")
        {
            Response.Redirect("~/");
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        loginCheck();
        setMemberInfo();
    }
}
