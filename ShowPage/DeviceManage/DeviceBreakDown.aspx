<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeviceBreakDown.aspx.cs" Inherits="ShowPage_DeviceManage_DeviceBreakDown" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>设备故障</title>
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
                    <asp:LinkButton ID="LinkButton1" runat="server">登记</asp:LinkButton>
                    &nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="LinkButton2" runat="server">处理</asp:LinkButton>
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
                        DataKeyNames="故障登记单号" DataSourceID="SqlDataSource1">
                        <Columns>
                            <asp:BoundField DataField="故障登记单号" HeaderText="故障登记单号" InsertVisible="False" 
                                ReadOnly="True" SortExpression="故障登记单号" />
                            <asp:BoundField DataField="故障设备编号" HeaderText="故障设备编号" 
                                SortExpression="故障设备编号" />
                            <asp:BoundField DataField="故障时间" HeaderText="故障时间" 
                                SortExpression="故障时间" />
                            <asp:BoundField DataField="故障现象" HeaderText="故障现象" 
                                SortExpression="故障现象" />
                            <asp:BoundField DataField="故障报修人员编号" HeaderText="故障报修人员编号" 
                                SortExpression="故障报修人员编号" />
                            <asp:BoundField DataField="故障等级" HeaderText="故障等级" 
                                SortExpression="故障等级" />
                            <asp:BoundField DataField="故障处理状态" HeaderText="故障处理状态" 
                                SortExpression="故障处理状态" />
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                        
                        SelectCommand="SELECT [故障登记单号], [故障设备编号], [故障时间], [故障现象], [故障报修人员编号], [故障等级], [故障处理状态] FROM [t_设备故障登记]">
                    </asp:SqlDataSource>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
