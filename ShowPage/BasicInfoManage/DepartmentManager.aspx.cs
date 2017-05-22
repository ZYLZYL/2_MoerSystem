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


using System.Collections.Generic;

using System.Data.Sql;
using System.IO;

public partial class ShowPage_BasicInfoManage_Test : System.Web.UI.Page
{
    //选择所有记录    
    private void BindGrid()
    {
        GridView1.DataSource = DoWork.Department_SelectAll();
        GridView1.DataBind();
    }
    //当加载页面时
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }

    protected void createDiction_Click(object sender, EventArgs e)
    {

    }
    protected void SearchBtn_Click(object sender, EventArgs e)
    {

    }
    protected void RefBtn_Click(object sender, EventArgs e)
    {

    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

    }
    protected void OnRow_Bound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    //选中事件
    protected void gvShow_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            CheckBox h = e.Row.FindControl("CheckAll") as CheckBox;
            h.Attributes.Add("onclick", "SelectAll(this)");
        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onclick", "CheckTr(this,event)");
            //e.Row.Attributes.Add("class", e.Row.RowIndex % 2 == 0 ? "odd" : "even");  
            //e.Row.Attributes.Add("oldClass", e.Row.RowIndex % 2 == 0 ? "odd" : "even");  
            e.Row.Attributes.Add("onmouseover", "oldBg=this.className;this.className='current'");
            e.Row.Attributes.Add("onmouseout", "this.className=oldBg;");
            e.Row.Attributes["style"] = "Cursor:hand";
        }

    }
    //导出Excel
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlData da = new SqlData();
        string sqlString = "SELECT * FROM t_SYS_Department";
        DataSet ds = da.datesetExecute(sqlString, "tbNews");
        // DataRow[] row=ds.Tables["tbNews"].Select("select Zhibu from bizusers ");
        CreateExcel(ds, "1", "excel.xls");

    }
    //创建Excel文件
    public void CreateExcel(DataSet ds, string typeid, string FileName)
    {
        HttpResponse resp;
        resp = Page.Response;
        resp.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
        resp.AppendHeader("Content-Disposition", "attachment;filename=" + FileName);
        string colHeaders = "", ls_item = "";
        int i = 0;

        //定义表对象与行对像，同时用DataSet对其值进行初始化 

        DataTable dt = ds.Tables[0];

        DataRow[] myRow = dt.Select("");

        // typeid=="1"时导出为EXCEL格式文件；typeid=="2"时导出为XML格式文件 

        if (typeid == "1")
        {

            //取得数据表各列标题，各标题之间以"t分割，最后一个列标题后加回车符 

            for (i = 0; i < dt.Columns.Count - 1; i++)
                colHeaders += dt.Columns[i].Caption.ToString() + "\t";

            colHeaders += dt.Columns[i].Caption.ToString() + "\n";

            //向HTTP输出流中写入取得的数据信息 

            resp.Write(colHeaders);

            //逐行处理数据  

            foreach (DataRow row in myRow)
            {

                //在当前行中，逐列获得数据，数据之间以"t分割，结束时加回车符"n

                for (i = 0; i < row.ItemArray.Length - 1; i++) ls_item += row[i].ToString() + "\t";

                ls_item += row[i].ToString() + "\n";

                //当前行数据写入HTTP输出流，并且置空ls_item以便下行数据    

                resp.Write(ls_item);

                ls_item = "";

            }

        }

        else
        {

            if (typeid == "2")
            {

                //从DataSet中直接导出XML数据并且写到HTTP输出流中 

                resp.Write(ds.GetXml());

            }

        }

        //写缓冲区中的数据到HTTP头文件中 

        resp.End();

    }
    //创建excel文件完毕
}
