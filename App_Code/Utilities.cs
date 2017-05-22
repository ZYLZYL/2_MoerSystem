using System;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class contains miscellaneous functionality 
/// </summary>
public static class Utilities
{
    static Utilities()
    {

    }

    /// <summary>
    /// 判断输入字符串是否NULL如果是则向数据库中插入NULL
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static object IsSQLNull(string str)
    {
        if (str == null || str.ToString().Trim().Length <= 0 || str.ToUpper() == "NULL")
        {
            return DBNull.Value;
        }
        else
        {
            return str;
        }
    }

    //发送Email使用
    public static void SendMail(string from, string to, string subject,
    string body)
    {
        // Configure mail client
        SmtpClient mailClient = new SmtpClient(BalloonShopConfiguration.MailServer);
        // Set credentials (for SMTP servers that require authentication)
        mailClient.Credentials = new NetworkCredential(BalloonShopConfiguration.MailUsername, BalloonShopConfiguration.MailPassword);
        // Create the mail message
        MailMessage mailMessage = new MailMessage(from, to, subject, body);
        // Send mail
        mailClient.Send(mailMessage);
    }

    //输出异常，通过email发送出去；
    public static void LogError(Exception ex)
    {
        // get the current date and time
        string dateTime = DateTime.Now.ToLongDateString() + ", at "
                      + DateTime.Now.ToShortTimeString();
        // stores the error message
        string errorMessage = "Exception generated on " + dateTime;
        // obtain the page that generated the error
        System.Web.HttpContext context = System.Web.HttpContext.Current;
        errorMessage += "\n\n Page location: " + context.Request.RawUrl;
        // build the error message
        errorMessage += "\n\n Message: " + ex.Message;
        errorMessage += "\n\n Source: " + ex.Source;
        errorMessage += "\n\n Method: " + ex.TargetSite;
        errorMessage += "\n\n Stack Trace: \n\n" + ex.StackTrace;
        // send error email in case the option is activated in Web.Config
        if (BalloonShopConfiguration.EnableErrorLogEmail)
        {
            string from = BalloonShopConfiguration.MailFrom;
            string to = BalloonShopConfiguration.ErrorLogEmail;
            string subject = "BalloonShop Error Report";
            string body = errorMessage;
            SendMail(from, to, subject, body);
        }
    }

    /// <summary>
    /// 网页消息对话框
    /// </summary>
    /// <param name="Message">要显示的消息文本</param>
    public static void Show(string Message)
    {
        HttpContext.Current.Response.Write("<script language='javascript' type='text/javascript'>alert('" + Message + "')</script>");
        HttpContext.Current.Response.Write("<script>history.go(-1)</script>");
        HttpContext.Current.Response.End();
    }

    /// <summary>
    /// 网页消息对话框
    /// </summary>
    /// <param name="Message">要显示的消息文本</param>
    /// <param name="Src">点击确定后跳转的页面</param>
    public static void Show(string Message, string Src)
    {
        HttpContext.Current.Response.Write("<script language='javascript' type='text/javascript'>alert('" + Message + "');location.href='" + Src + "'</script>");
        HttpContext.Current.Response.End();
    }

    /// <summary>
    /// 网页消息对话框
    /// </summary>
    /// <param name="Message">要显示的消息文本</param>
    /// <param name="Close">关闭当前页面</param>
    public static void Show(string Message, bool Close)
    {
        if (Close)
        {
            HttpContext.Current.Response.Write("<script language='javascript' type='text/javascript'>alert('" + Message + "');window.close()</script>");
            HttpContext.Current.Response.End();
        }
        else
        {
            HttpContext.Current.Response.Write("<script language='javascript' type='text/javascript'>alert('" + Message + "')</script>");
            HttpContext.Current.Response.End();
        }
    }

    public static void TableToComboBox(DataTable aTable,DropDownList aComboBox,int iIndex)
    {
        if(aTable == null && aComboBox == null)
            return;

        aComboBox.Items.Clear();

        foreach(DataRow  dr in aTable.Rows)
        {
            ListItem  item = new ListItem();

            item.Text = dr[0].ToString();
            item.Value = dr[0].ToString();

            aComboBox.Items.Add(item);
        }

        if (iIndex < aComboBox.Items.Count)
            aComboBox.SelectedIndex = iIndex;
    }

    //------------------------------------------------------------------------------
    //功能：'ax;b;as;aa'  -->  List (ax)(b)(as)(aa)
    //------------------------------------------------------------------------------
    /// <summary>
    /// 拆分字符串为字符串数组
    /// </summary>
    /// <param name="aInString"></param>
    /// <param name="aInDelimiter"></param>
    /// <returns></returns>
    public static string[] splitToStrings(string aInString, string aInDelimiter)
    {
        string[] stringSeparators = new string[] { aInDelimiter };

        //保留空元素
        return aInString.Split(stringSeparators, StringSplitOptions.None);
    }

    /// <summary>
    /// 返回aInString中指定索引I_Index的字符串
    /// </summary>
    /// <param name="I_Index">索引值：（基于0）小于0，取最后一个</param>
    /// <param name="aInString">输入字符串，以aInDelimiter为分割符</param>
    /// <param name="aInDelimiter">分隔符</param>
    /// <returns></returns>
    public static string NamedItem(int I_Index, string aInString, string aInDelimiter)
    {
        //先拆分
        string aResult = "";
        try
        {
            string[] aStringList = splitToStrings(aInString, aInDelimiter);
            int aIndex;

            if (I_Index < 0) //取最后一个
                aIndex = aStringList.Length - 1;
            else
                aIndex = I_Index;

            if (aStringList.Length > 0)
                aResult = aStringList[aIndex];
        }
        catch (Exception ex)
        {
        }

        return aResult;
    }
}
