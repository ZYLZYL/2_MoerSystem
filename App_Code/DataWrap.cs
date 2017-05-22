using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;





/// <summary>
/// 数据字典
/// </summary>
public struct Diction
{
    public string SysName;
    public string ItemName;
    public string ItemValue;
}

/// <summary>
/// 人员
/// </summary>
public struct Person
{
    public int PersonID;
    public string UserName;
    public string XingMing;
    public string Sex;
    public string EnglishName;
    public string UsedName_has;
    public string TelephoneNo;
    public string fax;
    public string address;
    public string mobilePhone;
    public string Email;
    public string QQ;
    public string WeiXin;
    public string ZhiWu;
    public string zhicheng;
    public string ShenFenZhengNo;
    public string BirthDate;
    public string MinZu;
    public string MaxHighXueWei;
    public string ZhengZhiMianMiao;
    public string WorkTime_Init;
    public string DateComeWork;
    public string AiHao;
}
///部门
public struct Department
{
    public int DepartmentNo;
    public string DepartmentName;
    public string DepartmentPersonNo;
    public string DepartmentPhone1;
    public string DepartmentPhone2;
    public string DepartmentWork;
    public string DepartmentInfoFileNo;
    public string DepartmentNodeNo;
}
