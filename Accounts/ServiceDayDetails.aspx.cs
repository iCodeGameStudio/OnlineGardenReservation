using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
public partial class Accounts_ServiceDayDetails : System.Web.UI.Page
{
    String date;

    private void setPageTree()
    {
        ((HtmlGenericControl)Page.Master.FindControl("treepage")).InnerHtml = "<li><a href='AccountHome'><i class='fa fa-dashboard'></i>خانه</a></li>   <li><a href='ServicesAdd'>ثبت سرویس</a></li>  <li class='active'>جزئیات</li>";
    }

    private void setTitle()
    {
        ((HtmlGenericControl)Page.Master.FindControl("htitle")).InnerHtml = "جزئیات سرویس" + "<small>حذف و ویرایش سرویس ها تاریخ انتخاب شده</small>";
    }
    private void setActivateItemMenu()
    {
        ((HtmlGenericControl)Page.Master.FindControl("servicesAdd")).Attributes["class"] = "active";
        ((HtmlGenericControl)Page.Master.FindControl("serviceAdd")).Attributes["class"] = "active";
    }

    private void checkLogin()
    {
        if (Session["garden_id"] == null || Session["garden_id"].ToString() == "")
        {
            Response.Redirect("~/");
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        checkLogin();
        setPageTree();
        setTitle();
        setActivateItemMenu();
        try
        {
            date = Request.QueryString["date"].ToString();
        }
        catch
        {
            date = "";
        }
        if (!Page.IsPostBack)
        {
            getInfo("صبح");
            getInfo("ظهر");
            getInfo("عصر");
            getInfo("شب");
        }
        check_empty();
    }

    private void check_empty()
    {
        if (txtcapacity_morning.Text == "")
        {
            txtcapacity_morning.BackColor = System.Drawing.Color.MistyRose;
            txteating_morning.BackColor = System.Drawing.Color.MistyRose;
            txtother_morning.BackColor = System.Drawing.Color.MistyRose;
        }
        if (txtcapacity_noon.Text == "")
        {
            txtcapacity_noon.BackColor = System.Drawing.Color.MistyRose;
            txteating_noon.BackColor = System.Drawing.Color.MistyRose;
            txtother_noon.BackColor = System.Drawing.Color.MistyRose;
        }
        if (txtcapacity_afternoon.Text == "")
        {
            txtcapacity_afternoon.BackColor = System.Drawing.Color.MistyRose;
            txteating_afternoon.BackColor = System.Drawing.Color.MistyRose;
            txtother_afternoon.BackColor = System.Drawing.Color.MistyRose;
        }
        if (txtcapacity_night.Text == "")
        {
            txtcapacity_night.BackColor = System.Drawing.Color.MistyRose;
            txteating_night.BackColor = System.Drawing.Color.MistyRose;
            txtother_night.BackColor = System.Drawing.Color.MistyRose;
        }
    }

    private String checkEntity()
    {
        DBAServices dba = new DBAServices();
        String result = dba.checkEntity(Convert.ToInt32(Session["garden_id"]), Convert.ToDateTime(date));
        return result;
    }

    private void getInfo(String ser_type)
    {
        String result = checkEntity();
        if(result != "notExist")
        {
            DBAServices dba = new DBAServices();
            DataTable dt = new DataTable();
            dt = dba.getServiceInfoDay(Convert.ToInt32(Session["garden_id"]), Convert.ToDateTime(date), ser_type);
            if (dt.Rows.Count == 1)
            {
                if (ser_type == "صبح")
                {
                    txtcapacity_morning.Text = dt.Rows[0]["capacity"].ToString();
                    txteating_morning.Text = dt.Rows[0]["ser_eating"].ToString();
                    txtother_morning.Text = dt.Rows[0]["other_ser"].ToString();
                    if (txtother_morning.Text == "")
                    {
                        txtother_morning.BackColor = System.Drawing.Color.MistyRose;
                    }
                }
                else if (ser_type == "ظهر")
                {
                    txtcapacity_noon.Text = dt.Rows[0]["capacity"].ToString();
                    txteating_noon.Text = dt.Rows[0]["ser_eating"].ToString();
                    txtother_noon.Text = dt.Rows[0]["other_ser"].ToString();
                    if (txtother_noon.Text == "")
                    {
                        txtother_noon.BackColor = System.Drawing.Color.MistyRose;
                    }
                }
                else if (ser_type == "عصر")
                {
                    txtcapacity_afternoon.Text = dt.Rows[0]["capacity"].ToString();
                    txteating_afternoon.Text = dt.Rows[0]["ser_eating"].ToString();
                    txtother_afternoon.Text = dt.Rows[0]["other_ser"].ToString();
                    if (txtother_afternoon.Text == "")
                    {
                        txtother_afternoon.BackColor = System.Drawing.Color.MistyRose;
                    }
                }
                else
                {
                    txtcapacity_night.Text = dt.Rows[0]["capacity"].ToString();
                    txteating_night.Text = dt.Rows[0]["ser_eating"].ToString();
                    txtother_night.Text = dt.Rows[0]["other_ser"].ToString();
                    if (txtother_night.Text == "")
                    {
                        txtother_night.BackColor = System.Drawing.Color.MistyRose;
                    }
                }
            }
        }
        else
        {
            Response.Redirect("ServicesAdd");
        }
            
    }


    private void removeService(String ser_type)
    {
        Int32 garden_id = Convert.ToInt32(Session["garden_id"]);
        DBAServices dba = new DBAServices();
        dba.removeServiceDFDFinal(garden_id, ser_type, Convert.ToDateTime(date));
    }

    private void saveAndUpdate(String ser_type, Int32 capacity, String ser_eating, String ser_other)
    {
        Int32 garden_id = Convert.ToInt32(Session["garden_id"]);
        DBAServices dba = new DBAServices();
        dba.editServiceDFDFinal(garden_id, ser_type, capacity, ser_eating, ser_other, Convert.ToDateTime(date));
    }


    protected void btnEditMorning_Click(object sender, ImageClickEventArgs e)
    {
        String ser_type = "صبح";
        Int32 capacity = Convert.ToInt32(txtcapacity_morning.Text);
        String ser_eating = txteating_morning.Text;
        String ser_other = txtother_morning.Text;
        saveAndUpdate(ser_type, capacity, ser_eating, ser_other);
        Response.Redirect(Request.RawUrl);
    }

    protected void btnRemoveMorning_Click(object sender, ImageClickEventArgs e)
    {
        removeService("صبح");
        Response.Redirect(Request.RawUrl);
    }

    protected void btnEditNoon_Click(object sender, ImageClickEventArgs e)
    {
        String ser_type = "ظهر";
        Int32 capacity = Convert.ToInt32(txtcapacity_noon.Text);
        String ser_eating = txteating_noon.Text;
        String ser_other = txtother_noon.Text;
        saveAndUpdate(ser_type, capacity, ser_eating, ser_other);
        Response.Redirect(Request.RawUrl);
    }

    protected void btnRemoveNoon_Click(object sender, ImageClickEventArgs e)
    {
        removeService("ظهر");
        Response.Redirect(Request.RawUrl);
    }

    protected void btnEditAfternoon_Click(object sender, ImageClickEventArgs e)
    {
        String ser_type = "عصر";
        Int32 capacity = Convert.ToInt32(txtcapacity_afternoon.Text);
        String ser_eating = txteating_afternoon.Text;
        String ser_other = txtother_afternoon.Text;
        saveAndUpdate(ser_type, capacity, ser_eating, ser_other);
        Response.Redirect(Request.RawUrl);
    }

    protected void btnRemoveAfternoon_Click(object sender, ImageClickEventArgs e)
    {
        removeService("عصر");
        Response.Redirect(Request.RawUrl);
    }

    protected void btnEditNight_Click(object sender, ImageClickEventArgs e)
    {
        String ser_type = "شب";
        Int32 capacity = Convert.ToInt32(txtcapacity_night.Text);
        String ser_eating = txteating_night.Text;
        String ser_other = txtother_night.Text;
        saveAndUpdate(ser_type, capacity, ser_eating, ser_other);
        Response.Redirect(Request.RawUrl);
    }

    protected void btnRemoveNight_Click(object sender, ImageClickEventArgs e)
    {
        removeService("شب");
        Response.Redirect(Request.RawUrl);
    }
}