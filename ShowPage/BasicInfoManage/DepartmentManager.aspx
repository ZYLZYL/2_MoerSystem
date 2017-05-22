<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DepartmentManager.aspx.cs" Inherits="ShowPage_BasicInfoManage_Test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>部门管理</title>
<link href="../../public/css/Main.css" type="text/css" rel="stylesheet" />
<script type="text/javascript" src="../../public/css/myjs.js"></script>
<style type="text/css">  
    .checked { background: #c0c0ff; }  
    .odd { background: #72FE95; }  
    .even { background: #B8E2EF; }  
    .current { background: #FFDD75; }  
  </style> 
<style type="text/css">
        .style1
        {
            height: 30px;
        }
        .style2
        {
            height: 12px;
            color:Red;
        }
         </style>
    
</head>

<body class="main">
<table width="100%" border="0" cellpadding="0" cellspacing="0">
      <tr> 
        <td style="height:20px;background-color: #8CA1AE;" >
          <table width="157" style="height:100%" border="0" cellpadding="0" cellspacing="0">
            <tr> 
              <td  style="background-image: url(../../public/images/bg.gif); text-align:center">
                  部门显示</td>
            </tr>
          </table>
        </td>
      </tr>
 </table> 
    <form id="form1" runat="server">
    
    <table style="width:100%;">
        <tr>
            <td colspan="3">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
      <tr> 
        <td><center>
        <table id="search" cellspacing="0" cellpadding="0" width="98%" border="0">
            <tbody>
              <tr> 
                <td align="left" class="style1" valign="middle">请选择类型：<asp:DropDownList id="xtmc" 
                        runat="server" Height="20px" Width="165px" 
                        DataTextField="SysName" DataValueField="SysName"></asp:DropDownList>
                        <asp:button cssclass="mybutton" ID="SearchBtn" runat="server" Text="搜索" 
                        causesvalidation="False" onclick="SearchBtn_Click" />
                        <asp:button cssclass="mybutton" ID="RefBtn" runat="server" Text="刷新" 
                        causesvalidation="False" onclick="RefBtn_Click" />
                        <asp:Button cssclass="mybutton" ID="Button1" runat="server" 
                        PostBackUrl="DepartmentManagerInsert.aspx" 
                        Text="新增"  />
                         <asp:Button cssclass="mybutton" ID="Button2" runat="server" 
                        PostBackUrl="DepartmentManagerInsert.aspx" 
                        Text="删除"  />
                         <asp:Button cssclass="mybutton" ID="Button3" runat="server" 
                        PostBackUrl="DepartmentManagerInsert.aspx" 
                        Text="导入EXCEL"  />
                         <asp:Button cssclass="mybutton" ID="Button4" runat="server" 
                        onclick="Button1_Click"
                        Text="导出EXCEL"  />
                    <br /> &nbsp;<asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                    OnRowDataBound="gvShow_RowDataBound"  
                    AutoGenerateColumns="False" 
                    cellspacing="1" 
                    DataKeyNames="DepartmentNo" 
                    BorderStyle="None" 
                    BorderWidth="0px"
                    BackColor="Silver"
                    HeaderStyle-BackColor="#008cd6" 
                    EmptyDataText="没有查到符合条件的数据！" 
                    Width="100%" onpageindexchanging="GridView1_PageIndexChanging" 
                        onrowcancelingedit="GridView1_RowCancelingEdit" 
                        onrowupdating="GridView1_RowUpdating" onrowediting="GridView1_RowEditing" 
                        onrowdeleting="GridView1_RowDeleting" AllowSorting="True" 
                        onselectedindexchanged="GridView1_SelectedIndexChanged" PageSize="30" >
                        <Columns> 
                              <asp:TemplateField >  
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                  <HeaderTemplate>  
                                      <asp:CheckBox ID="CheckAll" runat="server" Text="全选" ToolTip="按一次全選，再按一次取消全選"/>  
                                  </HeaderTemplate>  
                                  <HeaderStyle  Width="50px" />  
                                  <ItemTemplate>  
                                      <asp:CheckBox runat="server" ID="ckbChose"/>  
                                  </ItemTemplate>  
                                      <ItemStyle  Width="30px" CssClass="txt"/>  
                              </asp:TemplateField>                      
                             <asp:TemplateField HeaderText="序号" HeaderImageUrl="~/public/images/refresh.gif">
                                <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text="<%# GridView1.Rows.Count+ 1 %>"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                                
                            </asp:TemplateField>                 
                            <asp:BoundField DataField="DepartmentName" HeaderText="部门名称" SortExpression="DepartmentName" ItemStyle-HorizontalAlign="Center">
                                
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>                          
                            
                            <asp:BoundField DataField="DepartmentPersonNo" HeaderText="部门主管人" 
                                SortExpression="DepartmentPersonNo" ItemStyle-HorizontalAlign="Center">
                                
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            
                            <asp:BoundField DataField="DepartmentPhone1" HeaderText="部门电话1" 
                                SortExpression="DepartmentPhone1" ItemStyle-HorizontalAlign="Center">
                                
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                             </asp:BoundField>
                            <asp:BoundField DataField="DepartmentWork" HeaderText="部门职责" 
                                SortExpression="DepartmentWork" ItemStyle-HorizontalAlign="Center">
                                
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                             </asp:BoundField>
                            <asp:TemplateField HeaderText="详情" >
                            
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                <ItemTemplate>
                                    <a href='DepartmentManagerMore.aspx?id=<%#Eval("DepartmentNo") %>' >详情</a>
                                    <a href='DepartmentManagerMore.aspx?id=<%#Eval("DepartmentNo") %>' >编辑</a>
                                    <a href='DepartmentManagerMore.aspx?id=<%#Eval("DepartmentNo") %>' >删除</a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerSettings Mode="NumericFirstLast" />
                        <RowStyle CssClass="list_gray" />
                        <HeaderStyle CssClass="title" ForeColor="white" />
                        <AlternatingRowStyle BackColor="#EBFBF0" />
                        <EmptyDataRowStyle BackColor="#E0E0E0" Font-Bold="True" ForeColor="Red" />
                    </asp:GridView>
                </td>
              </tr>
              <tr> 
                <td align="left" class="style2">
                    <asp:Label ID="statusLabel" runat="server" ></asp:Label>
                </td>
              </tr>
              <tr> 
                <td>
				<asp:Panel ID="Panel1" runat="server"  ScrollBars="Auto">
                  </asp:Panel>
                </td>
              </tr>
            </tbody>
        </table>
        </center>
        </td>
      </tr>
  </table>
    
                </td>
        </tr>
        
    </table>
    </form>
</body>
</html>
<script type="text/javascript">  
     var table = "<%=GridView1.ClientID %>";  
     var oldBg;  
     function SelectAll(ele) {  
         t = document.getElementById(table);  
         for (i = 1; i < t.rows.length; i++) {  
             t.rows[i].cells[0].children[0].checked = ele.checked;  
             if (t.rows[i].cells[0].children[0].checked) {  
                 t.rows[i].className = "checked";  
             }  
             else {  
                 t.rows[i].className = t.rows[i].getAttribute("oldClass");  
             }  
         }  
     }  
  
     function CheckTr(tr, evt) {  
         ele = evt.target || event.srcElement;  
         if (ele.tagName && ele.tagName != "INPUT")  
             tr.cells[0].children[0].checked = !tr.cells[0].children[0].checked;  
         if (tr.cells[0].children[0].checked) {  
             oldBg = tr.className = "checked";  
  
         }  
         else {  
             oldBg = tr.className = tr.getAttribute("oldClass");  
         }  
     }  
  </script>