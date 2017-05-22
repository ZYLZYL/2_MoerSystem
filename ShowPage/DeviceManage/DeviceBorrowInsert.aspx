<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeviceBorrowInsert.aspx.cs" Inherits="ShowPage_DeviceManage_DeviceBorrowInsert" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=emulateIE7" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" type="text/css" href="../../public/css/style.css" />
<link rel="stylesheet" type="text/css" href="../../public/css/WdatePicker.css" />
<link rel="stylesheet" type="text/css" href="../../public/css/skin_/form.css" />
<link href="../../public/umeditor/themes/default/_css/umeditor.css" type="text/css" rel="stylesheet"/>

<title>基础信息</title>
</head>

<body>
<div id="container">
    	<div id="main">
            <h2 class="subfild">
            	<span>设备申请</span>
            </h2>
            <span><asp:Label ID="statusLabel" runat="server" CssClass="AdminError"></asp:Label></span>
            <div class="subfild-content base-info">
            <form id="form1" runat="server">
            	<div class="kv-item ue-clear"  >
                	<label ><span class="impInfo">*</span>物品领用状态</label>
                	<div class="kv-item-content" >
                    	<asp:TextBox ID="zhuangtai" runat="server" placeholder="物品领用状态" readOnly="true">申请</asp:TextBox> 
                    </div>
                    <span class="kv-item-tip"></span>
                    <label >物品领用方式</label>
                	<div class="kv-item-content" >
                    	<select>
                        	<option>领用</option>
                            <option>借用</option>
                            <option>外借</option>
                        </select>
                    </div>
                </div>
                <div class="kv-item ue-clear">
                	<label ><span class="impInfo">*</span>物品领用申请人</label>
                	<div class="kv-item-content" ">
                    	<asp:TextBox ID="shengqingren" runat="server" placeholder="物品领用申请人"></asp:TextBox> 
                    </div>
                    <span class="kv-item-tip"></span>
                    <label ><span class="impInfo">*</span>物品领用申请时间</label>
                	<div class="kv-item-content" ">
                    	<asp:TextBox ID="shijain" runat="server" type="datetime-local" placeholder="物品领用申请时间" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox>
                    </div>
                </div>
                <div class="kv-item ue-clear">
                	<label ><span class="impInfo">*</span>物品领用人</label>
                	<div class="kv-item-content" ">
                    	<asp:TextBox ID="lingyongren" runat="server" placeholder="物品领用人"></asp:TextBox> 
                    </div>
                    <span class="kv-item-tip"></span>
                    <label ><span class="impInfo">*</span>物品领用经办人</label>
                	<div class="kv-item-content" ">
                    	<asp:TextBox ID="jingbanren" runat="server" placeholder="物品领用经办人"></asp:TextBox> 
                    </div>
                </div>
                <div class="kv-item ue-clear" >
                	<label ><span class="impInfo" >*</span>物品领用部门</label>&nbsp;
                	<div class="kv-item-content" <div class="kv-item-content" ">
                    	<asp:TextBox ID="bumen" runat="server" placeholder="物品领用部门"></asp:TextBox> 
                    </div>
                    <span class="kv-item-tip"></span>
                    <label ><span class="impInfo">*</span>物品领用单位</label>
                	<div class="kv-item-content" ">
                    	<asp:TextBox ID="danwei" runat="server" placeholder="物品领用单位"></asp:TextBox> 
                    </div>
                </div>
                 <div class="kv-item ue-clear">
                	<label ><span class="impInfo">*</span>物品领用申请说明</label>
                	<div class="kv-item-content" ">
                    	<asp:TextBox ID="shuoming" runat="server" placeholder="物品领用申请说明"></asp:TextBox> 
                    </div>
                    <span class="kv-item-tip"></span>
                    <label ><span class="impInfo">*</span>申请领用物品（一对多）</label>
                	<div class="kv-item-content" ">
                    	<asp:TextBox ID="wuping" runat="server" placeholder="申请领用物品"></asp:TextBox> 
                    </div>
                </div>
                
                <div class="buttons">
                    <asp:Button ID="createDeviceBorrow"  runat="server" class="button" Text="提交" />
                </div>
            </form>
        </div>
    </div>
</div>
</body>


</html>
