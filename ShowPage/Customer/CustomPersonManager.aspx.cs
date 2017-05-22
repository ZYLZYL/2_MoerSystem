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

public partial class ShowPage_BasicInfoManage_PersonManager : System.Web.UI.Page
{
    //选择所有记录    
    private void BindGrid()
    {
        this.GridView1.DataSource = DoWork.Person_SelectAll();
        GridView1.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GridView1.PageIndex = e.NewPageIndex;

        BindGrid();
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        //取消编辑模式
        this.GridView1.EditIndex = -1;
        //设置状态信息
        this.statusLabel.Text = "编辑取消";
        //重载该网格
        BindGrid();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //查询已更新的数据
        string id = this.GridView1.DataKeys[e.RowIndex].Value.ToString();       


        //执行删除命令
        //bool success = DoWork.Diction_DeleteItem(id);
        //取消编辑模式
        this.GridView1.EditIndex = -1;
        //显示状态信息
        //statusLabel.Text = success ? "删除成功" : "删除失败";

        //重载该网格
        BindGrid();

    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        this.GridView1.EditIndex = e.NewEditIndex; //设置允许启用编辑模式的行
        //设置状态标签
        this.statusLabel.Text = "正在编辑第(#" + e.NewEditIndex.ToString() + ")行";
        //重载该网格
        BindGrid();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //1、获得ID
        string id = this.GridView1.DataKeys[e.RowIndex].Value.ToString();

        throw new Exception("未实现");

        string sysName = ((TextBox)this.GridView1.Rows[e.RowIndex].Cells[0].Controls[0]).Text;
        string itemName = ((TextBox)this.GridView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
        string itemValue = ((TextBox)this.GridView1.Rows[e.RowIndex].Cells[2].Controls[0]).Text;

        //执行更新命令
        //bool success = DoWork.Diction_UpdateItem(id, sysName, itemName, itemValue);

        //取消编辑模式
        this.GridView1.EditIndex = -1;
        //显示状态信息
        //statusLabel.Text = success ? "更新成功" : "更新失败";

        //重载该网格
        BindGrid();
    }
}
