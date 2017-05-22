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

public partial class left : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /*
        if (Request.Cookies["hyyc"].Values["hyid_carol"] == null)
            {
                Response.Write("<br>&nbsp;<img src=/images/clock.gif></img><font size=2pt color=red>系统超时，请重新登录！</font>");
                Response.End();
            }
        

        long ParentNode;
        long NodeId;
        
        if (!IsPostBack)
        {
            //定义节点数组，数组下标对应于分类信息的ID，编码最多不能大于1000，否则会报错 
            TreeNode[] menuNodes = new TreeNode[1001];
            for (int i = 0; i < menuNodes.Length; i++)
            {
                //初始化各节点 
                menuNodes[i] = new TreeNode();
            }


            //查询当前用户拥有的菜单权限信息（不是禁用状态、菜单类型是Q或A）
 
            /*
            Socut.Reader dataR = new Socut.Reader("select distinct b.modu_id,c.modu_mc,c.modu_upid,c.modu_wjlj from yh a left outer join role_qx b on (a.ui_role=b.role_id) left outer join modu c on (b.modu_id=c.modu_id) where a.ui_id='" + Request.Cookies["hyyc"].Values["hyid_carol"].ToString() + "' and c.modu_zt<>'禁用' and c.modu_lx='Q' ");
            //循环记录集，依次加载TreeView节点 
            while (dataR.Read())
            {
                ParentNode = (long)dataR["modu_upid"];
                //获取上级分类ID 
                NodeId = (long)dataR["modu_id"];
                //获取当前分类ID 
                //设置节点的显示文本，即分类名称 
                menuNodes[NodeId].Text = (string)dataR["modu_mc"];
                if (ParentNode != 0)
                {
                    //如果存在上级分类，则将本节点作为上级分类对应的节点的子节点 
                    menuNodes[ParentNode].ChildNodes.Add(menuNodes[NodeId]);
                    //由于模块的编码规则是“一级菜单1位，二级菜单2位，三级菜单2位”，所以小于1000的通常不是直接模块所以加此判断 
                    if (NodeId >= 1000)
                    {
                        //设置节点的链接地址 
                        //menuNodes(NodeId).NavigateUrl = "bmright.aspx?ClassID=" & NodeId 
                        menuNodes[NodeId].NavigateUrl = (string)dataR["modu_wjlj"];
                        menuNodes[NodeId].Target = "mainframe";
                    }
                    else
                    {
                        //设置为点击不是链接 
                        menuNodes[NodeId].SelectAction = TreeNodeSelectAction.Expand;
                    }
                }
                else
                {
                    //如果不存在上级分类，则将本节点作为根节点，直接加载 
                    TreeView1.Nodes.Add(menuNodes[NodeId]);
                    //设父节点设置为点击链接也可以弹出下级菜单 
                    menuNodes[NodeId].SelectAction = TreeNodeSelectAction.Expand;
                }
            }
            dataR.Close();            
        } 
       */  

    }
}
