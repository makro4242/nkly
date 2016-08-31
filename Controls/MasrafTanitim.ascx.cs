using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_MasrafTanitim : System.Web.UI.UserControl
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
            if (hp.kayitvarmi("Masraf_kodu", "Masraflar", txtMasrafKodu.Text, Request.QueryString["id"]))
            {
                if (Request.QueryString["id"] == null)
                {
                    string sorgu = "INSERT INTO [dbo].[Masraflar]([Masraf_Kodu],[Masraf_Aciklama])VALUES('" + f.Temizle(txtMasrafKodu.Text.ToUpper()) + "','" + f.Temizle(txtMasrafAciklama.Text.ToUpper()) + "')";
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
                    string sorgu = "UPDATE [dbo].[Masraflar] SET [Masraf_kodu]=" + f.Temizle(txtMasrafKodu.Text.ToUpper()).tirnakla() + ",[Masraf_Aciklama]=" + f.Temizle(txtMasrafAciklama.Text.ToUpper()).tirnakla() + " where Id=" + Request.QueryString["id"];
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
        DataTable dt = f.GetDataTable("SELECT * FROM Masraflar");
        if (dt != null)
        {
            rptKayitlar.DataSource = dt;
            rptKayitlar.DataBind();
        }
    }
    public void kartbilgilerinigetir()
    {
        try
        {
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            DataTable dt = f.GetDataTable("SELECT * FROM Masraflar where Id=" + Request.QueryString["id"].ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                txtMasrafKodu.Text = dt.Rows[0]["Masraf_Kodu"].ToString();
                txtMasrafAciklama.Text = dt.Rows[0]["Masraf_Aciklama"].ToString();
            }

        }
        catch (Exception)
        {
            Response.Redirect("Default.aspx");
        }

    }

}