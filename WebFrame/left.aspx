<%@ Page Language="C#" AutoEventWireup="true" CodeFile="left.aspx.cs" Inherits="left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />

    <title>菜单</title>

<style type="text/css">
body
{
	margin:0;
	padding:0;
}
html, body{height:100%;}
img
{
	border:none;
}
*
{
	font-family:'微软雅黑';
	font-size:12px;
	color:#626262;
}
dl,dt,dd
{
	display:block;
	margin:0;
}
a
{
	text-decoration:none;
}

#bg
{
  	background-image:url(../public/images/content/dotted.png);
}
.container
{
	width:100%;
	height:100%;
	margin:auto;
}
.biaoti
{ 
	text-align:left;
	/*菜单那个颜色*/
	background-color:#E1E8F7;
	width:100%;
	height:33px; 
	line-height:30px;
}

/*left*/
.leftsidebar_box
{
	width:100%;
	height:100%;
	background-color:#E9EEF3;
}
.line
{ 
	font-size:0px;
	height:1px;
	width:100%;
	/*每一个下拉框之间的颜色*/
	background-color:#E9EEF3;
	background-repeat:repeat-x;
}
.leftsidebar_box dt
{ 
	height:30px;
	padding-left:25px;
	padding-right:10px;
	background-repeat:no-repeat;
	background-position:10px center;
	color:#f5f5f5;
	font-size:14px;
	position:relative;
	line-height:30px;
	cursor:pointer; 
}
.leftsidebar_box dd
{
/*打开下拉框以后的背景颜色*/
	background-color:#E9EEF3;
	padding-left:30px;
}
.leftsidebar_box dd a
{ 
	font-size:12px;
	font-family: "宋体"; 
	/*里边字体的颜色*/
	color:#2E4FBE;
	line-height:25px; 
	height:25px;
}
.leftsidebar_box dt img
{
	position:absolute;
	right:10px;
	top:13px;
        left: 145px;
    }
/*.system_log dt{background-image:url(../public/images/left/system.png)}
.custom dt{background-image:url(../public/images/left/custom.png)}
.channel dt{background-image:url(../public/images/left/channel.png)}
.app dt{background-image:url(../public/images/left/app.png)}
.cloud dt{background-image:url(../public/images/left/cloud.png)}
.syetem_management dt{background-image:url(../public/images/left/syetem_management.png)}
.source dt{background-image:url(../public/images/left/source.png)}
.statistics dt{background-image:url(../public/images/left/statistics.png)}*/
.leftsidebar_box dl dd:last-child
{
	padding-bottom:0px;
}
.first_dd 
{ 
	padding-top:0px;
}
</style>
</head>

<body id="bg">
    <form id="form2" runat="server">
<div class="biaoti" >
   <span style="font-family:'宋体';color:#2E4FBE; font-weight:bold;font-size:14px;">
   <img style="vertical-align:middle;width:30px; height:30px;" src="../public/images/left/menu.png" alt="菜单管理" /> 
    菜单管理</span>&nbsp;     
</div>

