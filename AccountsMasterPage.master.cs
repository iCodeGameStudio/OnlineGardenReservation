using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
public partial class AccountsMasterPage : System.Web.UI.MasterPage
{
    private void loginCheck()
    {
        if (Session["garden_id"] == null || Session["garden_id"].ToString() == "")
        {
            Response.Redirect("~/");
        }
    }

    private void checkDaysService()
    {

        String end_date_act = "";
        DBAGardens dba = new DBAGardens();
        DataTable dt = dba.getGardenInfo(Convert.ToInt32(Session["garden_id"]));
        if (dt.Rows.Count == 1)
        {
            end_date_act = dt.Rows[0]["end_date_act"].ToString();
        }
        DateTime now_date = new DateTime();
        now_date = DateTime.Today;
        DateTime end_date = new DateTime();
        end_date = DateTime.Parse(end_date_act);

        //DateTime different = new DateTime(end_date.Subtract(now_date).Ticks);  
        //TimeSpan diff1 = end_date - now_date;
       // TimeSpan different = end_date.Subtract(now_date);
        String diff2 = (end_date - now_date).TotalDays.ToString();
        if (Convert.ToInt32(diff2) <= 7)
        {
            service.Style.Add("display", "block");
        }
        else
        {
            service.Style.Add("display", "none");
        }

    }

    private void setMemberInfo()
    {
        String name = "";
        String family = "";
        String file_name = "";
        String start_date_act = "";
        String end_date_act = "";
        String act_count = "";
        DBAGardens dba = new DBAGardens();
        DataTable dt = dba.getGardenInfo(Convert.ToInt32(Session["garden_id"]));
        if (dt.Rows.Count == 1)
        {
            name = dt.Rows[0]["name"].ToString();
            family = dt.Rows[0]["family"].ToString();
            file_name = dt.Rows[0]["file_name"].ToString();
            start_date_act = dt.Rows[0]["start_date_act"].ToString();
            end_date_act = dt.Rows[0]["end_date_act"].ToString();
            act_count = dt.Rows[0]["act_count"].ToString();

            if (File.Exists(Server.MapPath("~/Images/Uploads/GardenProfile/" + file_name)))
            {
                imgprofile.Src = "~/Images/Uploads/GardenProfile/" + file_name;
                imgprofile2.Src = "~/Images/Uploads/GardenProfile/" + file_name;
                imgprofile3.Src = "~/Images/Uploads/GardenProfile/" + file_name;
            }
            else
            {
                imgprofile.Src = "~/Images/Uploads/GardenProfile/noimage.png";
                imgprofile2.Src = "~/Images/Uploads/GardenProfile/noimage.png";
                imgprofile3.Src = "~/Images/Uploads/GardenProfile/noimage.png";
            }
            namefamily1.InnerText = name + " " + family;
            namefamily2.InnerHtml = name + " " + family + "<br><small>مدیر باغ</small>";
            namefamily3.InnerText = name + " " + family;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        loginCheck();
        checkDaysService();
        setMemberInfo();
    }



    protected void timer1_Tick(object sender, EventArgs e)
    {
        //lbl1.Text = Convert.ToInt32(lbl1.Text) + 1 + "";
    }

}
