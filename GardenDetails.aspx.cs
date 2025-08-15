using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class GardenDetails : System.Web.UI.Page
{
    String garden_id;

    private void setGardenInfo()
    {
        DBAGardens dba = new DBAGardens();
        DataTable dt = dba.getGardenInfo(garden_id);
        if (dt.Rows.Count > 0)
        {
            spanname.InnerText = dt.Rows[0]["garden_name"].ToString();
            spancapacity.InnerText = dt.Rows[0]["capacity"].ToString() + " نفر";
            spantype.InnerText = dt.Rows[0]["type"].ToString();
            spantel.InnerText = dt.Rows[0]["tel"].ToString();
            txtpossibilities.Text = dt.Rows[0]["possibilities"].ToString();
            txtaddress.Text = dt.Rows[0]["address"].ToString();            
        }
        else
            Response.Redirect("~/");
    }

    private void setImages()
    {
        DBAGardens dba = new DBAGardens();
        Repeater1.DataSource = dba.getGardenInfo(garden_id);
        Repeater1.DataBind();
        Repeater2.DataSource = dba.getGardenInfo(garden_id);
        Repeater2.DataBind();
    }


    protected void Page_Load(object sender, EventArgs e)
    {
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
            Response.Redirect("~/");
        }
        setGardenInfo();
        setImages();
    }
}