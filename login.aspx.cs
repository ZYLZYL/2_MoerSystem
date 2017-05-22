using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string url = null;
        url = Request.QueryString["formurl"];
        //取到链接地址中的值 
        if (url != "MyLogin")
        {
            //根据链接地址中的url值判断是否继续进入登录界面 
            //返回到第一页 
            Response.Redirect("default.aspx");
        }

        Button Button1 = new Button();
        //开始判断客户端显示分辨率 
        if (!IsPostBack)
        {
            HtmlInputHidden btnW = new HtmlInputHidden();
            HtmlInputHidden btnH = new HtmlInputHidden();

            Button1.ID = "Button1";
            Button1.CssClass = "btnhide";

            //利用css样式将该按钮隐藏显示 
            btnW.Name = "WidthPixel";
            btnW.ID = "WidthPixel";
            btnH.Name = "HeightPixel";
            btnH.ID = "HeightPixel";

            FindControl("browserpeek").Controls.Add(btnW);
            FindControl("browserpeek").Controls.Add(btnH);
            FindControl("browserpeek").Controls.Add(Button1);

            string scriptString = "";
            scriptString += "document.browserpeek.WidthPixel.value=window.screen.width;";
            scriptString += "document.browserpeek.HeightPixel.value=window.screen.height;";
            ClientScript.RegisterOnSubmitStatement(this.GetType(), "Meng", scriptString);
            MyBody.Attributes.Add("onload", "document.browserpeek.Button1.click();");
        }
        else
        {
            MyBody.Attributes.Remove("onload");
            if (this.FindControl("browserpeek").Controls.Contains(Button1))
            {
                this.FindControl("browserpeek").Controls.Remove(Button1);
                Button1.Dispose();
            }
            StringBuilder strLabel = new StringBuilder();

            HttpBrowserCapabilities bc = Request.Browser;
            //首先集中指定一级cookies的过期时间 
            Response.Cookies["huayi"].Expires = new DateTime(2020, 1, 1);
            Response.Cookies["hygk"].Expires = new DateTime(2020, 1, 1);

            if (Request.Cookies["mretail_defiw"] == null)
            {
                //判断cookies是否不存在 
                if (Request.Form["WidthPixel"] == "1024" & Request.Form["HeightPixel"] == "768")
                {
                    Response.Cookies["mretail_defiw"].Value = "815";
                    Response.Cookies["mretail_defih"].Value = "510";
                    Response.Cookies["mretail_defiw"].Expires = new DateTime(2015, 1, 1);
                    Response.Cookies["mretail_defih"].Expires = new DateTime(2015, 1, 1);
                }
                else
                {
                    if (Request.Form["WidthPixel"] == "800" & Request.Form["HeightPixel"] == "600")
                    {
                        Response.Cookies["mretail_defiw"].Value = "768";
                        Response.Cookies["mretail_defih"].Value = "338";
                        Response.Cookies["mretail_defiw"].Expires = new DateTime(2020, 1, 1);
                        Response.Cookies["mretail_defih"].Expires = new DateTime(2020, 1, 1);
                    }
                    else
                    {
                        if (Request.Form["WidthPixel"] == "1280" & Request.Form["HeightPixel"] == "800")
                        {
                            Response.Cookies["mretail_defiw"].Value = "1070";
                            Response.Cookies["mretail_defih"].Value = "540";
                            Response.Cookies["mretail_defiw"].Expires = new DateTime(2020, 1, 1);
                            Response.Cookies["mretail_defih"].Expires = new DateTime(2020, 1, 1);
                        }
                        else
                        {
                            if (Request.Form["WidthPixel"] == "1280" & Request.Form["HeightPixel"] == "768")
                            {
                                Response.Cookies["mretail_defiw"].Value = "1070";
                                Response.Cookies["mretail_defih"].Value = "530";
                                Response.Cookies["mretail_defiw"].Expires = new DateTime(2020, 1, 1);
                                Response.Cookies["mretail_defih"].Expires = new DateTime(2020, 1, 1);
                            }
                            else
                            {
                                if (Request.Form["WidthPixel"] == "1280" & Request.Form["HeightPixel"] == "1024")
                                {
                                    Response.Cookies["mretail_defiw"].Value = "1070";
                                    Response.Cookies["mretail_defih"].Value = "780";
                                    Response.Cookies["mretail_defiw"].Expires = new DateTime(2020, 1, 1);
                                    Response.Cookies["mretail_defih"].Expires = new DateTime(2020, 1, 1);
                                }
                                else
                                {
                                    if (Request.Form["WidthPixel"] == "1360" & Request.Form["HeightPixel"] == "769")
                                    {
                                        Response.Cookies["mretail_defiw"].Value = "1070";
                                        Response.Cookies["mretail_defih"].Value = "780";
                                        Response.Cookies["mretail_defiw"].Expires = new DateTime(2020, 1, 1);
                                        Response.Cookies["mretail_defih"].Expires = new DateTime(2020, 1, 1);
                                    }
                                    else
                                    {
                                        if (Request.Form["WidthPixel"] == "1366" & Request.Form["HeightPixel"] == "768")
                                        {
                                            Response.Cookies["mretail_defiw"].Value = "1070";
                                            Response.Cookies["mretail_defih"].Value = "780";
                                            Response.Cookies["mretail_defiw"].Expires = new DateTime(2020, 1, 1);
                                            Response.Cookies["mretail_defih"].Expires = new DateTime(2020, 1, 1);
                                        }
                                        else
                                        {
                                            Response.Cookies["mretail_defiw"].Value = "1150";
                                            Response.Cookies["mretail_defih"].Value = "530";
                                            Response.Cookies["mretail_defiw"].Expires = new DateTime(2020, 1, 1);
                                            Response.Cookies["mretail_defih"].Expires = new DateTime(2020, 1, 1);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    protected void LoginBtn_Click(object Sender, EventArgs E)
    {
        if (Page.IsValid)
        {
            //密码解密 
            byte[] data = System.Text.Encoding.Unicode.GetBytes(UserPass.Text.ToCharArray());
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(data);
            string sResult = System.Text.Encoding.Unicode.GetString(result);
            string EnPswdStr = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(UserPass.Text.ToString(), "MD5");

            //临时向上移动
            Server.Transfer("main.aspx");
            /*
            Socut.Reader dataR = new Socut.Reader("select a.*,b.bm_mc from yh a left outer join bm b on (a.ui_ssbm=b.bm_id) where ui_id='" + UserName.Text + "' and ui_pwd='" + EnPswdStr + "'");
            if (dataR.Read())
            {
                //如果存在用户 
                if (dataR["ui_status"].ToString() == "正常")
                {
                    //如果正常状态 
                    if ((DateTime)dataR["ui_sdate"] < DateTime.Today & (DateTime)dataR["ui_edate"] > DateTime.Today)
                    {
                        //判断该用户是否在有效期范围内 
                        Response.Cookies["hyyc"]["hyid_carol"] = dataR["ui_id"].ToString();
                        //登录用户ID 
                        Response.Cookies["huayi"]["yhxm"] = Server.UrlEncode(dataR["ui_desc"].ToString());
                        //Server.UrlEncode用来防止中文Cookies显示乱码 
                        Response.Cookies["huayi"]["dlsj"] = DateTime.Now.ToString();
                        //当前用户的登录时间 
                        Response.Cookies["hycs"]["yndx"] = dataR["ui_yndx"].ToString();
                        //当前用户是否可以发送短信 
                        Response.Cookies["hycs"]["yxdz"] = dataR["mail_qc"].ToString();
                        //个人发送邮箱地址 
                        Response.Cookies["hycs"]["smtp"] = dataR["mail_smtp"].ToString();
                        //个人发送邮箱的smtp地址 
                        Response.Cookies["hycs"]["dlid"] = dataR["mail_dlyh"].ToString();
                        //个人发送邮箱的登录用户名 
                        Response.Cookies["hycs"]["dlmm"] = dataR["mail_dlmm"].ToString();
                        //个人发送邮箱的登录密码 
                        Response.Cookies["hycs"]["port"] = dataR["mail_port"].ToString();
                        //个人发送邮箱的端口 
                        Response.Cookies["hycs"]["fsr"] = Server.UrlEncode(dataR["mail_fsr"].ToString());
                        //个人发送邮箱的发送人签名 
                        Response.Cookies["hygk"]["sess"] = Session.SessionID;
                        //记录当前登录用户的session.id 
                        Response.Cookies["hyyc"]["hylx_carol"] = "q";
                        //登录用户类型 
                        Response.Cookies["huayi"]["dljg"] = Server.UrlEncode(dataR["bm_mc"].ToString());
                        //设定所属部门名称 
                        Response.Cookies["huayi"]["dlbm"] = dataR["ui_ssbm"].ToString();
                        //设定所属部门编码 

                        dataR.Close();
                        //初始化待办事宜权限 
                        Socut.Reader dr = new Socut.Reader("select * from yh_work where ui_id='" + UserName.Text + "'");
                        //企业全称、企业简称和企业品牌 
                        if (dr.Read())
                        {
                            Response.Cookies["hycs"]["c1"] = dr["c1"].ToString();
                            //常用类 
                            Response.Cookies["hycs"]["c3"] = dr["c3"].ToString();
                            Response.Cookies["hycs"]["c4"] = dr["c4"].ToString();
                            Response.Cookies["hycs"]["c10"] = dr["c10"].ToString();
                            Response.Cookies["hycs"]["c11"] = dr["c11"].ToString();
                            Response.Cookies["hycs"]["c13"] = dr["c13"].ToString();
                            Response.Cookies["hycs"]["s1"] = dr["s1"].ToString();

                            Response.Cookies["mretail_txfs"].Value = dr["txfs"].ToString(); //提醒方式
                            Response.Cookies["mretail_txfs"].Expires = new DateTime(2015, 1, 1);
                            //审批类 
                            Response.Cookies["hycs"]["s8"] = dr["s8"].ToString();
                            Response.Cookies["hycs"]["s9"] = dr["s9"].ToString();
                            Response.Cookies["hycs"]["s11"] = dr["s11"].ToString();
                            Response.Cookies["hycs"]["s12"] = dr["s12"].ToString();
                            Response.Cookies["hycs"]["s13"] = dr["s13"].ToString();
                            Response.Cookies["hycs"]["s15"] = dr["s15"].ToString();
                            Response.Cookies["hycs"]["t13"] = dr["t13"].ToString(); //提醒类
                            Response.Cookies["hycs"]["t14"] = dr["t14"].ToString();
                            Response.Cookies["hycs"]["t15"] = dr["t15"].ToString();
                        }
                        dr.Close();
                        //初始化系统参数 
                        if (Request.Cookies["mretail_bcount"] == null)
                        {
                            //大页每页行数 
                            Response.Cookies["mretail_bcount"].Value = Socut.Data.ExecuteScalar("select p_string from csda where paramt='bigrowcount'").ToString();
                            Response.Cookies["mretail_bcount"].Expires = new DateTime(2015, 1, 1);
                        }
                        if (Request.Cookies["mretail_scount"] == null)
                        {
                            //小页每页行数参数 
                            Response.Cookies["mretail_scount"].Value = Socut.Data.ExecuteScalar("select p_string from csda where paramt='smallrowcount'").ToString();
                            Response.Cookies["mretail_scount"].Expires = new DateTime(2015, 1, 1);
                        }
                        if (Request.Cookies["mretail_hcount"] == null)
                        {
                            //半页每页行数参数 
                            Response.Cookies["mretail_hcount"].Value = Socut.Data.ExecuteScalar("select p_string from csda where paramt='halfrowcount'").ToString();
                            Response.Cookies["mretail_hcount"].Expires = new DateTime(2015, 1, 1);
                        }
                        Response.Cookies["hycs"]["mkrz"] = Socut.Data.ExecuteScalar("select p_string from csda where paramt='yn_mkrz'").ToString();
                        //进入模块的监控日志参数 
                        Response.Cookies["hycs"]["rqfw"] = Socut.Data.ExecuteScalar("select p_string from csda where paramt='max_query'").ToString();
                        //一次性最多查询日期范围参数 
                        Response.Cookies["hygk"]["tbkd"] = Socut.Data.ExecuteScalar("select p_string from csda where paramt='max_chartsize'").ToString();
                        //图表自定义宽度限制的参数 
                        Response.Cookies["hygk"]["tpsize"] = Socut.Data.ExecuteScalar("select p_string from csda where paramt='xp_pic_size'").ToString();
                        //图片最大值的参数 
                        Response.Cookies["hygk"]["vdsize"] = Socut.Data.ExecuteScalar("select p_string from csda where paramt='video_size'").ToString();
                        //视频最大值的参数 
                        Response.Cookies["hygk"]["fjsize"] = Socut.Data.ExecuteScalar("select p_string from csda where paramt='fj_size'").ToString();
                        //允许上传附件最大值的参数 
                        Response.Cookies["hygk"]["dcsize"] = Socut.Data.ExecuteScalar("select p_string from csda where paramt='max_out_count'").ToString();
                        //限制导出数据最大记录数的参数 
                        Response.Cookies["hygk"]["uptime"] = Socut.Data.ExecuteScalar("select p_string from csda where paramt='new_date'").ToString();
                        //最新数据更新时间的参数 
                        Response.Cookies["hycs"]["ddqz"] = Socut.Data.ExecuteScalar("select p_string from csda where paramt='jjdd_qz'").ToString();
                        //紧急订单的前缀参数 
                        //企业简称和企业品牌 
                        Response.Cookies["huayi"]["qyjc"] = Server.UrlEncode(Socut.Data.ExecuteScalar("select qy_jc from qy").ToString());
                        Response.Cookies["huayi"]["qypp"] = Server.UrlEncode(Socut.Data.ExecuteScalar("select qy_pp from qy").ToString());
                        //更新在线用户表 
                        Socut.Data.ExecuteNonQuery("delete from online where username='" + UserName.Text + "'");
                        Socut.Data.ExecuteNonQuery("insert into online (username,logintime,activetime,ipaddr,authkey) values ('" + UserName.Text + "',getdate(),getdate(),'" + Request.UserHostAddress + "','" + Session.SessionID + "')");
                        //记录日志进入系统 
                        Socut.Data.ExecuteNonQuery("insert into dlrz(dl_id,dl_rq,dl_ip,dl_jqm,dl_zt) values('" + UserName.Text + "','" + DateTime.Now.ToString() + "','" + Request.UserHostAddress + "','" + Dns.GetHostName() + "','登陆系统')");
                        Server.Transfer("main.aspx");
                    }
                    else
                    {
                        dataR.Close();
                        Msg.Text = "对不起，该用户不在有效期范围内，不能登录！";
                    }
                }
                else
                {
                    dataR.Close();
                    Msg.Text = "对不起，该用户目前属于非正常状态，不能登录！";
                }
            }
            else
            {
                dataR.Close();
                //如果不存在该用户，则关闭连接并提示错误信息 
                Msg.Text = "用户名或密码错误！";
            }
        }
             */
        }
    }
}