<div class="container">
	<div class="leftsidebar_box">
		<dl class="system_log">
			<dt onclick="changeImage()"> 实验室管理<img src="../public/images/left/select_xl01.png" /></dt>
			<dd>&nbsp;</dd>
			<dd class="first_dd"><a href="renshixinxi.asp" target="mainFrame">> 人事信息</a></dd>		
			<dd class="first_dd"><a href="dangwuxinxi.asp" target="mainFrame">> 党务信息</a></dd>
			<dd class="first_dd"><a href="a_xueke.asp" target="mainFrame">> 学科信息</a></dd>
			<dd class="first_dd"><a href="keyanxinxi.asp" target="mainFrame">> 科研信息</a></dd>		
			<dd class="first_dd"><a href="benkexinxi.asp" target="mainFrame">> 本科信息</a></dd>		
			<dd class="first_dd"><a href="yanjiusheng.asp" target="mainFrame">> 研究生信息</a></dd>		
			<dd class="first_dd"><a href="guojihezuoxinxi.asp" target="mainFrame">> 国际合作信息</a></dd>		
			<dd class="first_dd"><a href="xueshengxinxi.asp" target="mainFrame">> 学生信息</a></dd>			
			<dd class="first_dd"><a href="xueyuanhuodongxinxi.asp" target="mainFrame">> 学院活动信息</a></dd>		
			<dd class="first_dd"><a href="xiaoyouxinxi.asp" target="mainFrame">> 校友信息</a></dd>
			<dd>&nbsp;</dd>
		</dl>
	    <div class="line">&nbsp;</div>
		<dl class="system_log">
			<dt onclick="changeImage()"> 试验管理<img src="../public/images/left/select_xl01.png" /></dt>
			<dd>&nbsp;</dd>
			<dd class="first_dd"><a href="xialakuangpeizhi.asp" target="mainFrame">> 下拉框配置</a></dd>
			<dd class="first_dd"><a href=" passwordChange.asp" target="mainFrame">> 个人密码修改</a></dd>
			<dd class="first_dd"><a href="guanliyuanFenPei.asp" target="mainFrame">> 管理员分配</a></dd>
			<dd class="first_dd"><a href="XiTongTongZhi.asp" target="mainFrame">> 系统通知</a></dd>
			<dd class="first_dd"><a href="bianhaozhuanhuan.asp" target="mainFrame">> 编号转换</a></dd>
			<dd>&nbsp;</dd>
		</dl>
		 <div class="line">&nbsp;</div>
		<dl class="system_log">
			<dt onclick="changeImage()"> 设备管理<img src="../public/images/left/select_xl01.png" /></dt>
			<dd>&nbsp;</dd>
			<dd class="first_dd"><a href="../ShowPage/DeviceManage/DeviceClass.aspx" target="mainFrame">> 设备种类</a></dd>		
			<dd class="first_dd"><a href= "../ShowPage/DeviceManage/DeviceInput.aspx" target="mainFrame">> 设备台账</a></dd>
			<dd class="first_dd"><a href="../ShowPage/DeviceManage/DeviceCheck.aspx" target="mainFrame">> 设备验收</a></dd>
			<dd class="first_dd"><a href="../ShowPage/DeviceManage/DeviceBorrow.aspx" target="mainFrame">> 设备借用</a></dd>		
			<dd class="first_dd"><a href= "../ShowPage/DeviceManage/DeviceBreakDown.aspx" target="mainFrame">> 设备故障</a></dd>		
			<dd class="first_dd"><a href="../ShowPage/DeviceManage/DeviceUnUsed.aspx" target="mainFrame">> 设备报废</a></dd>
			<dd>&nbsp;</dd>			
		</dl>
		 <div class="line">&nbsp;</div>
		<dl class="system_log">
			<dt onclick="changeImage()"> 客户管理<img src="../public/images/left/select_xl01.png" /></dt>
			<dd>&nbsp;</dd>
			<dd class="first_dd"><a href= "../ShowPage/Customer/CustomerManager.aspx" target="mainFrame">> 单位管理</a></dd>		
			<dd class="first_dd"><a href= "../ShowPage/Customer/CustomPersonManager.aspx" target="mainFrame">> 联系人管理</a></dd>
			<dd class="first_dd"><a href= "../ShowPage/Customer/CustomerMoney.aspx" target="mainFrame">> 客户收付款</a></dd>
			<dd class="first_dd"><a href="../ShowPage/Customer/CustomerHeTong.aspx" target="mainFrame">> 客户合同管理</a></dd>		
			<dd class="first_dd"><a href="../ShowPage/Customer/CustomerWeiTuoDan.aspx" target="mainFrame">> 客户委托单管理</a></dd>
			<dd class="first_dd"><a href="../ShowPage/Customer/CustomReporter.aspx" target="mainFrame">> 客户试验报告管理</a></dd>		
			<dd>&nbsp;</dd>			
		</dl>		
		 <div class="line">&nbsp;</div>
		<dl class="system_log">
			<dt onclick="changeImage()"> 合同管理<img src="../public/images/left/select_xl01.png" /></dt>
			<dd>&nbsp;</dd>
			<dd class="first_dd"><a href="ShowPage/BasicInfoManage/test.aspx" target="mainFrame">> 人事信息</a></dd>		
			<dd class="first_dd"><a href="dangwuxinxi.asp" target="mainFrame">> 党务信息</a></dd>
			<dd class="first_dd"><a href="a_xueke.asp" target="mainFrame">> 学科信息</a></dd>
			<dd class="first_dd"><a href="keyanxinxi.asp" target="mainFrame">> 科研信息</a></dd>		
			<dd class="first_dd"><a href="benkexinxi.asp" target="mainFrame">> 本科信息</a></dd>		
			<dd class="first_dd"><a href="yanjiusheng.asp" target="mainFrame">> 研究生信息</a></dd>		
			<dd class="first_dd"><a href="guojihezuoxinxi.asp" target="mainFrame">> 国际合作信息</a></dd>		
			<dd class="first_dd"><a href="xueshengxinxi.asp" target="mainFrame">> 学生信息</a></dd>			
			<dd class="first_dd"><a href="xueyuanhuodongxinxi.asp" target="mainFrame">> 学院活动信息</a></dd>		
			<dd class="first_dd"><a href="xiaoyouxinxi.asp" target="mainFrame">> 校友信息</a></dd>
			<dd>&nbsp;</dd>			
		</dl>
		
		 <div class="line">&nbsp;</div>
		<dl class="system_log">
			<dt onclick="changeImage()"> 供应商管理<img src="../public/images/left/select_xl01.png" /></dt>
			<dd>&nbsp;</dd>
			<dd class="first_dd"><a href= "../ShowPage/SupplierManage/SupplierManager.aspx" target="mainFrame">> 供应商基本资料</a></dd>		
			<dd class="first_dd"><a href="../ShowPage/SupplierManage/SupplierPersonManager.aspx" target="mainFrame">> 供应商联系人管理</a></dd>
			<dd class="first_dd"><a href="../ShowPage/SupplierManage/SupplierHistory.aspx"target="mainFrame">> 供应商品历史信息</a></dd>
			<dd>&nbsp;</dd>			
		</dl>
		 <div class="line">&nbsp;</div>
		<dl class="system_log">
			<dt onclick="changeImage()"> 资质管理<img src="../public/images/left/select_xl01.png" /></dt>
			<dd>&nbsp;</dd>
			<dd class="first_dd"><a href="renshixinxi.asp" target="mainFrame">> 人事信息</a></dd>		
			<dd class="first_dd"><a href="dangwuxinxi.asp" target="mainFrame">> 党务信息</a></dd>
			<dd class="first_dd"><a href="a_xueke.asp" target="mainFrame">> 学科信息</a></dd>
			<dd class="first_dd"><a href="keyanxinxi.asp" target="mainFrame">> 科研信息</a></dd>		
			<dd class="first_dd"><a href="benkexinxi.asp" target="mainFrame">> 本科信息</a></dd>		
			<dd class="first_dd"><a href="yanjiusheng.asp" target="mainFrame">> 研究生信息</a></dd>		
			<dd class="first_dd"><a href="guojihezuoxinxi.asp" target="mainFrame">> 国际合作信息</a></dd>		
			<dd class="first_dd"><a href="xueshengxinxi.asp" target="mainFrame">> 学生信息</a></dd>			
			<dd class="first_dd"><a href="xueyuanhuodongxinxi.asp" target="mainFrame">> 学院活动信息</a></dd>		
			<dd class="first_dd"><a href="xiaoyouxinxi.asp" target="mainFrame">> 校友信息</a></dd>
			<dd>&nbsp;</dd>
		</dl>
		 <div class="line">&nbsp;</div>
		<dl class="system_log">
			<dt onclick="changeImage()"> 档案资料管理<img src="../public/images/left/select_xl01.png" /></dt>
			<dd>&nbsp;</dd>
			<dd class="first_dd"><a href="renshixinxi.asp" target="mainFrame">> 人事信息</a></dd>		
			<dd class="first_dd"><a href="dangwuxinxi.asp" target="mainFrame">> 党务信息</a></dd>
			<dd class="first_dd"><a href="a_xueke.asp" target="mainFrame">> 学科信息</a></dd>
			<dd class="first_dd"><a href="keyanxinxi.asp" target="mainFrame">> 科研信息</a></dd>		
			<dd class="first_dd"><a href="benkexinxi.asp" target="mainFrame">> 本科信息</a></dd>		
			<dd class="first_dd"><a href="yanjiusheng.asp" target="mainFrame">> 研究生信息</a></dd>		
			<dd class="first_dd"><a href="guojihezuoxinxi.asp" target="mainFrame">> 国际合作信息</a></dd>		
			<dd class="first_dd"><a href="xueshengxinxi.asp" target="mainFrame">> 学生信息</a></dd>			
			<dd class="first_dd"><a href="xueyuanhuodongxinxi.asp" target="mainFrame">> 学院活动信息</a></dd>		
			<dd class="first_dd"><a href="xiaoyouxinxi.asp" target="mainFrame">> 校友信息</a></dd>
			<dd>&nbsp;</dd>
		</dl>
		 <div class="line">&nbsp;</div>
		<dl class="system_log">
			<dt onclick="changeImage()"> 分析报告管理<img src="../public/images/left/select_xl01.png" /></dt>
			<dd>&nbsp;</dd>
			<dd class="first_dd"><a href="renshixinxi.asp" target="mainFrame">> 人事信息</a></dd>		
			<dd class="first_dd"><a href="dangwuxinxi.asp" target="mainFrame">> 党务信息</a></dd>
			<dd class="first_dd"><a href="a_xueke.asp" target="mainFrame">> 学科信息</a></dd>
			<dd class="first_dd"><a href="keyanxinxi.asp" target="mainFrame">> 科研信息</a></dd>		
			<dd class="first_dd"><a href="benkexinxi.asp" target="mainFrame">> 本科信息</a></dd>		
			<dd class="first_dd"><a href="yanjiusheng.asp" target="mainFrame">> 研究生信息</a></dd>		
			<dd class="first_dd"><a href="guojihezuoxinxi.asp" target="mainFrame">> 国际合作信息</a></dd>		
			<dd class="first_dd"><a href="xueshengxinxi.asp" target="mainFrame">> 学生信息</a></dd>			
			<dd class="first_dd"><a href="xueyuanhuodongxinxi.asp" target="mainFrame">> 学院活动信息</a></dd>		
			<dd class="first_dd"><a href="xiaoyouxinxi.asp" target="mainFrame">> 校友信息</a></dd>
			<dd>&nbsp;</dd>
		</dl>
		 <div class="line">&nbsp;</div>
        <dl class="system_log">
			<dt onclick="changeImage()"> 基础资料管理<img src="../public/images/left/select_xl01.png" /></dt>
			<dd>&nbsp;</dd>
			<dd class="first_dd"><a href= "../ShowPage/BasicInfoManage/webDataDiction.aspx" target="mainFrame">> 字典管理</a></dd>		
			<dd class="first_dd"><a href="../ShowPage/BasicInfoManage/PersonManager.aspx" target="mainFrame">> 人员管理</a></dd>
			<dd class="first_dd"><a href="../ShowPage/BasicInfoManage/DepartmentManager.aspx"target="mainFrame">> 部门管理</a></dd>
			<dd class="first_dd"><a href= "../ShowPage/BasicInfoManage/PersonJueSe.aspx" target="mainFrame">> 用户与权限管理</a></dd>		
			<dd>&nbsp;</dd>
		</dl>
	    <div class="line">&nbsp;</div>
		<dl class="system_log">
			<dt onclick="changeImage()"> 设置<img src="../public/images/left/select_xl01.png" /></dt>
			<dd>&nbsp;</dd>
			<dd class="first_dd"><a href="xialakuangpeizhi.asp" target="mainFrame">> 下拉框配置</a></dd>
			<dd class="first_dd"><a href=" passwordChange.asp" target="mainFrame">> 个人密码修改</a></dd>
			<dd class="first_dd"><a href="guanliyuanFenPei.asp" target="mainFrame">> 管理员分配</a></dd>
			<dd class="first_dd"><a href="XiTongTongZhi.asp" target="mainFrame">> 系统通知</a></dd>
			<dd class="first_dd"><a href="bianhaozhuanhuan.asp" target="mainFrame">> 编号转换</a></dd>
			<dd>&nbsp;</dd>
		</dl>
		
		
	</div>
</div>

<script type="text/javascript" src="../public/js/jquery.js"></script>
<script type="text/javascript">
$(".leftsidebar_box dt").css({"background-color":"#008cd6"});
$(".leftsidebar_box dt img").attr("src","../public/images/left/select_xl01.png");
$(function(){
	$(".leftsidebar_box dd").hide();
	$(".leftsidebar_box dt").click(function(){
		$(".leftsidebar_box dt").css({"background-color":"#008cd6"})
		$(this).css({"background-color": "#008cd6"});
		$(this).parent().find('dd').removeClass("menu_chioce");
		$(".leftsidebar_box dt img").attr("src", "../public/images/left/select_xl01.png");
		$(this).parent().find('img').attr("src", "../public/images/left/select_xl.png");
		$(".menu_chioce").slideUp(); 
		$(this).parent().find('dd').slideToggle();
		$(this).parent().find('dd').addClass("menu_chioce");
	});
	
	$(".leftsidebar_box dd").click(function(){
	$(".leftsidebar_box dd").css({"background-color":"#E9EEF3"})
		$(this).css({"background-color": "#C8D7EC"});
	});	
	
	$("a").bind("focus",function() {
     if(this.blur) {this.blur()};
    });
	
})
</script>

    </form>

</body>
</html>
