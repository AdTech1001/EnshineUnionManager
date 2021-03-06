﻿using System;
using System.Web;
using System.Web.UI;

namespace EnshineUnionManager
{
    public partial class MyPayMoneyInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie getCookies = Request.Cookies["UserLogin"];
                if (getCookies != null)
                {
                    spClientName.InnerHtml = "【" + Server.UrlDecode(getCookies["ClientName"].ToString()) + "】 Welcome To 益生联盟数据平台";

                    string[] Day = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
                    var hour = string.Empty;
                    if (DateTime.Now.Hour > 12)
                    {
                        hour = "下午" + DateTime.Now.Hour + "\n时";
                    }
                    else { hour = "上午" + DateTime.Now.Hour + "\n时"; }
                    spNowTime.InnerText = DateTime.Now.ToString("yyyy年MM月dd日") + "\n" + Day[Convert.ToInt16(DateTime.Now.DayOfWeek)] + "\n" + hour; ;
                }
                else
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('请登录在进行查询。');window.location.href='Login.aspx';</script>");
                }
            }
        }

    }
}