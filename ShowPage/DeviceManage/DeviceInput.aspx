<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeviceInput.aspx.cs" Inherits="ShowPage_DeviceManage_DeviceInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>设备信息</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;">
            <tr>
                <td>
                    当前页面:</td>
            </tr>
            <tr>
                <td>
                    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">设备台账</asp:LinkButton>
                    <asp:LinkButton ID="LinkButton2" runat="server">LinkButton</asp:LinkButton>
                    <asp:LinkButton ID="LinkButton3" runat="server">LinkButton</asp:LinkButton>
                    <asp:LinkButton ID="LinkButton4" runat="server">LinkButton</asp:LinkButton>
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
                        DataKeyNames="物品编号" DataSourceID="SqlDataSource1">
                        <Columns>
                            <asp:BoundField DataField="物品编号" HeaderText="物品编号" InsertVisible="False" 
                                ReadOnly="True" SortExpression="物品编号" />
                            <asp:BoundField DataField="物品种类编号" HeaderText="物品种类编号" 
                                SortExpression="物品种类编号" />
                            <asp:BoundField DataField="物品ID" HeaderText="物品ID" SortExpression="物品ID" />
                            <asp:BoundField DataField="物品规格" HeaderText="物品规格" SortExpression="物品规格" />
                            <asp:BoundField DataField="总数量" HeaderText="总数量" SortExpression="总数量" />
                            <asp:BoundField DataField="剩余数量" HeaderText="剩余数量" SortExpression="剩余数量" />
                            <asp:BoundField DataField="批次号" HeaderText="批次号" SortExpression="批次号" />
                            <asp:BoundField DataField="生产日期" HeaderText="生产日期" SortExpression="生产日期" />
                            <asp:BoundField DataField="购买价" HeaderText="购买价" SortExpression="购买价" />
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                        SelectCommand="SELECT [物品编号], [物品种类编号], [物品ID], [物品规格], [总数量], [剩余数量], [批次号], [生产日期], [购买价] FROM [t_SYS_物品]">
                    </asp:SqlDataSource>
                </td>
            </tr>
        </table>
    
    </div>
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
        DataSourceID="SqlDataSource2">
        <Columns>
            <asp:BoundField DataField="设备状态" HeaderText="设备状态" SortExpression="设备状态" />
            <asp:BoundField DataField="校准周期" HeaderText="校准周期" SortExpression="校准周期" />
            <asp:BoundField DataField="保养周期" HeaderText="保养周期" SortExpression="保养周期" />
            <asp:BoundField DataField="设备验收状态" HeaderText="设备验收状态" 
                SortExpression="设备验收状态" />
            <asp:BoundField DataField="保养单位" HeaderText="保养单位" SortExpression="保养单位" />
            <asp:BoundField DataField="校准单位" HeaderText="校准单位" SortExpression="校准单位" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
        SelectCommand="SELECT [设备状态], [校准周期], [保养周期], [设备验收状态], [保养单位], [校准单位] FROM [t_设备]">
    </asp:SqlDataSource>
    </form>
</body>
</html>
