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

public partial class webDataDiction : System.Web.UI.Page
{
    //GridView绑定    
    private void BindGrid()
    {
         GridView1.DataSource = DoWork.Diction_SelectAll();
         GridView1.DataBind();
    }

    //搜索完之后的GridView的绑定
    private void BindGridBySysName(string aSysName)
    {
        if (string.IsNullOrEmpty(aSysName))
            return;
        
        this.GridView1.DataSource = DoWork.Diction_SelectBySystem(aSysName);
        GridView1.DataBind();
    }

    //
    private void BindComboBoxBySystem()
    {
        xtmc.DataSource = DoWork.Diction_SelectSysName();
        xtmc.DataBind();
    }
  
    //页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //填充GridView
            BindGrid();
            BindComboBoxBySystem();            
        }        
    }

    //行编辑
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        this.GridView1.EditIndex = e.NewEditIndex; //设置允许启用编辑模式的行
        //设置状态标签
        this.statusLabel.Text = "正在编辑第(#" + (e.NewEditIndex + 1).ToString() + ")行";
        //重载该网格
        BindGrid();
    }
    
    //string itemName = ((TextBox)this.GridView1.Rows[e.RowIndex].FindControl("aaa")).Text;
    //更新
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //1、获得ID
        string id = this.GridView1.DataKeys[e.RowIndex].Value.ToString();
        
        string sysName = ((TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
        string itemName = ((TextBox)this.GridView1.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
        string itemValue = ((TextBox)this.GridView1.Rows[e.RowIndex].Cells[3].Controls[0]).Text; 
                
        //执行更新命令
        bool success = DoWork.Diction_UpdateItem(id, sysName, itemName, itemValue);

        //取消编辑模式
        this.GridView1.EditIndex = -1;
        //显示状态信息
        statusLabel.Text = success? "更新成功":"更新失败";

        //重载该网格
        BindGrid();
    }

    //删除行
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //查询已更新的数据
        string id = this.GridView1.DataKeys[e.RowIndex].Value.ToString();
        
        //执行删除命令
        bool success = DoWork.Diction_DeleteItem(id);
        //取消编辑模式
        this.GridView1.EditIndex = -1;
        //显示状态信息
        statusLabel.Text = success ? "删除成功" : "删除失败"; 

        //重载该网格
        BindGrid();

    }

    //编辑取消
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        //取消编辑模式
        this.GridView1.EditIndex = -1;
        //设置状态信息
        this.statusLabel.Text = "编辑取消";
        //重载该网格
        BindGrid();
    }

    //创建新记录
    protected void createDiction_Click(object sender, EventArgs e)
    {
        bool success = DoWork.Diction_NewItem(this.TextBoxSysName.Text.Trim(),this.TextBoxItemName.Text.Trim(),this.TextBoxItemValue.Text.Trim());

        //显示状态信息
        statusLabel.Text = success ? "插入成功" : "插入失败，请检查是否已经存在该记录";

        BindGrid();
    }

    //单击选中行变色子程序 
    public void OnRow_Bound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowType == DataControlRowType.DataRow))
        {
            e.Row.Attributes["onclick"] = "javascript:changeBg(this)";
        }
    }
    
    //刷新
    protected void RefBtn_Click(object sender, EventArgs e)
    {
        //填充GridView
        BindGrid();
    }

    //分页
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GridView1.PageIndex = e.NewPageIndex;

        BindGrid();
    }

    //搜索
    protected void SearchBtn_Click(object sender, EventArgs e)
    {
        BindGridBySysName(xtmc.Text);
    }
}
