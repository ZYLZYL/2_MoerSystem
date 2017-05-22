<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeviceUnUsed.aspx.cs" Inherits="ShowPage_DeviceManage_DeviceUnUsed" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>设备报废</title>
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
                    <asp:LinkButton ID="LinkButton1" runat="server">申请</asp:LinkButton>
                    &nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="LinkButton2" runat="server">核准</asp:LinkButton>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;            
                    <asp:LinkButton ID="LinkButton3" runat="server">启用</asp:LinkButton>
                    &nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="LinkButton4" runat="server">停用</asp:LinkButton>
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
                        DataKeyNames="设备报废申请单号" DataSourceID="SqlDataSource1">
                        <Columns>
                            <asp:BoundField DataField="设备报废申请单号" HeaderText="设备报废申请单号" 
                                ReadOnly="True" SortExpression="设备报废申请单号" />
                            <asp:BoundField DataField="设备编号" HeaderText="设备编号" SortExpression="设备编号" />
                            <asp:BoundField DataField="设备报废申请人" HeaderText="设备报废申请人" 
                                SortExpression="设备报废申请人" />
                            <asp:BoundField DataField="设备报废申请时间" HeaderText="设备报废申请时间" 
                                SortExpression="设备报废申请时间" />
                            <asp:BoundField DataField="设备报废申请部门" HeaderText="设备报废申请部门" 
                                SortExpression="设备报废申请部门" />
                            <asp:BoundField DataField="设备报废申请说明" HeaderText="设备报废申请说明" 
                                SortExpression="设备报废申请说明" />
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                        
                        SelectCommand="SELECT [设备报废申请单号], [设备编号], [设备报废申请人], [设备报废申请时间], [设备报废申请部门], [设备报废申请说明] FROM [t_设备_报废]">
                    </asp:SqlDataSource>
                </td>
            </tr>
        </table>
    
    </div>
    </form>    
</body>
</html>
