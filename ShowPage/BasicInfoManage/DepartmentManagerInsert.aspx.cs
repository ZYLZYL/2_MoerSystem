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

public partial class ShowPage_BasicInfoManage_DepartmentManagerInsert : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //插入记录    
    protected void createDepartment_Click(object sender, EventArgs e)
    {
        Department aDepartment = new Department();
        aDepartment.DepartmentName = this.DepartmentName.Text.Trim();
        aDepartment.DepartmentPersonNo = this.DepartmentPersonNo.Text.Trim();
        aDepartment.DepartmentPhone1 = this.DepartmentPhone1.Text.Trim();
        aDepartment.DepartmentPhone2 = this.DepartmentPhone2.Text.Trim();
        aDepartment.DepartmentWork = this.DepartmentWork.Text.Trim();
        aDepartment.DepartmentInfoFileNo = this.DepartmentInfoFileNo.Text.Trim();
        aDepartment.DepartmentNodeNo = this.DepartmentNodeNo.Text.Trim();

        bool success = DoWork.Department_NewItem(aDepartment);
        Response.Write("<script>alert('插入成功！');location.href='DepartmentManager.aspx';</script>");
        
        //显示状态信息
        statusLabel.Text = success ? "插入失败，请检查是否已经存在该记录" : "插入成功";
        
            

        
    }



}
