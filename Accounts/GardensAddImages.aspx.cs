using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
public partial class Accounts_GardensAddImages : System.Web.UI.Page
{
    String garden_id;
    List<bool> isChecked = null;

    private void setPageTree()
    {
        ((HtmlGenericControl)Page.Master.FindControl("treepage")).InnerHtml = "<li><a href='AccountHome'><i class='fa fa-dashboard'></i>خانه</a></li>   <li><a href='GardensAdd'><i class='fa fa-tree'></i>باغ من</a></li>   <li class='active'>ثبت تصاویر باغ</li>";
    }
    private void setTitle()
    {
        ((HtmlGenericControl)Page.Master.FindControl("htitle")).InnerHtml = "ثبت تصاویر باغ" + "<small>شما می توانید تصاویری برای باغ خود ثبت کنید</small>";
    }
    private void setActivateItemMenu()
    {
        ((HtmlGenericControl)Page.Master.FindControl("garden")).Attributes["class"] = "active";
    }

    private void checkLogin()
    {
        if (Session["garden_id"] == null || Session["garden_id"].ToString() == "")
        {
            Response.Redirect("~/");
        }
    }

    private void checkEntity()
    {
        checkLogin();
        Int32 garden_id = Convert.ToInt32(Session["garden_id"]);
        DBAGardens dba = new DBAGardens();
        String result = dba.entityInformation(garden_id);
        if (result == "NotExist")
        {
            Response.Redirect("GardensAdd");
        }

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        setPageTree();
        checkEntity();
        setTitle();
        setActivateItemMenu();
        garden_id = Session["garden_id"].ToString();
        if (!Page.IsPostBack)
        {
            setGardenImages();   
        }
    }

    private void setGardenImages()
    {
        DBAGardens dba = new DBAGardens();
        GridView1.DataSource = dba.getImagesGardens(Convert.ToInt32(garden_id));
        GridView1.DataBind();
    }

    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkBoxStatus = (CheckBox)sender;
        GridViewRow row = (GridViewRow)checkBoxStatus.NamingContainer;
        Int32 id = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Value);
        Boolean cover = checkBoxStatus.Checked;
        DBAGardens dba = new DBAGardens();
        dba.setCover(Convert.ToInt32(garden_id), id, cover);
        setGardenImages();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DBAGardens dba = new DBAGardens();
        Int32 id = Int32.Parse(e.CommandArgument.ToString());
        String command = e.CommandName.ToString();
        if (command == "remove")
        {
            dba.deleteGardensImages(id);
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('success', { title: 'عملیات موفقیت آمیز', img: '/Images/icon-success.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'کاربر گرامی ، تصویر انتخاب شده با موفقیت حذف گردید', delay: 10000 });", true);
            setGardenImages();
        }
    }

    private void uploadImages()
    {
        Int32 sizefilemax = 1024;
        String filepath = "../Images/Uploads/Gardens";
        UTLUploader utl = new UTLUploader();
        String result = utl.uploadImage(FileUpload1.PostedFile, sizefilemax, filepath, true);
        String filename;
        if (result == "error-size")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('error', { title: 'خطا', img: '/Images/icon-error.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'کاربر گرامی ، اندازه فایل انتخاب شده بیش از حد مجاز است ', delay: 10000 });", true);
        }
        else if (result == "error-extension")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('error', { title: 'خطا', img: '/Images/icon-error.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'کاربر گرامی ، پسوند فایل انتخاب شده نا معتبر است ', delay: 10000 });", true);
        }
        else if (result == "no-file")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('error', { title: 'خطا', img: '/Images/icon-error.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'کاربر گرامی ، هیچ فایلی انتخاب نشده است ', delay: 10000 });", true);
        }
        else if (result == "error-upload")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('error', { title: 'خطا', img: '/Images/icon-error.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'کاربر گرامی ، در ارسال تصویر مشکلی رخ داده است ', delay: 10000 });", true);
        }
        else
        {
            String result_check_stock_image = "";
            DBAGardens dba = new DBAGardens();
            result_check_stock_image = dba.checkStockImages(Convert.ToInt32(garden_id));
            if (result_check_stock_image == "Error")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('error', { title: 'خطا', img: '/Images/icon-error.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'کاربر گرامی ، شما فقط مجاز به ارسال 10 تصویر هستید ', delay: 10000 });", true);
            }
            else
            {
                filename = result;
                dba.uploadImage(Convert.ToInt32(garden_id), filename);
                setGardenImages();
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Lobibox", "Lobibox.notify('success', { title: 'عملیات موفقیت آمیز', img: '/Images/icon-success.png',soundExt: '.ogg', soundPath: '/Media/', msg: 'کاربر گرامی ، تصویر انتخاب شده با موفقیت ارسال و ثبت شد', delay: 10000 });", true);
            }
        }
    }

    protected void Upload_Click(object sender, EventArgs e)
    {
            uploadImages();
    }

}
