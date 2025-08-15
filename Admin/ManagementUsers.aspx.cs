using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Globalization;
public partial class Admin_ManagementUsers : System.Web.UI.Page
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
        ((HtmlGenericControl)Page.Master.FindControl("treepage")).InnerHtml = "<li><a href='ManagementHome'><i class='fa fa-dashboard'></i>خانه</a></li>   <li class='active'>مدیران</li>";
    }

    private void setTitle()
    {
        ((HtmlGenericControl)Page.Master.FindControl("htitle")).InnerHtml = "مدیران سایت" + "<small>لیست مدیران سایت و تعریف مدیر جدید</small>";
    }
    private void setActivateItemMenu()
    {
        ((HtmlGenericControl)Page.Master.FindControl("users")).Attributes["class"] = "active";
    }

    private void setUsers()
    {
        DBAUsers dba = new DBAUsers();
        GridView1.DataSource = dba.getUsers(Convert.ToInt32(Session["user_id"]));
        GridView1.DataBind();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManagementUsersAdd");
    }

    private void checkAdminType()
    {
        String access;
        DBAUsers dba = new DBAUsers();
        DataTable dt = dba.getUserInfo(Convert.ToInt32(Session["user_id"]));
        if (dt.Rows.Count == 1)
        {
            access = dt.Rows[0]["access"].ToString();
            if (access == "2")
            {
                Response.Redirect("ManagementResult?link=access-denied");
            }
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        checkLogin();
        setPageTree();
        checkAdminType();
        setTitle();
        setActivateItemMenu();
        if (!Page.IsPostBack)
        {
            setUsers();
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DBAUsers dba = new DBAUsers();
        Int32 id = Int32.Parse(e.CommandArgument.ToString());
        String command = e.CommandName.ToString();
        if (command == "remove")
        {
            dba.removeUsers(id);
            setUsers();
        }
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = 0;
        GridView1.EditIndex = e.NewEditIndex;
        setUsers();
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
        DBAUsers dba = new DBAUsers();
        dba.editUser(id, name, family, melicode, mobile, email);
        GridView1.EditIndex = -1;
        setUsers();
        GridViewRow row = GridView1.Rows[e.RowIndex];
        ImageButton ib = (ImageButton)row.FindControl("btnEdit");
        ib.CommandName = "edit";
        Response.Redirect(Request.RawUrl);
    }

    public String miladiToShamsi(Object miladi)
    {
        DateTime miladi_date = Convert.ToDateTime(miladi.ToString());
        DateTime time = Convert.ToDateTime(miladi.ToString());
        PersianCalendar shamsi = new PersianCalendar();
        String day = "";
        String mounth = "";
        String year = "";
        String mounth_name = "";
        day = shamsi.GetDayOfMonth(miladi_date).ToString();
        mounth = shamsi.GetMonth(miladi_date).ToString();
        mounth_name = mounthName(mounth);
        year = shamsi.GetYear(miladi_date).ToString();
        String persiandate = day + " " + mounth_name + " " + year + " | " + "ساعت: " + time.TimeOfDay.ToString();
        return persiandate;
    }

    private String mounthName(String mounth)
    {
        String result = "";
        switch (mounth)
        {
            case "1":
                result = "فروردین";
                break;
            case "2":
                result = "اردیبهشت";
                break;
            case "3":
                result = "خرداد";
                break;
            case "4":
                result = "تیر";
                break;
            case "5":
                result = "مرداد";
                break;
            case "6":
                result = "شهریور";
                break;
            case "7":
                result = "مهر";
                break;
            case "8":
                result = "آبان";
                break;
            case "9":
                result = "آذر";
                break;
            case "10":
                result = "دی";
                break;
            case "11":
                result = "بهمن";
                break;
            case "12":
                result = "اسفند";
                break;
        }
        return result;
    }
    public String ToFarsi(String number)
    {
        UTLNumbers num = new UTLNumbers();
        return num.ToPersianNumber(number);
    }
}