using System;
using System.Data;

public partial class Sofor_Default : System.Web.UI.Page
{
    MyFonksiyon f = new MyFonksiyon();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["sofor"] == null)
        {
            Response.Redirect("/Login.aspx");
        }
        if (Session["mesaj"] == null)
        {
            Session.Add("mesaj", "");
        }
        string sayfa = "default";

        if (Request.QueryString["Sayfa"] != null)
        {
            sayfa = Request.QueryString["Sayfa"];
        }
        pnlContainer.Controls.Add(LoadControl("Controls/" + sayfa + ".ascx"));
        if (!Page.IsPostBack)
        {
            seferleriGetir();
        }
    }
    public void seferleriGetir()
    {
        DataTable dt = f.GetDataTable("select s.Sefer_Kodu,p.Personel_AdiSoyadi from Seferler s left join Personeller p on s.Sefer_Personel=p.Personel_Kodu where  Sefer_Personel=" + Request.Cookies["sofor"]["kullaniciadi"].ToString().tirnakla() + " and Sefer_AktifPasif=1");
        if (dt != null)
        {
            rptSeferler.DataSource = dt;
            rptSeferler.DataBind();
        }
    }
}