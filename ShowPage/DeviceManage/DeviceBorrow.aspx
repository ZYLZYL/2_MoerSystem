<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeviceBorrow.aspx.cs" Inherits="ShowPage_DeviceManage_DeviceBorrow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>设备借用</title>
</head>
<body>
    <form id="form2" runat="server">
    <div>
    
        <table style="width:100%;">
            <tr>
                <td>
                    当前页面:</td>
            </tr>
            <tr>
                <td>
                    <asp:LinkButton ID="LinkButton1" runat="server" href="DeviceBorrowInsert.aspx">领用申请</asp:LinkButton>
                    &nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="LinkButton2" runat="server">领用核准</asp:LinkButton>
                    &nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="LinkButton3" runat="server">资金登记</asp:LinkButton>
                    &nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="LinkButton4" runat="server">领用登记</asp:LinkButton>
                    &nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="LinkButton5" runat="server">归还登记</asp:LinkButton>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="LinkButton6" runat="server">设备预约</asp:LinkButton>
                    &nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="LinkButton7" runat="server">设备使用</asp:LinkButton>
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
                        DataKeyNames="物品领用单号" DataSourceID="SqlDataSource1">
                        <Columns>
                            <asp:BoundField DataField="物品领用单号" HeaderText="物品领用单号" 
                                ReadOnly="True" SortExpression="物品领用单号" />
                            <asp:BoundField DataField="物品领用状态" HeaderText="物品领用状态" 
                                SortExpression="物品领用状态" />
                            <asp:BoundField DataField="物品领用方式" HeaderText="物品领用方式" 
                                SortExpression="物品领用方式" />
                            <asp:BoundField DataField="物品领用经办人" HeaderText="物品领用经办人" 
                                SortExpression="物品领用经办人" />
                            <asp:BoundField DataField="物品领用人" HeaderText="物品领用人" 
                                SortExpression="物品领用人" />
                            <asp:BoundField DataField="物品领用申请时间" HeaderText="物品领用申请时间" 
                                SortExpression="物品领用申请时间" />
                            <asp:BoundField DataField="物品领用申请人" HeaderText="物品领用申请人" 
                                SortExpression="物品领用申请人" />
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                        
                        SelectCommand="SELECT [物品领用单号], [物品领用状态], [物品领用方式], [物品领用经办人], [物品领用人], [物品领用申请时间], [物品领用申请人] FROM [t_SYS_物品_领用借用]">
                    </asp:SqlDataSource>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
