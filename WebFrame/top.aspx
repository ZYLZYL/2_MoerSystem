<%@ Page Language="C#" AutoEventWireup="true" CodeFile="top.aspx.cs" Inherits="top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>top</title>
<link href="../public/css/Main.css" type="text/css" rel="stylesheet" />
<script type="text/javascript" src= "../public/css/myjs.js"></script>    

<script type="text/javascript">
<!--
    function shleft() {
        if (parent.cen.cols == "0,*") {
            parent.cen.cols = "180,*,"
            document.getElementById("shleft").src = "../public/images/maxsize.gif"
            document.getElementById("shleft").alt = "收缩菜单栏";
        }
        else {
            parent.cen.cols = "0,*"
            document.getElementById("shleft").src = "../public/images/rest.gif"
            document.getElementById("shleft").alt = "还原菜单栏";
        }
    }
-->
</script>
    <style type="text/css">
        .style1
        {
            width: 105px;
        }
    </style>
</head>
<body  style="margin-top:0px; margin-right:0px; margin-bottom:0px; margin-left:0px;">
    <form id="form1" runat="server">
    <div>
    <table width="100%" height="82" border="0" cellpadding="0" cellspacing="0">

    <!--第一行-->    
    <tr> 
      <td>
      <table width="100%"  border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td class="style1" style=" background-color:#008cd6"><a href="~/" target="_blank"><img src="../public/images/logo.png" border="0"></a></td>
          <td align="right" valign="top" style=" background-color:#008cd6">
          <table width="100%"  border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td align="right" style=" background-color:">                
		            <a class="top_text" href='javascript:shleft();'><img src="../public/images/maxsize.gif" name="shleft" id="shleft" border=0 value="隐藏" alt="收缩菜单栏"></a>
                    <a href="#" onclick=javascript:if(confirm("确认要退出系统吗？")){location.href="logout.aspx?id=1";top.window.close();}><font color=red>退出系统</font></a>&nbsp;
                    <p><font color="#ffffff"><div id="date"></div></font>
                </td>
              </tr>
            </table></td>
        </tr>
      </table></td>
  </tr>
  <tr>
  <td height="27" background="../public/images/topbg.jpg">
  <table width="100%"  border="0" cellspacing="0" cellpadding="0">
        <tr>
          
          <td valign="bottom">&nbsp;&nbsp;</td>
		  <td align="right" valign="bottom">
                <a href="../a_informs_notice_notes.aspx" target="mainFrame" class="top_text"><img src="../public/images/index.gif" border="0" alt="主页" />主页</a>
                <a href="../dbsy.aspx" target="mainFrame" class="top_text"><img src="../public/images/work.gif" border="0" alt="您待办的工作列表" />待办事宜</a>
                <a href="#" onclick="javascript:popAdd('/txl.aspx');" class="top_text"><img src="../public/images/book.gif" border="0" alt="查看人员通讯信息" />通讯录</a>		        
		  </td>
        </tr>
      </table> </td>
  </tr>
</table>
    </div>
    </form>
</body>

<script language="javascript">

    function times() {
        var date = document.getElementById("date");
        var d = new Date();
        var arr = ["日", "一", "二", "三", "四", "五", "六"];
        date.innerHTML = "今天是:&nbsp;&nbsp;" + d.getFullYear() + "年" + (d.getMonth() + 1) + "月" + d.getDate() + "日" + "&nbsp;&nbsp;" + d.getHours() + ":" + d.getMinutes() + ":" + d.getSeconds() + "&nbsp;&nbsp;" + "星期" + arr[d.getDay()];
    }
    window.onload = function() {
        setInterval(function() {
            times();
        }, 1000);
        var hh = document.getElementById("hh").value;
        setInterval(function() {

            var xmlhttp;
            if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                xmlhttp = new XMLHttpRequest();
            }
            else {// code for IE6, IE5
                xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            }
            xmlhttp.onreadystatechange = function() {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                    document.getElementById("num").innerHTML = xmlhttp.responseText;
                }
            }
            //xmlhttp.open("GET", "TopFrame_news.asp", true);
            //xmlhttp.send();
        }, 1000);
    }

    var out = document.getElementById("out")
    out.onclick = function() {
        //window.parent.location.replace("index.html");
    }

    out.onmouseover = function() {
        out.style.color = "red";
    }
    out.onmouseout = function() {
        out.style.color = "white";
    }

</script>
</html>

