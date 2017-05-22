<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DepartmentManagerInsert.aspx.cs" Inherits="ShowPage_BasicInfoManage_DepartmentManagerInsert" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=emulateIE7" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" type="text/css" href="../../public/css/style.css" />
<link rel="stylesheet" type="text/css" href="../../public/css/WdatePicker.css" />
<link rel="stylesheet" type="text/css" href="../../public/css/skin_/form.css" />
<link href="../../public/css/Main.css" type="text/css" rel="stylesheet" />

<title>基础信息</title>
</head>

<body  >
<table width="100%" border="0" cellpadding="0" cellspacing="0">
      <tr> 
        <td style="height:20px;background-color: #8CA1AE;"align="center" >
          <table width="157" style="height:100%" border="0" cellpadding="0" cellspacing="0">
            <tr> 
              <td  style="background-image: url(../../public/images/bg.gif); text-align:center">部门新增</td>
            </tr>
          </table>
        </td>
      </tr>
 </table>     
<div id="container">
    	<div id="main">
            <h2 class="subfild">
            	<span>设备申请</span>
            </h2>
            <span><asp:Label ID="statusLabel" runat="server" CssClass="AdminError"></asp:Label></span>
            <div class="subfild-content base-info">
            <form id="form1" runat="server">
            	
                <div class="kv-item ue-clear">
                	<label style="width:6%"><span class="impInfo">*</span>部门名字</label>
                	<div class="kv-item-content" ">
                    	<asp:TextBox ID="DepartmentName" runat="server" placeholder="部门名字"></asp:TextBox> 
                    </div>
                    <span class="kv-item-tip"></span>
                    <label style="width:6%"><span class="impInfo">*</span>部门主管人编号</label>
                	<div class="kv-item-content" ">
                    	<asp:TextBox ID="DepartmentPersonNo" runat="server" placeholder="部门主管人编号" ></asp:TextBox>
                    </div>
                </div>
                <div class="kv-item ue-clear">
                	<label style="width:6%"><span class="impInfo">*</span>部门电话1</label>
                	<div class="kv-item-content" ">
                    	<asp:TextBox ID="DepartmentPhone1" runat="server" placeholder="部门电话1"></asp:TextBox> 
                    </div>
                    <span class="kv-item-tip"></span>
                    <label style="width:6%"><span class="impInfo">*</span>部门电话2</label>
                	<div class="kv-item-content" ">
                    	<asp:TextBox ID="DepartmentPhone2" runat="server" placeholder="部门电话2"></asp:TextBox> 
                    </div>
                </div>
                <div class="kv-item ue-clear" >
                	<label style="width:6%"><span class="impInfo" >*</span>部门简介</label>&nbsp;
                	<div class="kv-item-content" <div class="kv-item-content" ">
                    	<asp:TextBox ID="DepartmentWork" runat="server" placeholder="部门简介"></asp:TextBox> 
                    </div>
                    <span class="kv-item-tip"></span>
                    <label style="width:6%"><span class="impInfo">*</span>部门文件编号</label>
                	<div class="kv-item-content" ">
                    	<asp:TextBox ID="DepartmentInfoFileNo" runat="server" placeholder="部门文件编号"></asp:TextBox> 
                    </div>
                </div>
                 <div class="kv-item ue-clear">
                	<label style="width:6%"><span class="impInfo">*</span>部门节点编号</label>
                	<div class="kv-item-content" ">
                    	<asp:TextBox ID="DepartmentNodeNo" runat="server" placeholder="部门节点编号"></asp:TextBox> 
                    </div>
                </div>
                
                <div class="buttons">
                    <asp:Button ID="Button1" runat="server" Text="提交" Height="35px" onclick="createDepartment_Click"
                        Width="119px" />
                </div>
            </form>
        </div>
    </div>
</div>
</body>


</html>

