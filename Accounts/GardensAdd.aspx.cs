using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
public partial class Accounts_GardensAdd : System.Web.UI.Page
{
    private void setPageTree()
    {
        ((HtmlGenericControl)Page.Master.FindControl("treepage")).InnerHtml = "<li><a href='AccountHome'><i class='fa fa-dashboard'></i>خانه</a></li><li class='active' id='page_name' runat='server'>باغ من</li>";
    }
    private void setTitle()
    {
        ((HtmlGenericControl)Page.Master.FindControl("htitle")).InnerHtml = "ثبت مشخصات باغ" + "<small>ثبت مشخصات باغ به همراه ارسال تصاویر باغ</small>";
    }
    private void setActivateItemMenu()
    {
        ((HtmlGenericControl)Page.Master.FindControl("garden")).Attributes["class"] = "active";
    }

    private void setInfo()
    {
        DBAGardens dba = new DBAGardens();
        DataTable dt = new DataTable();
        dt = dba.getGardenDetailsInfo(Convert.ToInt32(Session["garden_id"]));
        if (dt.Rows.Count == 1)
        {
            txtgardenname.Text = dt.Rows[0]["garden_name"].ToString();
            txttel.Text = dt.Rows[0]["tel"].ToString();
            txtcapacity.Text = dt.Rows[0]["capacity"].ToString();
            TextBox1.Text = dt.Rows[0]["possibilities"].ToString();
            txtaddress.Text = dt.Rows[0]["address"].ToString();
            drptype.SelectedValue = dt.Rows[0]["type"].ToString();
        }
        String phrase = TextBox1.Text;
        String[] words = phrase.Split('،');

        foreach (var word in words)
        {
            for (int i = 0; i < chk.Items.Count; i++)
            {
                if (chk.Items[i].Text == word.Trim())
                {
                    chk.Items[i].Selected = true;
                }
            }
        }
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
        if (!Page.IsPostBack)
            setInfo();
    }

    private void changeInfo()
    {
        Int32 garden_id = Convert.ToInt32(Session["garden_id"]);
        String garden_name = txtgardenname.Text.Trim();
        String tel = txttel.Text.Trim();
        String capacity = txtcapacity.Text.Trim();
        String type = drptype.SelectedValue.ToString();
        String address = txtaddress.Text.Trim();
        String possibilities = TextBox1.Text.Trim();
        DBAGardens dba = new DBAGardens();
        dba.changeInformation(garden_id, garden_name, tel, capacity, type, address, possibilities);
        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('success', { title: 'عملیات موفقیت آمیز', img: '/Images/icon-success.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'کاربر گرامی ، اطلاعات باغ شما با موفقیت ثبت گردید ، حال شما می توانید برای باغ خود تصویر ثبت کنید', delay: 20000 });", true);
    }
    protected void btnsavegarden_Click(object sender, EventArgs e)
    {
        changeInfo();
    }

    private void checkEntity()
    {
        Int32 garden_id = Convert.ToInt32(Session["garden_id"]);
        DBAGardens dba = new DBAGardens();
        String result = dba.entityInformation(garden_id);
        if (result == "NotExist")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('error', { title: 'خطا', img: '/Images/icon-error.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'کاربر گرامی ، ابتدا باید برای باغ خود اطلاعات ثبت کنید ', delay: 10000 });", true);
        }
        else
        {
            Response.Redirect("GardensAddImages");
        }
    }

    protected void btnupload_Click(object sender, EventArgs e)
    {
        checkEntity();
    }
    protected void chk_SelectedIndexChanged(object sender, EventArgs e)
    {
        String s = String.Empty;
        TextBox1.Text = "";
        for (int i = 0; i < chk.Items.Count; i++)
        {
            if (chk.Items[i].Selected)
            {
                TextBox1.Text = "";
                s += chk.Items[i].Value + " ، ";
                TextBox1.Text += s;
            }

        }
    }
}