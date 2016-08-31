using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Sofor_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["sofor"]==null)
        {
            Response.Redirect("/Login.aspx");
        }
        if (Session["mesaj"] == null)
        {
            Session.Add("mesaj", "");
        }
        string sayfa = "SeferTanitim";

        if (Request.QueryString["Sayfa"] != null)
        {
            sayfa = Request.QueryString["Sayfa"];
        }
        pnlContainer.Controls.Add(LoadControl("Controls/" + sayfa + ".ascx"));
    }
}