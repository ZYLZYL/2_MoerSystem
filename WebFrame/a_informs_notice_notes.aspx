<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
</script>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<meta http-equiv="Content-Language" content="zh-cn" />
<title>板块列表</title>
<link href="../public/css/wangyebiaoge1.css" rel="stylesheet" type="text/css"/>
<script type="text/javascript" src="../public/js/wangyestyle1.js"></script>
<script src="../public/js/jquery-1.2.4b.js" type="text/javascript"></script>
<script src="../public/js/ui.core.js" type="text/javascript"></script>
<script src="../public/js/ui.tabs.js" type="text/javascript"></script>
<script type="text/javascript">
            $(function() {
                $('#rotate > ul').tabs({ fx: { opacity: 'toggle' } }).tabs('rotate', 4000);
            });
        </script>

<style type="text/css">

#time
{
 font-size:12px; 
color: #959595;
}
.STYLE4
{
font-family:"黑体", "宋体";
font-size:12px;
clear:left;
}
ul#nav1
{ 
   width:100%; 
} 

ul#nav1 li
{
   display:inline;
   float:left;
   margin:50px 100px 50px 100px;
   text-align:center;
   vertical-align:middle;
   height:164px;
   width:150px;
   background-color:#E1E8F7;
   padding:0px;
} 

/*:inline-block;

ul#nav1 li a{ 
   display:list-item  
   padding:0 5px; 
   font-family:"\5FAE\8F6F\96C5\9ED1"; 
   font-size:14px; 
   font-weight:bold;
   text-decoration:none;
    height:164px;
   width:150px;
   background-color:#E1E8F7;
} 

ul#nav1 li a:hover
{ 
background-color:#C8D7EC;
  
} 
* img 
{
border:none;
}
table
{
   table-layout: fixed;
}	

td
{
	white-space: nowrap;
	overflow: hidden;
	text-overflow: ellipsis;	
}

ul
{
    list-style:none
 }

#navigator
{
   position:absolute;
   left:80%;
   top:95%
}

#table1 
{ 
    float:left; 
    width:60%; 
    height:80%; 
    margin:2% 0 0 0 ; 
    padding:1% 1% 0 0.5%;
    border:5px 
    solid #E1E8F7;
}
#table2 { float:right; width:34%; height:80%; margin:2% 0.5% 0 0; padding:1% 1% 0 0.5%;border:5px solid #E1E8F7;}
#footer { clear:both;}
a.classa:link {color: #000000;}              
a.classa:visited {color: #000000;}           
a.classa:hover { text-decoration:underline; }          
a.classa:active {color: #000000;}   

.new{ 
display:none;
}
-->
</style>
 
<link rel="stylesheet" href="../public/css/ui.tabs.css" type="text/css" media="print, projection, screen">
<style type="text/css" media="screen, projection">
/* Not required for Tabs, just to make this demo look better... */
body, h1, h2 { font-family: "Trebuchet MS", Trebuchet, Verdana, Helvetica, Arial, sans-serif; }
h1 { margin: 1em 0 1.5em; font-size: 18px; }
h2 { margin: 2em 0 1.5em; font-size: 16px; }
p { margin: 0; }
pre, pre+p, p+p { margin: 1em 0 0; }
code { font-family: "Courier New", Courier, monospace; }
</style>
</head>

<body>

<div style="border:1; width:100%;" id="location" >
<img style="margin-top:1px; vertical-align:middle "  width="30" height="30" src="../public/images/main/fangzi.jpg" alt="当前位置" />
<span class="STYLE92"> 当前位置：</span>
<span class="STYLE94"><strong>公司通知</strong></span>
</div>

<div id="table1" class="info">

<table border="0" width="100%"  cellpadding="0"cellspacing="1">
	<tr>
	    <td width="53%" ></td>
	    <td width="24%"></td>
	<tr style="background-color:#E1E8F7;color:#000000;font-size:14px; height:25px">
		<td align="left" style="border-bottom:dashed; border-bottom-width:2px; border-bottom-color: #E1E8F7; margin-top:5px;"  colspan="3">&nbsp;<span class="STYLE94"><strong><a href="a_informs.asp">公司通知</a></strong></span>&nbsp;&nbsp;
			
			&nbsp;<span ><strong><a href="a_informs_notice_notes_informs_insert.asp">
			<button>发布通知</button></a></strong></span>
	  </td>
		<td width="23%"><a href="a_informs.asp">more..</a></td>
	</tr>

	<tr style="font-size:12px;margin-bottom:5px">
		<td align="left" style="color:#333333; width: 65%; height:20px; margin:3px 0;font-size:12px;"><img src="../public/images/imgs/notice.png" width="10" height="13" />&nbsp;
		通知类别|<a class="classa" href="#" target="mainFrame">标题></a>
			&nbsp;
		</td>
		<TD>时间</TD>
		<td style="font-size:12px; width:35%; font-style:color:#959595" align="right" colspan="2"><span id="time"></span></td>
	</tr>

</table>
</div>





<div id="footer"></div>

</body>
</html>
