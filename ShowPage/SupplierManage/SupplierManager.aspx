<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SupplierManager.aspx.cs" Inherits="ShowPage_BasicInfoManage_Test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;">
            <tr>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Button" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        Width="709px" DataKeyNames="单位编号"  AllowPaging="True" 
                        DataSourceID="SqlDataSource1">
                        <PagerSettings FirstPageText="第一页" LastPageText="最后一页" 
                            Mode="NextPreviousFirstLast" NextPageText="下一页" />
                        <Columns>                           
                            <asp:BoundField DataField="单位编号" HeaderText="单位编号" 
                                SortExpression="单位编号" InsertVisible="False" ReadOnly="True" />
                            <asp:BoundField DataField="单位名称" HeaderText="单位名称" 
                                SortExpression="单位名称" />
                            <asp:BoundField DataField="单位大类" HeaderText="单位大类" 
                                SortExpression="单位大类" />
                            <asp:BoundField DataField="单位小类" HeaderText="单位小类" 
                                SortExpression="单位小类" />
                            <asp:BoundField DataField="地址" HeaderText="地址" 
                                SortExpression="地址" />
                            <asp:BoundField DataField="营业执照" HeaderText="营业执照" SortExpression="营业执照" />
                            <asp:BoundField DataField="纳税人识别号" HeaderText="纳税人识别号" 
                                SortExpression="纳税人识别号" />
                            <asp:BoundField DataField="单位地址" HeaderText="单位地址" SortExpression="单位地址" />
                            <asp:BoundField DataField="联系电话1" HeaderText="联系电话1" SortExpression="联系电话1" />
                            <asp:BoundField DataField="联系电话2" HeaderText="联系电话2" SortExpression="联系电话2" />
                            <asp:BoundField DataField="传真号码" HeaderText="传真号码" SortExpression="传真号码" />
                            <asp:BoundField DataField="联系电话3" HeaderText="联系电话3" SortExpression="联系电话3" />
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                        
                        SelectCommand="SELECT [单位编号], [单位名称], [单位大类], [单位小类], [地址], [营业执照], [纳税人识别号], [单位地址], [联系电话1], [联系电话2], [传真号码], [联系电话3] FROM [t_SYS_单位]">
                    </asp:SqlDataSource>
                </td>
            </tr>
        </table>
    
    </div>
   
    </form>
</body>
</html>
