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

public partial class PersonManager : System.Web.UI.Page
{
    //选择所有记录    
    private void BindGrid()
    {
        GridView1.DataSource = DoWork.Person_SelectAll();
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
    /*
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //查询已更新的数据
        string id = this.GridView1.DataKeys[e.RowIndex].Value.ToString();       

        //执行删除命令
        bool success = DoWork.Persons_DeleteItem(id);
        //取消编辑模式
        this.GridView1.EditIndex = -1;
        //显示状态信息
        statusLabel.Text = success ? "删除成功" : "删除失败";

        //重载该网格
        BindGrid();

    }
    */
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

        GridViewRow  row =  GridView1.Rows[e.RowIndex];

        string aXingMing = ((TextBox)row.Cells[1].Controls[0]).Text;
        string aSex = ((DropDownList)row.Cells[2].FindControl("DropDownList2")).SelectedValue; 
            
        string aMobilephone = ((TextBox)row.Cells[3].Controls[0]).Text;
        string aEmail = ((TextBox)row.Cells[4].Controls[0]).Text;
        
        //执行更新命令
        bool success = DoWork.Persons_UpdateItem(id, aXingMing, aSex, aMobilephone, aEmail);

        //取消编辑模式
        this.GridView1.EditIndex = -1;
        //显示状态信息
        statusLabel.Text = success ? "更新成功" : "更新失败";

        //重载该网格
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

    protected void SearchBtn_Click(object sender, EventArgs e)
    {
        throw new Exception("待完成");
    }
    protected void RefBtn_Click(object sender, EventArgs e)
    {
        BindGrid();
    }
    protected void createDiction_Click(object sender, EventArgs e)
    {
        Person aPerson = new Person();
        aPerson.XingMing = this.TextBoxXingMing.Text.Trim();
        aPerson.Sex = this.DropDownListSex.Text.Trim();
        aPerson.TelephoneNo = this.TextBoxTelephone.Text.Trim();
        aPerson.Email = this.TextBoxEmail.Text.Trim();

        bool success = DoWork.Persons_NewItem(aPerson);

        //显示状态信息
        statusLabel.Text = success ? "插入成功" : "插入失败，请检查是否已经存在该记录";

        BindGrid();
    }
}
