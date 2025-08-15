using System;
using System.Collections.Generic;
using System.Web;
using System.Configuration;

public class UTLStatic
{
	public UTLStatic()
	{
	}
    //----------------------------------------------------------------------------------------------------------------------------------
    public static String connectionString
    {
        get { return ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(); }
    }
    //----------------------------------------------------------------------------------------------------------------------------------
    public static String title
    {
        get { return ConfigurationManager.AppSettings["Title"].ToString(); }
    }
    public static String titleSecondary
    {
        get { return ConfigurationManager.AppSettings["TitleSecondary"].ToString(); }
    }
    public static String url
    {
        get { return ConfigurationManager.AppSettings["URL"].ToString(); }
    }
    //----------------------------------------------------------------------------------------------------------------------------------
    public static String pinCode
    {
        get { return ConfigurationManager.AppSettings["PinCode"].ToString(); }
    }
    //----------------------------------------------------------------------------------------------------------------------------------
    //public static String paymentZarinPalMerchantCode
    //{
    //    get { return ConfigurationManager.AppSettings["PaymentZarinPalMerchantCode"].ToString(); }
    //}
    public static String paymentZarinPalCallbackUrl
    {
        get { return ConfigurationManager.AppSettings["PaymentZarinPalCallbackUrl"].ToString(); }
    }
    public static String paymentZarinPalGetwayUrl
    {
        get { return ConfigurationManager.AppSettings["PaymentZarinPalGetwayUrl"].ToString(); }
    }
    //----------------------------------------------------------------------------------------------------------------------------------
}