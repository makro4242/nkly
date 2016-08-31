using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PersonelTanitim : System.Web.UI.UserControl
{

    MyFonksiyon f = new MyFonksiyon();
    Helper hp = new Helper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            kartlarilistele();
            personelKoduGetir();
            if (Request.QueryString["id"] != null)
            {
                kartbilgilerinigetir();
            }
        }

    }
    public void personelKoduGetir()
    {
        int kodu = Convert.ToInt32(f.GetDataTable("select isNull(personel_kodu,0) from personeller order by convert(int,personel_kodu) desc").Rows[0][0]);
        kodu++;
        txtPersonelKodu.Text = kodu.ToString();
    }
    protected void Kaydet(object sender, EventArgs e)
    {
        if (!Helper.boskontrol(frm))
        {
            Helper.mesaj(0, "Kayıt Başarısız");
        }
        else
        {
            if (hp.kayitvarmi("Personel_Kodu", "Personeller", txtPersonelKodu.Text, Request.QueryString["id"]))
            {

                if (Request.QueryString["id"] == null)
                {
                    string sorgu = "INSERT INTO [dbo].[Personeller]([Personel_Kodu],[Personel_AdiSoyadi],[Personel_Telefonu],[Personel_Adresi])VALUES('" + txtPersonelKodu.Text.ToUpper() + "','" + f.Temizle(txtPersonelAdiSoyadi.Text.ToUpper()) + "','" + f.Temizle(txtPersonelTelefonu.Text.ToUpper()) + "','" + f.Temizle(txtPersonelAdresi.Text.ToUpper()) + "')";
                    int sonuc = f.cmd(sorgu);
                    if (sonuc > 0)
                    {
                        Helper.mesaj(1, "Kayıt Başarılı");
                        f.cmd("INSERT INTO Kullanicilar VALUES(" + f.Temizle(txtPersonelKodu.Text).tirnakla() + "," + f.Temizle(txtPersonelSifre.Text).tirnakla() + ",0)");
                        Response.Redirect(Request.RawUrl);
                    }
                    else
                    {
                        Helper.mesaj(0, "Kayıt Başarısız");
                    }
                }
                else
                {
                    string sorgu = "UPDATE [dbo].[Personeller] SET [Personel_Kodu]=" + f.Temizle(txtPersonelKodu.Text.ToUpper()).tirnakla() + ",[Personel_AdiSoyadi]=" + f.Temizle(txtPersonelAdiSoyadi.Text.ToUpper()).tirnakla() + ",[Personel_Telefonu]=" + f.Temizle(txtPersonelTelefonu.Text).tirnakla() + ",[Personel_Adresi]=" + f.Temizle(txtPersonelAdresi.Text.ToUpper()).tirnakla() + " where Id=" + Request.QueryString["id"];
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
        DataTable dt = f.GetDataTable("SELECT * FROM Personeller");
        rptKayitlar.DataSource = dt;
        rptKayitlar.DataBind();
    }
    public void kartbilgilerinigetir()
    {
        try
        {
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            DataTable dt = f.GetDataTable("SELECT * FROM Personeller where Id=" + Request.QueryString["id"].ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                txtPersonelKodu.Text = dt.Rows[0]["Personel_Kodu"].ToString();
                txtPersonelAdiSoyadi.Text = dt.Rows[0]["Personel_AdiSoyadi"].ToString();

            }
        }
        catch (Exception)
        {

            Response.Redirect("Default.aspx");
        }

    }

}