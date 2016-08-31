using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cikis_yap : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        HttpCookie myCookie;
        if (Request.Cookies["sofor"] != null)
        {
            myCookie = Request.Cookies["sofor"];
        }
        else
        {
            myCookie = Request.Cookies["admin"];
        }
        myCookie.Expires = DateTime.Now.AddMonths(-4);
        Response.Cookies.Add(myCookie);
        Response.Redirect("Default.aspx");
        Response.Redirect("/login.aspx");
    }
}