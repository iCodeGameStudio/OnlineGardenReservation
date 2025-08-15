using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web;

public class UTLUploader
{
    public UTLUploader()
    {
    }
    private static System.Drawing.Image scaleImage(System.Drawing.Image image, Int32 maxImageHeight)
    {
        if (image.Height > maxImageHeight)
        {
            Double ratio = (Double)maxImageHeight / image.Height;
            Int32 newWidth = (Int32)(image.Width * ratio);
            Int32 newHeight = (Int32)(image.Height * ratio);
            Bitmap newImage = new Bitmap(newWidth, newHeight);
            Graphics g = Graphics.FromImage(newImage);
            g.DrawImage(image, 0, 0, newWidth, newHeight);
            return newImage;
        }
        return image;
    }
    private String checkUploadImage(HttpPostedFile file, Int32 maxFileSize)
    {
        if ((file != null) && (file.FileName != ""))
        {
            String fileName = System.IO.Path.GetFileName(file.FileName);
            String fileExtension = System.IO.Path.GetExtension(fileName);
            if ((fileExtension.ToLower() == ".jpg") || (fileExtension.ToLower() == ".bmp") || (fileExtension.ToLower() == ".gif") || (fileExtension.ToLower() == ".png"))
            {
                Int32 fileSize = (file.ContentLength) / 1024;
                if (fileSize > maxFileSize)
                {
                    return "error-size";
                }
            }
            else
            {
                return "error-extension";
            }
        }
        else
        {
            return "no-file";
        }
        return "no-error";
    }
    public String uploadImage(HttpPostedFile file, Int32 maxFileSize, String uploadPath, Boolean randomFileName)
    {
        String result = checkUploadImage(file, maxFileSize);
        try
        {
            //ایجاد شئ بیتمپ از تصویر پست شده(انتخاب شده) برای آپلود
            Bitmap bmpUpload = new Bitmap(file.InputStream);
            //ایجاد شئ ای از کلاس گرافیکس ، برای دستکاری تصویر انتخاب شده
            Graphics graphicsObj = Graphics.FromImage(bmpUpload);

            //لوگوی متنی
            //string txtLogo = "باغبون ، رزرواسیون آنلاین باغ";
            Bitmap bmptext = new Bitmap(HttpContext.Current.Server.MapPath(@"~\Images") + "\\" + "textwatermark.png");
            //مختصات مکانی لوگوی متنی
            Point positionTextLogo = new Point(0, bmpUpload.Height - bmptext.Height);
            //در نظر گرفتن رنگ
            //Brush brush = new SolidBrush(Color.Green);
            //چسباندن لوگوی متنی          
            //graphicsObj.DrawString(txtLogo, new System.Drawing.Font("IranSans", 16, FontStyle.Bold, GraphicsUnit.Pixel), brush, positionTextLogo);           
            graphicsObj.DrawImageUnscaled(bmptext, positionTextLogo);
            //ایجاد شئ بیتمپ از لوگوی تصویری مورد نظر
            Bitmap bmpLogo = new Bitmap(HttpContext.Current.Server.MapPath(@"~\Images") + "\\" + "watermarklogo.png");
            //مختصات مکانی لوگوی تصویری
            Point positionImgLogo = new Point(0, 0);
            //چسباندن لوگوی تصویری
            graphicsObj.DrawImageUnscaled(bmpLogo, positionImgLogo);

            //ذخیره تصویر نهایی در مسیر مورد نظر
            //   bmpUpload.Save(HttpContext.Current.Server.MapPath("Images") + "\\" + System.IO.Path.GetFileName(file.FileName) + ".jpg");

            
            if (result == "no-error")
            {
                String fileName = "";
                if (randomFileName)
                    fileName = Guid.NewGuid().ToString() + ".jpg";
                else
                    fileName = System.IO.Path.GetFileName(file.FileName);
                uploadPath = HttpContext.Current.Server.MapPath(uploadPath);
                try
                {
                    System.Drawing.Image image = scaleImage(System.Drawing.Image.FromStream(file.InputStream), 600);
                    //System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(image);
                    bmpUpload.Save(uploadPath + "/" + fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    bmpUpload.Dispose();
                    return fileName;
                }
                catch
                {
                    return "error-upload";
                }
            }
        }
        catch
        {

        }
           

        return result;
       
    }
}