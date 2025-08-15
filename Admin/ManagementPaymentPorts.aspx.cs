using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
public partial class Admin_ManagementPaymentPorts : System.Web.UI.Page
{
    private void checkAdminType()
    {
        String access;
        DBAUsers dba = new DBAUsers();
        DataTable dt = dba.getUserInfo(Convert.ToInt32(Session["user_id"]));
        if (dt.Rows.Count == 1)
        {
            access = dt.Rows[0]["access"].ToString();
            if (access == "2" || access == "1")
            {
                Response.Redirect("ManagementResult?link=access-denied");
            }
        }
    }

    private void checkLogin()
    {
        if (Session["user_id"] == null || Session["user_id"].ToString() == "")
        {
            Response.Redirect("~/");
        }
    }
    private void setPageTree()
    {
        ((HtmlGenericControl)Page.Master.FindControl("treepage")).InnerHtml = "<li><a href='ManagementHome'><i class='fa fa-dashboard'></i>خانه</a></li>   <li class='active'>درگاه پرداخت</li>";
    }

    private void setTitle()
    {
        ((HtmlGenericControl)Page.Master.FindControl("htitle")).InnerHtml = "درگاه پرداخت" + "<small>لیست درگاه های پرداخت و ویرایش حساب</small>";
    }
    private void setActivateItemMenu()
    {
        ((HtmlGenericControl)Page.Master.FindControl("port")).Attributes["class"] = "active";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        checkLogin();
        checkAdminType();
        setPageTree();
        setTitle();
        setActivateItemMenu();
        if (!Page.IsPostBack)
            setPaymentPort();
    }

    private void setPaymentPort()
    {
        DBAPaymentsZarinPal dba = new DBAPaymentsZarinPal();
        GridView1.DataSource = dba.getPaymentPort();
        GridView1.DataBind();
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = 0;
        GridView1.EditIndex = e.NewEditIndex;
        setPaymentPort();
        GridViewRow row = GridView1.Rows[e.NewEditIndex];
        ImageButton ib = (ImageButton)row.FindControl("btnEdit");
        ib.CommandName = "update";
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Int32 id = (Int32)GridView1.DataKeys[e.RowIndex].Value;
        GridView1.EditIndex = e.RowIndex;
        String name = ((TextBox)GridView1.Rows[e.RowIndex].Cells[0].Controls[0]).Text.Trim();
        String merchant_code = ((TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text.Trim();
        DBAPaymentsZarinPal dba = new DBAPaymentsZarinPal();
        dba.editPaymentPort(id, name, merchant_code);
        GridView1.EditIndex = -1;
        setPaymentPort();
        GridViewRow row = GridView1.Rows[e.RowIndex];
        ImageButton ib = (ImageButton)row.FindControl("btnEdit");
        ib.CommandName = "edit";
        Response.Redirect(Request.RawUrl);
    }
}