using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
public partial class Accounts_AccountSignup : System.Web.UI.Page
{

    private void addMember()
    {

        String name = txtname.Text.Trim();
        String family = txtfamily.Text.Trim();
        String meli_code = txtmelicode.Text.Trim();
        String mobile = txtmobile.Text.Trim();
        String email = txtemail.Text.Trim();
        String province = provinceSelect.SelectedItem.Text.Trim();
        String city = citySelect.SelectedItem.Text.Trim();
        DBAGardens dba = new DBAGardens();
        String result = dba.addGarden(name, family, meli_code, mobile, email, province, city);
        if (result == "account is exist")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('error', { title: 'خطا', img: '/Images/icon-error.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'کاربر گرامی ، قبلا با این ایمیل یا کد ملی یک حساب کاربری ایجاد شده است', delay: 20000 });", true);
        }
        if (result == "successfuly")
        {
            txtname.Text = "";
            txtfamily.Text = "";
            txtmelicode.Text = "";
            txtemail.Text = "";
            txtmobile.Text = "";
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('success', { title: 'عملیات موفقیت آمیز', img: '/Images/icon-success.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'کاربر گرامی ، ثبت نام با موفقیت انجام شد ، پس از تأیید مدیریت ، حساب کاربری شما فعال خواهد شد', delay: 20000 });", true);

        }
    }


    private void setProvinces()
    {
        DBAGardens dba = new DBAGardens();
        provinceSelect.DataSource = dba.getProvince();
        provinceSelect.DataTextField = "name";
        provinceSelect.DataValueField = "id";
        provinceSelect.DataBind();
        provinceSelect.Items.Insert(0, new ListItem("استان خود را انتخاب کنید", ""));
    }
    private void setCitys()
    {
        DBAGardens dba = new DBAGardens();
        citySelect.DataSource = dba.getCity(Convert.ToInt32(provinceSelect.SelectedItem.Value));
        citySelect.DataTextField = "name";
        citySelect.DataValueField = "id";
        citySelect.DataBind();
        citySelect.Items.Insert(0, new ListItem("شهر خود را انتخاب کنید", ""));
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["garden_id"] != null && Session["garden_id"].ToString() != "")
        {
            Response.Redirect("AccountHome");
        }
        if (!Page.IsPostBack)
        {
            setProvinces();
        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        addMember();
    }


    protected void btn_Click(object sender, EventArgs e)
    {

    }

    protected void provinceSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (provinceSelect.SelectedItem.Value != "")
        {
            setCitys();
        }
        else
        {
            citySelect.Items.Clear();
        }

    }
}
