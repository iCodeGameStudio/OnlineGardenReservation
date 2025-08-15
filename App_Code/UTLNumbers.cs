using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class UTLNumbers
{
    private static readonly string[] pn = { "۰", "۱", "۲", "۳", "۴", "۵", "۶", "۷", "۸", "۹" };
    private static readonly string[] en = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
    public String ToEnglishNumber(String number)
    {
        String chash = number;
        for (int i = 0; i < 10; i++)
            chash = chash.Replace(pn[i], en[i]);
        return chash;
    }
    public String ToPersianNumber(String number)
    {
        String chash = number;
        for (int i = 0; i < 10; i++)
            chash = chash.Replace(en[i], pn[i]);
        return chash;
    }
}