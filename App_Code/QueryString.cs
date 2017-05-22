using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web;

/// <summary>
/// 安全获取QueryString
/// </summary>
public class QueryString
{
    public QueryString()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    /// <summary>
    /// 安全获取QueryString
    /// </summary>
    /// <param name="page"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public static string GetStringSafeFromQueryString(System.Web.UI.Page page, string key)
    {
        string value = page.Request.QueryString[key];
        return (value == null) ? string.Empty : value;
    }

    /// <summary>
    /// 安全获取 int32 型 QueryString
    /// </summary>
    /// <param name="page"></param>
    /// <param name="key"></param>
    /// <param name="defaultValue"></param>
    /// <returns></returns>
    public static int GetInt32SafeFromQueryString(Page page, string key, int defaultValue)
    {
        string value = GetStringSafeFromQueryString(page, key);
        int i = defaultValue;
        try
        {
            i = int.Parse(value);
        }
        catch (Exception ex) { throw ex; }
        return i;
    }

    /// <summary>
    /// 安全获取 Double 型 QueryString
    /// </summary>
    /// <param name="page"></param>
    /// <param name="key"></param>
    /// <param name="defaultValue"></param>
    /// <returns></returns>
    public static double GetDoubleSafeFromQueryString(Page page, string key, double defaultValue)
    {
        string value = GetStringSafeFromQueryString(page, key);
        double d = defaultValue;
        try
        {
            d = double.Parse(value);
        }
        catch (Exception ex) { throw ex; }
        return d;
    }

    /// <summary>
    /// 安全获取 Float 型 QueryString
    /// </summary>
    /// <param name="page"></param>
    /// <param name="key"></param>
    /// <param name="defaultValue"></param>
    /// <returns></returns>
    public static float GetFloatSafeFromQueryString(Page page, string key, float defaultValue)
    {
        string value = GetStringSafeFromQueryString(page, key);
        float d = defaultValue;
        try
        {
            d = float.Parse(value);
        }
        catch (Exception ex) { throw ex; }
        return d;
    }

}