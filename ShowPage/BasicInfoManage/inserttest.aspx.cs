using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class ShowPage_BasicInfoManage_inserttest : System.Web.UI.Page
{
    protected string Action = "";
    //myBaseClass myData = new myBaseClass();
    protected class UserLoginInfo
    {
        public string UserName = "";
        public string UserPassword = "";
    }
    protected UserLoginInfo _UserLoginInfo = new UserLoginInfo();//创建对象

    protected void Page_Load(object sender, EventArgs e)
    {
        Init_WebControls();
    }

    public void Init_WebControls()
    {
        try
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Action"]))//获取form的Action中的参数
            {
                Action = Request.QueryString["Action"].Trim().ToLower();//去掉空格并变小写
            }
            switch (Action)
            {
                case "login":
                    if (!string.IsNullOrEmpty(Request.Form["UserName"]) && !string.IsNullOrEmpty(Request.Form["UserPassWord"]))//获取form中的参数
                    {
                        _UserLoginInfo.UserName = Request.Form["UserName"].ToString();
                        _UserLoginInfo.UserPassword = Request.Form["UserPassWord"].ToString();
                        string user = "select 管理员名称,密码 from T_管理员表 where 管理员名称='" + _UserLoginInfo.UserName + "' and 密码='" + _UserLoginInfo.UserPassword + "'";
                        /*if (myData.readDataSet(user).Tables[0].Rows.Count == 1)
                        {
                            Response.Redirect("Main.aspx", false);//防止Response.End 方法终止页的执行
                        }
                        else
                        {
                            Response.Write("<Script Language=JavaScript>alert('密码或用户名错误，请重试！');</Script>");

                        }
                         */
                    }
                    break;
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
