<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomPersonManager.aspx.cs" Inherits="ShowPage_BasicInfoManage_PersonManager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>人员管理</title>
    <style type="text/css">
        .style1
        {
            height: 29px;
        }
        .style2
        {
            height: 80px;
        }
        *{ 
   margin-left:0px;
   margin-right:9px;
   margin-top:0px;	
}
        .style3
        {
            height: 28px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;">
            <tr>
                <td class="style1">
                 <img style="margin-top:1px; vertical-align:middle "  width="30" height="30" 
                        src="../../public/images/main/fangzi.jpg" alt="当前位置" /> 当前位置:</td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label1" runat="server" CssClass="style2" Text="人员信息"></asp:Label>                    
            </tr>
            <tr>
                <td>
                    <asp:LinkButton ID="LinkButton1" runat="server">LinkButton</asp:LinkButton>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="statusLabel" runat="server" CssClass="AdminError"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="false" 
                        AutoGenerateColumns="False" Width="835px" 
                        onpageindexchanging="GridView1_PageIndexChanging" 
                        onrowcancelingedit="GridView1_RowCancelingEdit" 
                        onrowdeleting="GridView1_RowDeleting" onrowediting="GridView1_RowEditing" 
                        onrowupdating="GridView1_RowUpdating" DataKeyNames="PersonID" 
                        EmptyDataText="null">
                        <Columns>
                            <asp:BoundField DataField="PersonType" HeaderText="人员类型" 
                                SortExpression="PersonType" />
                            <asp:BoundField DataField="XingMing" HeaderText="姓名" 
                                SortExpression="XingMing" />
                            <asp:BoundField DataField="Sex" HeaderText="性别" SortExpression="Sex" />
                            <asp:BoundField DataField="mobilePhone" HeaderText="手机号码" 
                                SortExpression="mobilePhone" />
                            <asp:BoundField DataField="BirthDate" HeaderText="出生日期" 
                                SortExpression="BirthDate" />
                            <asp:BoundField DataField="MaxHighXueWei" HeaderText="最高学位" 
                                SortExpression="MaxHighXueWei" />
                            <asp:CommandField ShowEditButton="True" />
                            <asp:CommandField ShowDeleteButton="True" DeleteText="详情" />
                        </Columns>
                    </asp:GridView>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>    
       
    </form>
</body>
</html>