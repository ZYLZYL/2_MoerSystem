<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PersonJueSe.aspx.cs" Inherits="ShowPage_BasicInfoManage_PersonJueSe" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>人员角色权限管理</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="人员信息"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                        AutoGenerateColumns="False" DataKeyNames="PersonID" 
                        DataSourceID="SqlDataSource1" Width="580px">
                        <Columns>
                            <asp:BoundField DataField="PersonID" HeaderText="PersonID" 
                                InsertVisible="False" ReadOnly="True" SortExpression="PersonID" />
                            <asp:BoundField DataField="PersonType" HeaderText="PersonType" 
                                SortExpression="PersonType" />
                            <asp:BoundField DataField="XingMing" HeaderText="XingMing" 
                                SortExpression="XingMing" />
                            <asp:BoundField DataField="Sex" HeaderText="Sex" SortExpression="Sex" />
                            <asp:CommandField ShowSelectButton="True" />
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                        
                        SelectCommand="SELECT [PersonID], [PersonType], [XingMing], [Sex] FROM [t_SYS_Persons]">
                    </asp:SqlDataSource>
                </td>
            </tr>
        </table>
    
    </div>
    <div>
    
        <table style="width:100%;">
            <tr>
                <td>
                    角色信息</td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                        DataKeyNames="角色编号" DataSourceID="SqlDataSource2">
                        <Columns>
                            <asp:BoundField DataField="角色编号" HeaderText="角色编号" ReadOnly="True" 
                                SortExpression="角色编号" />
                            <asp:BoundField DataField="角色名称" HeaderText="角色名称" SortExpression="角色名称" />
                            <asp:BoundField DataField="角色信息描述" HeaderText="角色信息描述" 
                                SortExpression="角色信息描述" />
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                        SelectCommand="SELECT [角色编号], [角色名称], [角色信息描述] FROM [t_SYS_角色]">
                    </asp:SqlDataSource>
                </td>
            </tr>
        </table>
    
    </div>
    <div>
    
        <table style="width:100%;">
            <tr>
                <td>
                    权限信息</td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
                        DataKeyNames="权限编号" DataSourceID="SqlDataSource3">
                        <Columns>
                            <asp:BoundField DataField="权限编号" HeaderText="权限编号" ReadOnly="True" 
                                SortExpression="权限编号" />
                            <asp:BoundField DataField="权限名称" HeaderText="权限名称" SortExpression="权限名称" />
                            <asp:BoundField DataField="权限信息描述" HeaderText="权限信息描述" 
                                SortExpression="权限信息描述" />
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                        SelectCommand="SELECT [权限编号], [权限名称], [权限信息描述] FROM [t_SYS_权限]">
                    </asp:SqlDataSource>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
