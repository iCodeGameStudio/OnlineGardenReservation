using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.Data;
public partial class Admin_ManagementGardenDetails : System.Web.UI.Page
{
    String garden_id;
    private void checkLogin()
    {
        if (Session["user_id"] == null || Session["user_id"].ToString() == "")
        {
            Response.Redirect("~/");
        }
    }

    private void setPageTree()
    {
        ((HtmlGenericControl)Page.Master.FindControl("treepage")).InnerHtml = "<li><a href='ManagementHome'><i class='fa fa-dashboard'></i>خانه</a></li>   <li><a href='ManagementGardens'><i class='fa fa-tree'></i>باغ ها</a></li>   <li class='active'>مشخصات باغ</li>";
    }
    private void setTitle()
    {
        ((HtmlGenericControl)Page.Master.FindControl("htitle")).InnerHtml = "مشخصات باغ و صاحب باغ" + "<small>همه جزئیات باغ و صاحب باغ و ویرایش</small>";
    }
    private void setActivateItemMenu()
    {
        ((HtmlGenericControl)Page.Master.FindControl("gardens")).Attributes["class"] = "active";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        checkLogin();
        try
        {
            garden_id = Request.QueryString["id"].ToString();
        }
        catch
        {
            garden_id = "";
        }

        if (garden_id == "")
        {
            Response.Redirect("ManagementGardens");
        }
        setPageTree();
        setTitle();
        setActivateItemMenu();
        if(!Page.IsPostBack)
        {
            setGarden();
            setGardenInfo();
        }       
    }

    private void setGarden()
    {
        DBAGardens dba = new DBAGardens();
        DataTable dt = dba.getGardenInfo(Convert.ToInt32(garden_id));
        String name = "";
        String family = "";
        String melicode = "";
        String mobile = "";
        String email = "";
        String province = "";
        String city = "";
        if (dt.Rows.Count == 1)
        {
            name = dt.Rows[0]["name"].ToString();
            family = dt.Rows[0]["family"].ToString();
            melicode = dt.Rows[0]["melicode"].ToString();
            mobile = dt.Rows[0]["mobile"].ToString();
            email = dt.Rows[0]["email"].ToString();
            province = dt.Rows[0]["province"].ToString();
            city = dt.Rows[0]["city"].ToString();
        }
        txtname.Text = name;
        txtfamily.Text = family;
        txtmelicode.Text = melicode;
        txtmobile.Text = mobile;
        txtemail.Text = email;
        txtprovince.Text = province;
        txtcity.Text = city;
    }

    private void setGardenInfo()
    {
        DBAGardens dba = new DBAGardens();
        DataTable dt = dba.getGardenDetailsInfo(Convert.ToInt32(garden_id));
        String gardenname = "";
        String tel = "";
        String capacity = "";
        String type = "";
        String possibilities = "";
        String address = "";
        if (dt.Rows.Count == 1)
        {
            gardenname = dt.Rows[0]["garden_name"].ToString();
            tel = dt.Rows[0]["tel"].ToString();
            capacity = dt.Rows[0]["capacity"].ToString();
            type = dt.Rows[0]["type"].ToString();
            possibilities = dt.Rows[0]["possibilities"].ToString();
            address = dt.Rows[0]["address"].ToString();
        }
        txtgardenname.Text = gardenname;
        txttel.Text = tel;
        txtcapacity.Text = capacity;
        txttype.Text = type;
        txtpossibilities.Text = possibilities;
        txtaddress.Text = address;
    }

}