using System;
using System.Data;

public partial class Sofor_Default : System.Web.UI.Page
{
    MyFonksiyon f = new MyFonksiyon();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["crm"] == null)
        {
            Response.Redirect("/Login.aspx");
        }
        if (Session["mesaj"] == null)
        {
            Session.Add("mesaj", "");
        }
        string sayfa = "sefertanitim";

     
        pnlContainer.Controls.Add(LoadControl("/Controls/" + sayfa + ".ascx"));
        if (!Page.IsPostBack)
        {
            
        }
    }
}