<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link href="public/css/Main.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="public/css/myjs.js"></script>
    <title>系统登录</title>

    <script type="text/javascript">
        function SetFocus() {
            var obj = document.getElementById("UserName");  //设置光标焦点，使用时可在body中加入upload，目前禁用，避免和判断分辨率程序冲突
            if (obj.value == "") {
                obj.focus();
            }
            else
                obj.select();
        }
        if (parent.location.href.indexOf("Admin_Index") > 0) {
            top.location.href = "default.aspx"
        };

        function ref() {
            refresh;
        }
    </script>

    <style type="text/css">
        .style1
        {
            color: #000099;
        }
        .style2
        {
            width: 134px;
        }
    </style>
</head>

<body id="MyBody" runat="server" leftmargin="0" topmargin="0" marginwidth="0" marginheight="0"
    style='overflow: scroll; '>
    <form id="browserpeek" runat="server" method="post" name="_DominoForm">
    <table height="100%" cellspacing="0" cellpadding="0" width="100%" border="0">
        <tbody>
            <tr height="171">
                <td align="left" width="540" height="236" background="public/images/login_hk.jpg">
                </td>
                <td bgcolor="#3d7acd" height="236">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td bgcolor="#3d7acd" colspan="2">
                    &nbsp;
                </td>
            </tr>
        </tbody>
    </table>
    <div id="div0" style="border-right: #000000 0px; border-top: #000000 0px; left: 30%;
        overflow: hidden; border-left: #000000 0px; width: 432px; border-bottom: #000000 0px;
        position: absolute; top: 28%; height: 282px">
        <table height="26" cellspacing="0" cellpadding="0" width="100%" border="0">
            <tbody>
                <tr>
                    <td align="left" width="22" background="public/images/ground_topleft.gif" height="26">
                        &nbsp;
                    </td>
                    <td background="public/images/ground_topfill.gif" height="26">
                        &nbsp;
                    </td>
                    <td align="right" width="22" background="public/images/ground_topright.gif" height="26"
                        bgproperties="FIXED">
                        &nbsp;
                    </td>
                </tr>
            </tbody>
        </table>
        <table height="40" cellspacing="0" cellpadding="0" width="100%" background="public/images/ground_middlefill.gif"
            border="0" bgproperties="FIXED">
            <tbody>
                <tr class="Outline2" valign="middle" height="26">
                    <td valign="middle" align="right">
                        &nbsp;
                    </td>
                </tr>
                <tr height="14">
                    <td>
                    </td>
                </tr>
            </tbody>
        </table>
        <table cellspacing="0" cellpadding="0" width="100%" background="public/images/ground_middlefill.gif"
            border="0" bgproperties="FIXED">
            <tbody>
                <tr>
                    <td width="40">
                    </td>
                    <td valign="top" align="right" width="95">
                        <table height="100%" cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tbody>
                                <tr height="71">
                                    <td align="right" width="100%" height="71">
                                        <img height="71" src="public/images/login_pic.gif" width="71" border="0">
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100%" height="8">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Outline1" align="right" height="12">
                                        <font color="navy">欢迎登陆</font>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100%" height="2">
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100%" align="right" height="12">
                                        <font color= "navy">请输入相关信息</font>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                    </td>
                </tr>
            </tbody>
        </table>
        <td width="40">
        </td>
        <td width="248" height="130">
            <table height="100%" cellspacing="0" cellpadding="0" width="100%" border="0">
                <tbody>
                    <tr height="14" width="100%">
                        <td class="style2">
                        </td>
                    </tr>
                    <tr height="4" width="100%">
                        <td class="style2">
                        </td>
                    </tr>
                    <tr height="17">
                        <td align="right" height="17" class="style2">
                            <font size="2" align="right"><span class="style1">用户名：</span>
                        </td>
                        <td height="17">
                            <asp:TextBox ID="UserName" CssClass="mytext" MaxLength="16" runat="server" Width="160px"></asp:TextBox><asp:RequiredFieldValidator
                                ID="Requiredfieldvalidator1" runat="server" ErrorMessage="*" Display="Static"
                                ControlToValidate="UserName"></asp:RequiredFieldValidator>
                            <td width="36">
                            </td>
                    </tr>
                    <tr height="4" width="100%">
                        <td class="style2">
                        </td>
                    </tr>
                    <tr height="17">
                        <td align="right" height="17" class="style2">
                            <span class="style1">密&nbsp;码：</span>
                        </td>
                        <td height="17">
                            <asp:TextBox ID="UserPass" runat="server" CssClass="mytext" TextMode="Password" MaxLength="16"
                                Width="160px"></asp:TextBox><asp:RequiredFieldValidator ID="Requiredfieldvalidator2"
                                    runat="server" ErrorMessage="*" Display="Static" ControlToValidate="UserPass"></asp:RequiredFieldValidator>
                            <td width="36">
                            </td>
                    </tr>
                    <tr height="4" width="100%">
                        <td class="style2">
                        </td>
                    </tr>
                    <tr height="17">
                        <td align="right" height="17" class="style2">
                        </td>
                        <td width="46">
                        </td>
                        <td width="36">
                        </td>
                    </tr>
                    <tr height="17">
                        <td height="17" class="style2">
                            &nbsp;
                        </td>
                        <td height="17" colspan="2">
                            <asp:Button ID="LoginBtn" OnClick="LoginBtn_Click" runat="server" Text=" 登陆 " CssClass="mybutton">
                            </asp:Button>
                        </td>
                    </tr>
                    <tr height="17">
                        <td height="17" class="style2">
                            &nbsp;
                        </td>
                        <td height="17" align="right">
                            <span class="style1"></span>
                        </td>
                        <td width="36">
                        </td>
                    </tr>
                </tbody>
            </table>
        </td>
        <table height="22" cellspacing="0" cellpadding="0" width="100%" background="public/images/ground_fill.gif"
            border="0">
            <tbody>
                <tr>
                    <td width="432" height="4">
                        <img height="4" src= "public/images/ground_dsn.gif" width="434" border="0" name="dsn">
                    </td>
                </tr>
                <tr>
                    <td width="432" height="18" align="center">
                        <asp:Label ID="Msg" runat="server" ForeColor="red"></asp:Label>
                    </td>
                </tr>
            </tbody>
        </table>
        <table height="9" cellspacing="0" cellpadding="0" width="100%" border="0">
            <tbody>
                <tr>
                    <td height="9">
                        <img height="9" src="public/images/ground_btn_bottom.gif" width="434" border="0">
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    </form>
</body>
</html>
