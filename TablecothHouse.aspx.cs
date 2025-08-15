using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TablecothHouse : System.Web.UI.Page
{
    static String ser_type = "";
    static String type = "";
    static String city = "";
    private void getGardens()
    {
        String type = "سفره خانه";
        DBAGardens dba = new DBAGardens();
        Repeater1.DataSource = dba.getGardensForType(type);
        Repeater1.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            getGardens();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        ser_type = DropDownList2.SelectedValue;
        type = DropDownList1.SelectedValue;
        try
        {
            city = Request.QueryString["City"];
            Response.Redirect("~/?City=" + city + "&ST=" + ser_type + "&TY=" + type.Replace(' ', '-') + "&Date=" + Textbox1.Text);
            ser_type = "";
            type = "";
        }
        catch
        {

        }
    }
}