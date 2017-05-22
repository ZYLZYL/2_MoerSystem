<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PersonInfo.aspx.cs" Inherits="ShowPage_PersonInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <style type="text/css">
        .style1
        {
            width: 358px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 547px">
    <p>基本信息:</p>
    <p style="width: 546px">
       <span class="WideLabel">用户姓名:</span>
       <asp:TextBox ID="UserXingMing" runat="server" Width="400px"></asp:TextBox> 
    </p>
    <p>       
       <span class="WideLabel">登录名称</span>
       <asp:TextBox ID="UserName" runat="server" Width="400px"></asp:TextBox> 
    </p>
    <p>
       <span class="WideLabel">出生日期</span>
       <asp:TextBox ID="newItemValue" runat="server" Width="413px" Height="22px"></asp:TextBox> 
    </p>
    <p>
       <span class="WideLabel">性别</span>
       <asp:TextBox ID="TextBox1" runat="server" Width="413px" Height="22px"></asp:TextBox> 
    </p>
    
     <p>
       <span class="WideLabel">电话</span>
       <asp:TextBox ID="TextBox2" runat="server" Width="413px" Height="22px"></asp:TextBox> 
    </p>
    
     <p>
       <span class="WideLabel">Email</span>
       <asp:TextBox ID="TextBox3" runat="server" Width="413px" Height="22px"></asp:TextBox> 
    </p>
    
     <p>
       <span class="WideLabel">新密码</span>
       <asp:TextBox ID="TextBox4" runat="server" Width="413px" Height="22px"></asp:TextBox> 
    </p>
    
     <p>
       <span class="WideLabel">确认密码</span>
       <asp:TextBox ID="TextBox5" runat="server" Width="413px" Height="22px"></asp:TextBox> 
    </p>    
    </div>
    
    
    <div>
    <p>详细信息:</p>
    <p style="width: 546px">
       <span class="WideLabel">地址:</span>
       <asp:TextBox ID="TextBox6" runat="server" Width="400px"></asp:TextBox> 
    </p>
    <p>       
       <span class="WideLabel">学历</span>
       <asp:TextBox ID="TextBox7" runat="server" Width="400px"></asp:TextBox> 
    </p>
    <p>
       <span class="WideLabel">专业</span>
       <asp:TextBox ID="TextBox8" runat="server" Width="413px" Height="22px"></asp:TextBox> 
    </p>
    <p>
       <span class="WideLabel">婚姻状况</span>
       <asp:TextBox ID="TextBox9" runat="server" Width="413px" Height="22px"></asp:TextBox> 
    </p>
    
     <p>
       <span class="WideLabel">个人习惯</span>
       <asp:TextBox ID="TextBox10" runat="server" Width="413px" Height="22px"></asp:TextBox> 
    </p>
    
     <p>
       <span class="WideLabel">兴趣爱好</span>
       <asp:TextBox ID="TextBox11" runat="server" Width="413px" Height="22px"></asp:TextBox> 
    </p>
    
     <p>
       <span class="WideLabel">工作编号</span>
       <asp:TextBox ID="TextBox12" runat="server" Width="413px" Height="22px"></asp:TextBox> 
    </p>
    
     <p>
       <span class="WideLabel">工作时间</span>
       <asp:TextBox ID="TextBox13" runat="server" Width="413px" Height="22px"></asp:TextBox> 
    </p>
    
     <p>
       <span class="WideLabel">职务</span>
       <asp:TextBox ID="TextBox14" runat="server" Width="413px" Height="22px"></asp:TextBox> 
    </p>
    
     <p>
       <span class="WideLabel">职称</span>
       <asp:TextBox ID="TextBox15" runat="server" Width="413px" Height="22px"></asp:TextBox> 
    </p>    
    </div>
    
    <div>
    <p>权限信息:</p>
    <p>
       <span class="WideLabel">职称</span>
       <asp:TextBox ID="TextBox25" runat="server" Width="413px" Height="22px"></asp:TextBox> 
    </p>    
    </div>
    
    <div>
    <p>其他信息:</p>
    <p>
       <span class="WideLabel">职称</span>
       <asp:TextBox ID="TextBox16" runat="server" Width="413px" Height="22px"></asp:TextBox> 
    </p>    
    </div>
    
    </form>
</body>
</html>
