using System;
using System.Data;

public partial class Sofor_Controls_menu : System.Web.UI.UserControl
{
    MyFonksiyon f = new MyFonksiyon();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            seferleriGetir();
        }
    }
    public void seferleriGetir()
    {
        DataTable dt = f.GetDataTable("select s.Sefer_Kodu,p.Personel_AdiSoyadi from Seferler s left join Personeller p on s.Sefer_Personel=p.Personel_Kodu where Sefer_Personel=" + Request.Cookies["sofor"]["kullaniciadi"].ToString().tirnakla() + " and Sefer_AktifPasif=1");
    }
}