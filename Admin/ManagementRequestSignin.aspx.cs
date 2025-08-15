using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
public partial class Admin_ManagementRequestSignin : System.Web.UI.Page
{
    private void checkLogin()
    {
        if (Session["user_id"] == null || Session["user_id"].ToString() == "")
        {
            Response.Redirect("~/");
        }
    }
    private void setPageTree()
    {
        ((HtmlGenericControl)Page.Master.FindControl("treepage")).InnerHtml = "<li><a href='ManagementHome'><i class='fa fa-dashboard'></i>خانه</a></li>   <li class='active'>درخواست ها</li>";
    }
    private void setTitle()
    {
        ((HtmlGenericControl)Page.Master.FindControl("htitle")).InnerHtml = "درخواست های عضویت" + "<small>باغ هایی که به تازگی عضو شده اند و منتظر تأیید شما هستند</small>";
    }
    private void setActivateItemMenu()
    {
        ((HtmlGenericControl)Page.Master.FindControl("requestMem")).Attributes["class"] = "active";
    }

    private void setGardensRequest()
    {
        DBAGardens dba = new DBAGardens();
        GridView1.DataSource = dba.getGardensRequest();
        GridView1.DataBind();
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        checkLogin();
        setPageTree();
        setTitle();
        setActivateItemMenu();
        if (!Page.IsPostBack)
        {
            setGardensRequest();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        setGardensRequest();
    }

    private void setFreeServices(Int32 id)
    {
        DBAServices dba = new DBAServices();
        String start_date_act = DateTime.Today.ToLongDateString();
        String end_date_act = DateTime.Today.AddDays(90).ToLongDateString();
        dba.setServices(id, start_date_act, end_date_act);
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {        
        DBAGardens dba = new DBAGardens();
        Int32 id = Int32.Parse(e.CommandArgument.ToString());
        String command = e.CommandName.ToString();
        if (command == "suspension")
        {
            dba.activeChange(id, 3);
            setGardensRequest();
        }
        else if (command == "refuse")
        {
            dba.activeChange(id, 2);
            setGardensRequest();
        }
        else if (command == "accept")
        {
            dba.activeChange(id, 1);
            setFreeServices(id);
            setGardensRequest();
        } 
        else if (command == "remove")
        {
            dba.removeGarden(id);
            setGardensRequest();
        }
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = 0;
        GridView1.EditIndex = e.NewEditIndex;
        setGardensRequest();
        GridViewRow row = GridView1.Rows[e.NewEditIndex];
        ImageButton ib = (ImageButton)row.FindControl("btnEdit");
        ib.CommandName = "update";
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Int32 id = (Int32)GridView1.DataKeys[e.RowIndex].Value;
        GridView1.EditIndex = e.RowIndex;
        String name = ((TextBox)GridView1.Rows[e.RowIndex].Cells[0].Controls[0]).Text.Trim();
        String family = ((TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text.Trim();
        String melicode = ((TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0]).Text.Trim();
        String mobile = ((TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0]).Text.Trim();
        String email = ((TextBox)GridView1.Rows[e.RowIndex].Cells[4].Controls[0]).Text.Trim();
        String province = ((TextBox)GridView1.Rows[e.RowIndex].Cells[5].Controls[0]).Text.Trim();
        String city = ((TextBox)GridView1.Rows[e.RowIndex].Cells[6].Controls[0]).Text.Trim();
        DBAGardens dba = new DBAGardens();
        dba.editGarden(id, name, family, melicode, mobile, email, province, city);
        GridView1.EditIndex = -1;
        setGardensRequest();
        GridViewRow row = GridView1.Rows[e.RowIndex];
        ImageButton ib = (ImageButton)row.FindControl("btnEdit");
        ib.CommandName = "edit";
    }
}