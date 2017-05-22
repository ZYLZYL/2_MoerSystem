<%@ Page Language="C#" AutoEventWireup="true" CodeFile="inserttest.aspx.cs" Inherits="ShowPage_BasicInfoManage_inserttest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <div id="top"> </div>
        <form id="login" name="login" action="?Action=Login" method="post">
            <div id="center">
            <div id="center_left"></div>
            <div id="center_middle">
                <div class="user">
                    <label>用户名：
                        <input type="text" name="UserName" id="UserName" />
                    </label>
                </div>
                <br />
                <div class="user">
                    <label>密　码：
                        <input type="password" name="UserPassword" id="UserPassword" />
                    </label>
                </div>
            </div>
            <div id="center_middle_right"></div>
            <div id="center_submit">
                <div class="button"> <img alt="" id="loginin" src="images/dl.gif" width="57" height="20" onclick="document.login.submit()"/> </div>
                <div class="button"> <img alt="" id="loginreset" src="images/cz.gif" width="57" height="20" onclick="document.login.reset()"/> </div>
            </div>
            <div id="center_right"></div>
            </div>
        </form>
    <div id="footer"></div>
</body>
</html>
