using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_LokasyonTanitim : System.Web.UI.UserControl
{
    MyFonksiyon f = new MyFonksiyon();
    Helper hp = new Helper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            kartlarilistele();
        }
        if (Request.QueryString["id"] != null)
        {
            kartbilgilerinigetir();
        }
    }
    protected void Kaydet(object sender, EventArgs e)
    {
        if (!Helper.boskontrol(frm))
        {
            Helper.mesaj(0, "Kayıt Başarısız");
        }

        else
        {
            if (hp.kayitvarmi("Lokasyon_Kodu", "Lokasyon", txtLokasyonKodu.Text, Request.QueryString["id"]))
            {
                if (Request.QueryString["id"] == null)
                {
                    string sorgu = "INSERT INTO [dbo].[Lokasyon]([Lokasyon_Kodu],[Lokasyon_Aciklama])VALUES('" + f.Temizle(txtLokasyonKodu.Text.ToUpper()) + "','" + f.Temizle(txtLokasyonAciklama.Text.ToUpper()) + "')";
                    int sonuc = f.cmd(sorgu);
                    if (sonuc > 0)
                    {
                        Helper.mesaj(1, "Kayıt Başarılı");
                        Response.Redirect(Request.RawUrl);
                    }
                    else
                    {
                        Helper.mesaj(0, "Kayıt Başarısız");
                    }
                }
                else
                {
                    string sorgu = "UPDATE [dbo].[Lokasyon] SET [Lokasyon_Kodu]=" + f.Temizle(txtLokasyonKodu.Text.ToUpper()).tirnakla() + ",[Lokasyon_Aciklama]=" + f.Temizle(txtLokasyonAciklama.Text.ToUpper()).tirnakla() + " where Id=" + Request.QueryString["id"];
                    int sonuc = f.cmd(sorgu);
                    if (sonuc > 0)
                    {
                        Helper.mesaj(1, "Güncelleme Başarılı");  //sql e kayıt girildiği zaman yani işlem başarılı ise ...  
                        Response.Redirect(Request.RawUrl.Split('&')[0]);
                    }
                    else
                    {
                        Helper.mesaj(0, "Güncelleme Başarısız"); //herhangi bir sebepden dolayı sql e kayıt girilememesi durumunda
                    }
                }
            }
        }
    }
    public void kartlarilistele()
    {
        DataTable dt = f.GetDataTable("SELECT * FROM Lokasyon");
        if (dt != null)
        {
            rptKayitlarr.DataSource = dt;
            rptKayitlarr.DataBind();
        }
    }
    public void kartbilgilerinigetir()
    {
        try
        {
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            DataTable dt = f.GetDataTable("SELECT * FROM Lokasyon where Id=" + Request.QueryString["id"].ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                txtLokasyonKodu.Text = dt.Rows[0]["Lokasyon_Kodu"].ToString();
                txtLokasyonAciklama.Text = dt.Rows[0]["Lokasyon_Aciklama"].ToString();
            }

        }
        catch (Exception)
        {
            Response.Redirect("Default.aspx");
        }

    }


    public Control frmm { get; set; }
}