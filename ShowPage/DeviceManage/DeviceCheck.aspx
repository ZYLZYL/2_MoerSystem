<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeviceCheck.aspx.cs" Inherits="ShowPage_DeviceManage_DeviceCheck" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>设备验收</title>
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
                    <asp:LinkButton ID="LinkButton1" runat="server">申请</asp:LinkButton>
                    &nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="LinkButton2" runat="server">核准</asp:LinkButton>
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
                        DataKeyNames="设备验收申请号" DataSourceID="SqlDataSource1">
                        <Columns>
                            <asp:BoundField DataField="设备验收申请号" HeaderText="设备验收申请号" InsertVisible="False" 
                                ReadOnly="True" SortExpression="设备验收申请号" />
                            <asp:BoundField DataField="设备编号" HeaderText="设备编号" SortExpression="设备编号" />
                            <asp:BoundField DataField="设备验收申请时间" HeaderText="设备验收申请时间" 
                                SortExpression="设备验收申请时间" />
                            <asp:BoundField DataField="设备验收申请说明" HeaderText="设备验收申请说明" 
                                SortExpression="设备验收申请说明" />
                            <asp:BoundField DataField="设备验收核准时间" HeaderText="设备验收核准时间" 
                                SortExpression="设备验收核准时间" />
                            <asp:BoundField DataField="设备验收核准结论" HeaderText="设备验收核准结论" 
                                SortExpression="设备验收核准结论" />
                            <asp:BoundField DataField="设备验收核准人编号" HeaderText="设备验收核准人编号" 
                                SortExpression="设备验收核准人编号" />
                            <asp:BoundField DataField="设备验收核准说明" HeaderText="设备验收核准说明" 
                                SortExpression="设备验收核准说明" />
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                        SelectCommand="SELECT [设备验收申请号], [设备编号], [设备验收申请时间], [设备验收申请说明], [设备验收核准时间], [设备验收核准结论], [设备验收核准人编号], [设备验收核准说明] FROM [t_设备_验收]">
                    </asp:SqlDataSource>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
