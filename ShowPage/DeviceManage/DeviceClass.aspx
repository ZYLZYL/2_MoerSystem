<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeviceClass.aspx.cs" Inherits="ShowPage_DeviceManage_DeviceClass" %>

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
                    <asp:Label ID="Label1" runat="server" Text="设备种类"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        DataKeyNames="物品种类编号" DataSourceID="SqlDataSource1">
                        <Columns>
                            <asp:BoundField DataField="物品种类编号" HeaderText="物品种类编号" InsertVisible="False" 
                                ReadOnly="True" SortExpression="物品种类编号" />
                            <asp:BoundField DataField="物品名称" HeaderText="物品名称" SortExpression="物品名称" />
                            <asp:BoundField DataField="物品大类" HeaderText="物品大类" SortExpression="物品大类" />
                            <asp:BoundField DataField="物品种类" HeaderText="物品种类" SortExpression="物品种类" />
                            <asp:BoundField DataField="物品计数单位" HeaderText="物品计数单位" 
                                SortExpression="物品计数单位" />
                            <asp:BoundField DataField="物品整数计数" HeaderText="物品整数计数" 
                                SortExpression="物品整数计数" />
                            <asp:BoundField DataField="库存数量" HeaderText="库存数量" SortExpression="库存数量" />
                            <asp:BoundField DataField="警戒库存数量" HeaderText="警戒库存数量" 
                                SortExpression="警戒库存数量" />
                            <asp:BoundField DataField="历史领用数量" HeaderText="历史领用数量" 
                                SortExpression="历史领用数量" />
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                        SelectCommand="SELECT [物品种类编号], [物品名称], [物品大类], [物品种类], [物品计数单位], [物品整数计数], [库存数量], [警戒库存数量], [历史领用数量] FROM [t_SYS_物品种类]">
                    </asp:SqlDataSource>
                </td>
            </tr>
        </table>
    
    </div>
    <table style="width:100%;">
        <tr>
            <td>
                设备规格</td>
        </tr>
        <tr>
            <td>
                <asp:DataList ID="DataList1" runat="server" DataKeyField="CfgId" 
                    DataSourceID="SqlDataSource2">
                    <ItemTemplate>
                        物品种类编号:
                        <asp:Label ID="物品种类编号Label" runat="server" Text='<%# Eval("物品种类配置名称") %>' />
                        <br />
                        <br />
                    </ItemTemplate>
                </asp:DataList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                    SelectCommand="SELECT [物品种类配置名称], [CfgId], [物品种类编号] FROM [t_SYS_物品种类_配置]">
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
